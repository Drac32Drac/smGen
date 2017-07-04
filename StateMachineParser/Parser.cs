using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StateMachineParser
{
    public static class Parser
    {
        public static List<KeyValuePair<string,string>> ParseAndGenerateCSFiles(
            string input, string nameSpace, List<string> externalUsings)
        {
            string commentsRemoved = removeComments(input);
            return ParseAndGenerateFiles(commentsRemoved, nameSpace, externalUsings,
                CodeGenerator.GenerateCS);
        }

        public static List<KeyValuePair<string, string>> ParseAndGenerateJavaFiles(
            string input, string package, List<string> externalImports)
        {
            string commentsRemoved = removeComments(input);
            List<KeyValuePair<string, string>> result = ParseAndGenerateFiles(commentsRemoved,
                package, externalImports, CodeGenerator.GenerateJava);
            return result;
        }

        private static string removeComments(string input)
        {
            StringBuilder result = new StringBuilder();
            CommentRemover commentRemover = new CommentRemover();
            
                // Get all non commented text
            commentRemover.AddOnParse((c) => result.Append(c));
            commentRemover.AddOnParseDoubleQuotes((c) => result.Append(c));
            commentRemover.AddOnParseSingleQuotes((c) => result.Append(c));

                // Comment Processing Exceptions
            commentRemover.AddOnIllegalCommentTypeEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character '" + c
                        + "' found while parsing comment type.");
                });
            commentRemover.AddOnIllegalSingleQuotesEnter((c) =>
                {
                    throw new ParseErrorException(
                        "Illegal newline character within single quotes found.");
                });
            commentRemover.AddOnIllegalDoubleQuotesEnter((c) =>
                {
                    throw new ParseErrorException(
                        "Illegal newline character within double quotes found.");
                });

            commentRemover.Input(new Queue<char>(input.ToCharArray()));
            
            return result.ToString();
        }

        public static List<KeyValuePair<string,string>> ParseAndGenerateFiles( string input,
            string nameSpace, List<string> externalSources, Func<string ,string, List<string>,
            string,string, List<string>, List<bool>, List<List<string>>, List<List<string>>,
            List<string>, List<string>, KeyValuePair<string,string>> CodeGenerator)
        {
            StringBuilder   machineName     = new StringBuilder();
            StringBuilder   inputType       = new StringBuilder();
            StringBuilder   stateName       = new StringBuilder();
            StringBuilder   commandOrNest   = new StringBuilder();
            StringBuilder   nextState       = new StringBuilder();
            StringBuilder   accept          = new StringBuilder();
            StringBuilder   decline         = new StringBuilder();
            StringBuilder   machineBody     = new StringBuilder();
            StringBuilder   groupTest       = new StringBuilder();
            StringBuilder   groupName       = new StringBuilder();
            StringBuilder   groupItem       = new StringBuilder();
            List<KeyValuePair<string, string>> result = 
                new List<KeyValuePair<string, string>>();

            ParseSMFile     Parser          = new ParseSMFile();
            ParseSMGroups   groupParser     = new ParseSMGroups();
            ParseSMState    stateParser     = new ParseSMState();

            string mName = "";
            string iType = "";
            List<string> sNames = new List<string>();
            List<bool> isNest = new List<bool>();
            List<List<string>> cOrNestValues = new List<List<string>>();
            List<List<string>> nStates = new List<List<string>>();
            List<string> mAccepts = new List<string>();
            List<string> mDeclines = new List<string>();
            List<string> groupNames = new List<string>();
            List<List<string>> groupItems = new List<List<string>>();
            string mBody = "";

                // Add Machine Name
            Parser.AddOnEndParseDeclaration((c) =>
            {
                mName = "";
                iType = "";
            });
            Parser.AddOnParseMachineName((c) => machineName.Append(c));

                // Add InputType
            Parser.AddOnParseInputType((c) => inputType.Append(c));

                // Finish Declaration
            Parser.AddOnEndParseInputTypeEnter((c) =>
            {
                mName = machineName.ToString();
                iType = inputType.ToString();
                machineName.Clear();
                inputType.Clear();
            });

                // Parse Body
            Parser.AddOnParseStates((c) => machineBody.Append(c));
            Parser.AddOnParseSingleQuotes((c) => machineBody.Append(c));
            Parser.AddOnParseDoubleQuotes((c) => machineBody.Append(c));
            Parser.AddOnNestedBrace((c) => machineBody.Append(c));
            Parser.AddOnNestedBraceSingeQuotes((c) => machineBody.Append(c));
            Parser.AddOnNestedBraceDoubleQuotes((c) => machineBody.Append(c));

                // Parse group name
            groupParser.AddOnGroupNameEnter((c) => groupName.Clear());
            groupParser.AddOnGroupName((c) => groupName.Append(c));
            groupParser.AddOnGroupNameExit((c) =>
            {
                groupNames.Add(groupName.ToString());
                groupItems.Add(new List<string>());
            });

                // Parse group item
            groupParser.AddOnGroupItem((c) => groupItem.Append(c));
            groupParser.AddOnItemSingleQuotes((c) => groupItem.Append(c));
            groupParser.AddOnItemDoubleQuotes((c) => groupItem.Append(c));

                // Finish group item
            groupParser.AddOnGroupItemExit((c) =>
            {
                groupItems[groupItems.Count - 1].Add(groupItem.ToString());
                groupItem.Clear();
            });
            groupParser.AddOnItemSingleQuotesExit((c) =>
            {
                groupItem.Append(c);
                groupItems[groupItems.Count - 1].Add(groupItem.ToString());
                groupItem.Clear();
            });
            groupParser.AddOnItemDoubleQuotesExit((c) =>
            {
                groupItem.Append(c);
                groupItems[groupItems.Count - 1].Add(groupItem.ToString());
                groupItem.Clear();
            });

                // Add State Names
            stateParser.AddOnStateNameEnter((c) => stateName.Clear());
            stateParser.AddOnStateName((c) => stateName.Append(c));
            stateParser.AddOnStateNameExit((c) => sNames.Add(stateName.ToString()));

                // Add Nested Machine or Command
            stateParser.AddOnSeparatorEnter((c) =>
            {
                cOrNestValues.Add(new List<string>());
                nStates.Add(new List<string>());
                isNest.Add(false);
            });
            stateParser.AddOnCommandOrNest((c) => commandOrNest.Append(c));

                // Confirm Nested Machine
            stateParser.AddOnPostNestedMachineEnter((c) => isNest[isNest.Count - 1] = true);

                // Add Nested Machine Accept and Decline
            stateParser.AddOnNestedMachineAccept((c) => accept.Append(c));
            stateParser.AddOnNestedMachineDecline((c) => decline.Append(c));

                // Finish Nested Machine
            stateParser.AddOnNestedMachineDeclineExit((c) =>
            {
                cOrNestValues[cOrNestValues.Count - 1].Add(commandOrNest.ToString());
                mAccepts.Add(accept.ToString());
                mDeclines.Add(decline.ToString());
                commandOrNest.Clear();
                accept.Clear();
                decline.Clear();
            });

                // Add Next State
            stateParser.AddOnNextState((c) => nextState.Append(c));

                // Add Command
            stateParser.AddOnCommand((c) => commandOrNest.Append(c));
            stateParser.AddOnParseSingleQuotes((c) => commandOrNest.Append(c));

                // Finish Single Quotes
            stateParser.AddOnParseSingleQuotesExit((c) => commandOrNest.Append('\''));

                // Finish Command/Next State pair
            stateParser.AddOnNextStateExit((c) =>
            {
                string command = commandOrNest.ToString();
                int index = -1;
                for (int i = 0; i < groupNames.Count; i++)
                {
                    if (command.CompareTo(groupNames[i]) == 0)
                    {
                        index = i;
                        break;
                    }
                }
                string next = nextState.ToString();
                if (index > -1)
                {
                    foreach (string item in groupItems[index])
                    {
                        cOrNestValues[cOrNestValues.Count - 1].Add(item);
                        nStates[nStates.Count - 1].Add(next);
                    }
                }
                else
                {
                    cOrNestValues[cOrNestValues.Count - 1].Add(command);
                    nStates[nStates.Count - 1].Add(next);
                }
                commandOrNest.Clear();
                nextState.Clear();
            });
            
                // Finish Command/NextState Sequence
            stateParser.AddOnPreStateNameEnter((c) =>
            {
                if (isNest.Count > 0 && !isNest[isNest.Count - 1])
                {
                    mAccepts.Add(null);
                    mDeclines.Add(null);
                }
            });

                // Finish Machine Definition and Parse Body
            Parser.AddOnAccept((c) =>
                {
                    mBody = machineBody.ToString();
                    string source = mBody;
                    machineBody.Clear();
                    // Parse Groups
                    groupParser.Input(new Queue<char>(mBody.ToCharArray()));
                    mBody = machineBody.ToString();

                        // Parse States
                    if (stateParser.Input(new Queue<char>(mBody.ToCharArray())) != false)
                    {
                        CheckStateReferences(sNames, isNest, nStates, mAccepts, mDeclines);
                        result.Add(CodeGenerator(source, nameSpace, externalSources, mName,
                            iType, sNames, isNest, cOrNestValues, nStates,
                            mAccepts, mDeclines));
                    }
                    
                    mName = "";
                    iType = "";
                    sNames = new List<string>();
                    isNest = new List<bool>();
                    cOrNestValues = new List<List<string>>();
                    nStates = new List<List<string>>();
                    mAccepts = new List<string>();
                    mDeclines = new List<string>();
                    groupNames = new List<string>();
                    mBody = "";
                    Parser.ResetStateOnEnd();
                });

                // Parse group test
            groupParser.AddOnParseGroupDeclaration((c) => groupTest.Append(c));
            groupParser.ParseGroupDeclarationMachine.AddOnDecline((c) =>
                {
                    groupTest.Append(c);
                    machineBody.Append(groupTest);
                    groupTest.Clear();
                });
            groupParser.ParseGroupDeclarationMachine.AddOnAccept((c) =>
                {
                    groupTest.Clear();
                });

                // Parser Exceptions
            Parser.AddOnIllegalDeclarationCharEnter((c) => 
                {
                    throw new ParseErrorException("Illegal character '" + c 
                        + "' found in declaration of " + mName + ".");
                });
            Parser.AddOnIllegalStateIdentifierEnter((c) =>
            {
                throw new ParseErrorException("Illegal Identifier character '" + c + "' found in "
                    + mName + ".");
            });
            Parser.AddOnIllegalStateContentEnter((c) =>
            {
                throw new ParseErrorException("Illegal Content character '" + c + "' found in "
                    + mName + ".");
            });
            Parser.AddOnIllegalNestedStateContentEnter((c) =>
            {
                throw new ParseErrorException("Illegal Nested Content character '" + c + "' found in "
                    + mName + ".");
            });

                // Group Parser Exceptions
            groupParser.AddOnIllegalGroupItemCharEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character '"
                        + c + "' found in group items in group '"
                        + groupName.ToString() + "'.");
                });
            groupParser.AddOnIllegalGroupNameCharEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character '"
                        + c + "' found in group name.");
                });
            groupParser.AddOnMissingGroupEqualsEnter((c) =>
                {
                    throw new ParseErrorException("Missing '=' in group '"
                        + groupName.ToString() + "'.");
                });
            groupParser.AddOnIllegalGroupStartEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character in group.  Found '"
                        + c + "', expected '{'.");
                });
            groupParser.AddOnIllegalGroupTokenEqualsEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character in group '" +
                        groupName.ToString() + "'.  Found '" + c + "', expected '='.");
                });
            groupParser.AddOnMissingGroupItemDelimeterEnter((c) =>
                {
                    throw new ParseErrorException("Missing ',' between group items in group '"
                        + groupName.ToString() + "'.");
                });

                // State Parser Exceptions
            stateParser.AddOnIllegalStateNameCharEnter((c) =>
                {
                    throw new ParseErrorException("Illegal character '"
                        + c + "' found in state name.");
                });
            stateParser.AddOnMissingMainColonEnter((c) =>
                {
                    throw new ParseErrorException("Missing ':' in state '"
                        + stateName.ToString() + "'.");
                });
            stateParser.AddOnIllegalCommandCharEnter((c) =>
                {
                    throw new ParseErrorException("Illegal command character '"
                        + c + "' found in state '" + stateName.ToString() + "'.");
                });
            stateParser.AddOnIllegalNextStateCharEnter((c) =>
                {
                    throw new ParseErrorException("Illegal destination state character '"
                        + c + "' found in state '" + stateName.ToString() + "'.");
                });
            stateParser.AddOnMissingEqualsOrTernaryEnter((c) =>
                {
                    throw new ParseErrorException("Missing '?' or '=' after '" 
                        + commandOrNest.ToString() + "' in state '" + stateName.ToString() + "'.");
                });
            stateParser.AddOnMissingNestColonEnter((c) =>
                {
                    throw new ParseErrorException("Missing ':' after '"
                        + accept.ToString() + "' in state '" + stateName.ToString() + "'.");
                });
            stateParser.AddOnMissingNestSemicolonEnter((c) =>
                {
                    throw new ParseErrorException("Missing ';' after '"
                        + decline.ToString() + "' in state '" + stateName.ToString() + "'.");
                });
            stateParser.AddOnMissingCommaOrSemicolonEnter((c) =>
                {
                    throw new ParseErrorException("Missing ',' or ';' after '"
                        + nextState.ToString() + "' in state '" + stateName.ToString() + "'.");
                });

            Parser.Input(new Queue<char>(input.ToCharArray()));

            return result;
        }

        private static void CheckStateReferences(List<string> stateNames, List<bool> isNest,
            List<List<string>> nextStates, List<string> nestAccepts, List<string> nestDeclines)
        {
            // check all commandOrNestValues
            for (int i = 0; i < isNest.Count; i++)
            {
                if (isNest[i])
                {
                    bool validAccept = false;
                    bool validDecline = false;
                    if (nestAccepts[i].CompareTo("accept") == 0)
                        validAccept = true;
                    else if (nestAccepts[i].CompareTo("decline") == 0)
                        validAccept = true;
                    if (nestDeclines[i].CompareTo("accept") == 0)
                        validDecline = true;
                    else if (nestDeclines[i].CompareTo("decline") == 0)
                        validDecline = true;
                    foreach (string state in stateNames)
                    {
                        if (validAccept && validDecline)
                            break;
                        if (nestAccepts[i].CompareTo(state) == 0)
                            validAccept = true;
                        if (nestDeclines[i].CompareTo(state) == 0)
                            validDecline = true;
                    }
                    if (!(validAccept && validDecline))
                    {
                        if (!validAccept)
                            throw new ParseErrorException(
                                "Invalid success state found in state '" + stateNames[i]
                                + "'.  " + nestAccepts[i] + " is not a valid state.");
                        if (!validDecline)
                            throw new ParseErrorException(
                                "Invalid failure state found in state '" + stateNames[i]
                                + "'.  " + nestDeclines[i] + " is not a valid state.");
                    }
                }
                else
                {
                    foreach (string nextState in nextStates[i])
                    {
                        bool valid = false;
                        if (nextState.CompareTo("accept") == 0)
                            continue;
                        if (nextState.CompareTo("decline") == 0)
                            continue;
                        foreach (string state in stateNames)
                        {
                            if (nextState.CompareTo(state) == 0)
                            {
                                valid = true;
                                break;
                            }
                        }
                        if (!valid)
                            throw new ParseErrorException("Invalid next state found in state '"
                                + stateNames[i] + "'.  " + nextState
                                + " is not a valid state.");
                    }
                }
            }
        }
    }
}
