using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StateMachineParser
{
    public static partial class CodeGenerator
    {
        public static KeyValuePair<string, string> GenerateCS(string source,
            string namespaceName, List<string> externalUsings, string machineName,
            string inputType, List<string> stateNames, List<bool> isNest,
            List<List<string>> commandOrNestValues, List<List<string>> nextStates,
            List<string> nestAccepts, List<string> nestDeclines)
        {
            StringBuilder result = new StringBuilder();

            // Generated Code Comments
            result.AppendLine("// ************************ " + machineName + " : "
                + inputType + " ************************");
            string[] codeLines = Regex.Split(source, "\r\n|\r|\n");
            foreach (string line in codeLines)
            {
                result.AppendLine("// " + line);
            }
            result.AppendLine("//");
            result.AppendLine("// This file was automatically generated from a tool that converted the");
            result.AppendLine("// above state machine definition into this state machine class.");
            result.AppendLine("// Any changes to this code will be replaced the next time the code is generated.");
            result.AppendLine();

            // Usings and Namespace
            result.AppendLine("using System;");
            result.AppendLine("using System.Collections.Generic;");
            if (externalUsings != null)
            {
                foreach (string externalUsing in externalUsings)
                {
                    result.AppendLine("using " + externalUsing + ";");
                }
            }
            result.AppendLine("namespace " + namespaceName);
            result.AppendLine("{");

            // Class declaration
            result.AppendLine("\tpublic class " + machineName);
            result.AppendLine("\t{");

            // States enum
            result.AppendLine("\t\tpublic enum States");
            result.AppendLine("\t\t{");
            {
                int wrapCount = 0;
                int index = 0;
                foreach (string s in stateNames)
                {
                    if (wrapCount == 2)
                    {
                        wrapCount = 0;
                        result.AppendLine();
                    }
                    if (wrapCount == 0)
                        result.Append("\t\t");
                    result.Append("\t"); result.Append(s);
                    result.Append(" = "); result.Append(index); result.Append(", ");
                    index++;
                    wrapCount++;
                }
            }
            result.AppendLine();
            result.AppendLine("\t\t}"); result.AppendLine();

            // Fields
            result.AppendLine("\t\tprivate States? state = null;");
            result.AppendLine("\t\tpublic States? CurrentState { get { return state; } }");
            result.AppendLine("\t\tprivate " + inputType + " currentCommand;");
            result.AppendLine("\t\tpublic " + inputType
                + " CurrentCommand { get { return currentCommand; } }");
            result.AppendLine("\t\tprivate bool reset = false;");
            result.AppendLine();

            for (int i = 0; i < stateNames.Count; i++)
            {
                result.AppendLine("\t\tprivate Action<" + inputType + "> on" +
                    stateNames[i] + "State = null;");
                result.AppendLine("\t\tprivate Action<" + inputType + "> on" +
                    stateNames[i] + "Enter = null;");
                result.AppendLine("\t\tprivate Action<" + inputType + "> on" +
                    stateNames[i] + "Exit = null;");
            }
            result.AppendLine("\t\tprivate Action<" + inputType + "> onAccept = null;");
            result.AppendLine("\t\tprivate Action<" + inputType + "> onDecline = null;");
            result.AppendLine("\t\tprivate Action<" + inputType + "> onEnd = null;");
            result.AppendLine();

            // Nested State Machines
            for (int i = 0; i < commandOrNestValues.Count; i++)
            {
                if (isNest[i])
                {
                    result.AppendLine("\t\tpublic readonly " + commandOrNestValues[i][0]
                        + " " + stateNames[i] + "Machine = new "
                        + commandOrNestValues[i][0] + "();");
                }
            }
            result.AppendLine();

            // Constructor

            // Input
            result.AppendLine("\t\tpublic bool? Input(Queue<" + inputType + "> data)");
            result.AppendLine("\t\t{");
            result.AppendLine("\t\t\tif (reset)");
            result.AppendLine("\t\t\t\tstate = null;");
            result.AppendLine("\t\t\tbool? result = null;");
            result.AppendLine("\t\t\tif (data == null)");
            result.AppendLine("\t\t\t\treturn null;");
            for (int i = 0; i < isNest.Count; i++)
            {
                if (isNest[i])
                {
                    result.AppendLine("\t\t\tbool? nestResult;");
                    break;
                }
            }
            result.AppendLine();
            result.AppendLine("Reset:");
            result.AppendLine("\t\t\treset = false;");
            result.AppendLine("\t\t\tswitch (state)");
            result.AppendLine("\t\t\t{");
            result.AppendLine("\t\t\t\tcase null:");
            result.AppendLine("\t\t\t\t\tif (data.Count > 0)");
            result.AppendLine("\t\t\t\t\t{");
            result.AppendLine("\t\t\t\t\t\tstate = States." + stateNames[0] + ";");
            result.AppendLine("\t\t\t\t\t\tgoto Resume" + stateNames[0] + ";");
            result.AppendLine("\t\t\t\t\t}");
            result.AppendLine("\t\t\t\t\telse");
            result.AppendLine("\t\t\t\t\t\tgoto End;");
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.AppendLine("\t\t\t\tcase States." + stateNames[i] + ":");
                result.AppendLine("\t\t\t\t\tgoto Resume" + stateNames[i] + ";");
            }
            result.AppendLine("\t\t\t}");
            result.AppendLine();

            result.AppendLine();
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.AppendLine("Enter" + stateNames[i] + ":");
                result.AppendLine("\t\t\tstate = States." + stateNames[i] + ";");
                result.AppendLine("\t\t\tif (on" + stateNames[i] + "Enter != null)");
                result.AppendLine("\t\t\t\ton" + stateNames[i] + "Enter(currentCommand);");
                result.AppendLine();
                if (isNest[i])
                {
                    if (stateNames[i].CompareTo(nestAccepts[i]) == 0
                            || stateNames[i].CompareTo(nestDeclines[i]) == 0)
                        result.AppendLine(stateNames[i] + ":");
                }
                else
                {
                    for (int j = 0; j < nextStates[i].Count; j++)
                    {
                        if (stateNames[i].CompareTo(nextStates[i][j]) != 0)
                            continue;
                        result.AppendLine(stateNames[i] + ":");
                        break;
                    }
                }

                result.AppendLine("\t\t\tif (on" + stateNames[i] + "State != null)");
                result.AppendLine("\t\t\t\ton" + stateNames[i] + "State(currentCommand);");
                result.AppendLine("Resume" + stateNames[i] + ":");
                
                if (isNest[i])
                {
                    result.AppendLine("\t\t\tnestResult = "
                        + stateNames[i] + "Machine.Input(data);");
                    result.AppendLine("\t\t\tswitch (nestResult)");
                    result.AppendLine("\t\t\t{");
                    result.AppendLine("\t\t\t\tcase null:");
                    result.AppendLine("\t\t\t\t\tgoto End;");
                    result.AppendLine("\t\t\t\tcase true:");
                    if (nestAccepts[i].CompareTo(stateNames[i]) != 0)
                    {
                        result.AppendLine("\t\t\t\t\tif (on" + stateNames[i] + "Exit != null)");
                        result.AppendLine("\t\t\t\t\t\ton" + stateNames[i]
                            + "Exit(" + stateNames[i] + "Machine.CurrentCommand);");
                    }
                    if (nestAccepts[i].CompareTo("accept") == 0)
                        result.AppendLine("\t\t\t\t\tgoto Accept;");
                    else if (nestAccepts[i].CompareTo("decline") == 0)
                        result.AppendLine("\t\t\t\t\tgoto Decline;");
                    else
                    {
                        if (nestAccepts[i].CompareTo(stateNames[i]) != 0)
                            result.AppendLine("\t\t\t\t\tgoto Enter" + nestAccepts[i] + ";");
                        else
                            result.AppendLine("\t\t\t\t\tgoto " + nestAccepts[i] + ";");
                    }
                    result.AppendLine("\t\t\t\tcase false:");
                    if (nestDeclines[i].CompareTo(stateNames[i]) != 0)
                    {
                        result.AppendLine("\t\t\tif (on" + stateNames[i] + "Exit != null)");
                        result.AppendLine("\t\t\t\t\t\ton" + stateNames[i]
                            + "Exit(" + stateNames[i] + "Machine.CurrentCommand);");
                    }
                    if (nestDeclines[i].CompareTo("accept") == 0)
                        result.AppendLine("\t\t\t\t\tgoto Accept;");
                    else if (nestDeclines[i].CompareTo("decline") == 0)
                        result.AppendLine("\t\t\t\t\tgoto Decline;");
                    else
                    {
                        if (nestDeclines[i].CompareTo(stateNames[i]) != 0)
                            result.AppendLine("\t\t\t\t\tgoto Enter" + nestDeclines[i] + ";");
                        else
                            result.AppendLine("\t\t\t\t\tgoto " + nestDeclines[i] + ";");
                    }
                    result.AppendLine("\t\t\t}");
                }
                else
                {
                    result.AppendLine("\t\t\tif (data.Count > 0)");
                    result.AppendLine("\t\t\t\tcurrentCommand = data.Dequeue();");
                    result.AppendLine("\t\t\telse");
                    result.AppendLine("\t\t\t\tgoto End;");
                    result.AppendLine("\t\t\tswitch (currentCommand)");
                    result.AppendLine("\t\t\t{");
                    for (int j = 0; j < commandOrNestValues[i].Count; j++)
                    {
                        if (commandOrNestValues[i][j].CompareTo("default") != 0)
                            result.AppendLine("\t\t\t\tcase " + commandOrNestValues[i][j] + ":");
                        else
                            result.AppendLine("\t\t\t\tdefault:");
                        int index = 0;
                        for (int n = 0; n < stateNames.Count; n++)
                        {
                            if (stateNames[n].CompareTo(nextStates[i][j]) == 0)
                            {
                                index = n;
                                break;
                            }
                        }
                        if (stateNames[i].CompareTo(nextStates[i][j]) == 0)
                        {
                            result.AppendLine("\t\t\t\t\tgoto " + stateNames[index] + ";");
                        }
                        else
                        {
                            result.AppendLine("\t\t\t\t\tif (on" + stateNames[i]
                                + "Exit != null)");
                            result.AppendLine("\t\t\t\t\t\ton" + stateNames[i]
                                + "Exit(currentCommand);");
                            if (nextStates[i][j].CompareTo("accept") == 0)
                                result.AppendLine("\t\t\t\t\tgoto Accept;");
                            else if (nextStates[i][j].CompareTo("decline") == 0)
                                result.AppendLine("\t\t\t\t\tgoto Decline;");
                            else
                                result.AppendLine("\t\t\t\t\tgoto Enter" + nextStates[i][j] + ";");
                        }
                    }
                    result.AppendLine("\t\t\t}");
                }

                result.AppendLine();
            }

            bool hasAccept = false;
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                {
                    if (nestAccepts[i].CompareTo("accept") == 0)
                    {
                        hasAccept = true;
                        goto GenAccept;
                    }
                    if (nestDeclines[i].CompareTo("accept") == 0)
                    {
                        hasAccept = true;
                        goto GenAccept;
                    }
                }
                else
                {
                    for (int j = 0; j < commandOrNestValues[i].Count; j++)
                        if (nextStates[i][j].CompareTo("accept") == 0)
                        {
                            hasAccept = true;
                            goto GenAccept;
                        }
                }
            }
GenAccept:
            if (hasAccept)
            {
                result.AppendLine("Accept:");
                result.AppendLine("\t\t\tresult = true;");
                result.AppendLine("\t\t\tstate = null;");
                result.AppendLine("\t\t\tif (onAccept != null)");
                result.AppendLine("\t\t\t\tonAccept(currentCommand);");
                result.AppendLine("\t\t\tgoto End;");
                result.AppendLine();
            }

            bool hasDecline = false;
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                {
                    if (nestAccepts[i].CompareTo("decline") == 0)
                    {
                        hasDecline = true;
                        goto GenDecline;
                    }
                    if (nestDeclines[i].CompareTo("decline") == 0)
                    {
                        hasDecline = true;
                        goto GenDecline;
                    }
                }
                else
                {
                    for (int j = 0; j < commandOrNestValues[i].Count; j++)
                        if (nextStates[i][j].CompareTo("decline") == 0)
                        {
                            hasDecline = true;
                            goto GenDecline;
                        }
                }
            }

GenDecline:
            if (hasDecline)
            {
                result.AppendLine("Decline:");
                result.AppendLine("\t\t\tresult = false;");
                result.AppendLine("\t\t\tstate = null;");
                result.AppendLine("\t\t\tif (onDecline != null)");
                result.AppendLine("\t\t\t\tonDecline(currentCommand);");
                result.AppendLine("\t\t\tgoto End;");
                result.AppendLine();
            }

            result.AppendLine("End:");
            result.AppendLine("\t\t\tif (onEnd != null)");
            result.AppendLine("\t\t\t\tonEnd(currentCommand);");
            result.AppendLine("\t\t\tif (reset)");
            result.AppendLine("\t\t\t{");
            result.AppendLine("\t\t\t\tgoto Reset;");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t\treturn result;");
            result.AppendLine("\t\t}");
            result.AppendLine();

            // Add OnState Actions
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                {
                    result.Append("\t\tpublic void AddOn" + stateNames[i] + "(Action<");
                    result.Append(inputType); result.AppendLine("> addedFunc)");
                    result.AppendLine("\t\t{");
                    result.AppendLine("\t\t\tAddOn" + stateNames[i] + "Enter(addedFunc);");
                    result.AppendLine("\t\t\t" + stateNames[i]
                        + "Machine.addOnAllStates(addedFunc);");
                    result.AppendLine("\t\t}"); result.AppendLine();
                }
                else
                {
                    result.Append("\t\tpublic void AddOn" + stateNames[i] + "(Action<");
                    result.Append(inputType); result.AppendLine("> addedFunc)");
                    result.AppendLine("\t\t{");
                    result.AppendLine("\t\t\ton" + stateNames[i] + "State += addedFunc;");
                    result.AppendLine("\t\t}"); result.AppendLine();
                }
            }

            // Add OnEnter Actions
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.Append("\t\tpublic void AddOn" + stateNames[i] + "Enter(Action<");
                result.Append(inputType); result.AppendLine("> addedFunc)");
                result.AppendLine("\t\t{");
                result.AppendLine("\t\t\ton" + stateNames[i] + "Enter += addedFunc;");
                result.AppendLine("\t\t}"); result.AppendLine();
            }

            // Add OnExit Actions
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.Append("\t\tpublic void AddOn" + stateNames[i] + "Exit(Action<");
                result.Append(inputType); result.AppendLine("> addedFunc)");
                result.AppendLine("\t\t{");
                result.AppendLine("\t\t\ton" + stateNames[i] + "Exit += addedFunc;");
                result.AppendLine("\t\t}"); result.AppendLine();
            }

            // Add OnAccept Actions
            result.Append("\t\tpublic void AddOnAccept(Action<");
            result.Append(inputType); result.AppendLine("> addedFunc)");
            result.AppendLine("\t\t{");
            result.AppendLine("\t\t\tonAccept += addedFunc;");
            result.AppendLine("\t\t}"); result.AppendLine();

            // Add OnDecline Actions
            result.Append("\t\tpublic void AddOnDecline(Action<");
            result.Append(inputType); result.AppendLine("> addedFunc)");
            result.AppendLine("\t\t{");
            result.AppendLine("\t\t\tonDecline += addedFunc;");
            result.AppendLine("\t\t}"); result.AppendLine();

            // Add OnEnd Actions
            result.Append("\t\tpublic void AddOnEnd(Action<");
            result.Append(inputType); result.AppendLine("> addedFunc)");
            result.AppendLine("\t\t{");
            result.AppendLine("\t\t\tonEnd += addedFunc;");
            result.AppendLine("\t\t}"); result.AppendLine();

            // add to all states
            result.AppendLine("\t\tinternal void addOnAllStates( Action<"
                + inputType + "> addedFunc )");
            result.AppendLine("\t\t{");
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                {
                    result.AppendLine("\t\t\tAddOn" + stateNames[i] + "(addedFunc);");
                }
                else
                {
                    result.AppendLine("\t\t\ton" + stateNames[i] + "State += addedFunc;");
                }
            }
            result.AppendLine("\t\t}"); result.AppendLine();
            result.AppendLine();

            // reset state
            result.AppendLine("\t\tpublic void ResetStateOnEnd()");
            result.AppendLine("\t\t{");
            result.AppendLine("\t\t\tstate = null;");
            result.AppendLine("\t\t\treset = true;");
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                    result.AppendLine("\t\t\t" + stateNames[i] + "Machine.ResetStateOnEnd();");
            }
            result.AppendLine("\t\t}");

            // End of Class
            result.AppendLine("\t}");
            result.AppendLine("}");

            // Output result
            return new KeyValuePair<string, string>(machineName, result.ToString());
        }
    }
}
