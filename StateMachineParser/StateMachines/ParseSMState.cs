// ************************ ParseSMState : char ************************
// 
// 	group whitespace		= { ' ', '\t', '\n', '\r' }
// 	group alphaNumeric		= { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
// 			'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
// 			'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
// 			'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
// 			'8', '9', '_', '.' }
// 
// 	PreStateName			: whitespace = PreStateName, '}' = accept,
// 			alphaNumeric = StateName, default = IllegalStateNameChar;
// 	StateName				: whitespace = PostStateName, ':' = Separator,
// 			alphaNumeric = StateName, default = IllegalStateNameChar;
// 	PostStateName			: whitespace = PostStateName, ':' = Separator,
// 			alphaNumeric = MissingMainColon, default = IllegalStateNameChar;
// 	Separator				: whitespace = Separator, '\'' = ParseSingleQuotes,
// 			'"' = ParseDoubleQuotes, alphaNumeric = CommandOrNest,
// 			default = IllegalCommandChar;
// 	CommandOrNest			: whitespace = PostCommandOrNest, '=' = PreNextState,
// 			'?' = PostNestedMachine, alphaNumeric = CommandOrNest,
// 			default = IllegalCommandChar;
// 	PostCommandOrNest		: whitespace = PostCommandOrNest, '=' = PreNextState,
// 			'?' = PostNestedMachine, alphaNumeric = MissingEqualsOrTernary,
// 			'\'' = MissingEqualsOrTernary, '"' = MissingEqualsOrTernary, 
// 			default = IllegalCommandChar;
// 	PostNestedMachine		: whitespace = PostNestedMachine,
// 			alphaNumeric = NestedMachineAccept, default = IllegalNextStateChar;
// 	NestedMachineAccept		: whitespace = PostNestedMachineAccept,
// 			':' = PreNestedMachineDecline, alphaNumeric = NestedMachineAccept,
// 			default = IllegalNextStateChar;
// 	PostNestedMachineAccept	: whitespace = PostNestedMachineAccept,
// 			':' = PreNestedMachineDecline, alphaNumeric = MissingNestColon,
// 			default = IllegalNextStateChar;
// 	PreNestedMachineDecline	: whitespace = PreNestedMachineDecline,
// 			alphaNumeric = NestedMachineDecline, default = IllegalNextStateChar;
// 	NestedMachineDecline	: whitespace = PostNestedMachineDecline,
// 			';' = PreStateName, alphaNumeric = NestedMachineDecline,
// 			default = IllegalNextStateChar;
// 	PostNestedMachineDecline	: whitespace = PostNestedMachineDecline,
// 			';' = PreStateName, default = MissingNestSemicolon;
// 	PreCommand				: whitespace = PreCommand, '\'' = ParseSingleQuotes,
// 			 '"' = ParseDoubleQuotes, alphaNumeric = Command, default = IllegalCommandChar;
// 		
// 	ParseSingleQuotes		: ParseSingleQuotes ? PostCommand : decline;
// 	ParseDoubleQuotes		: ParseDoubleQuotes ? PostCommand : decline;
// 	Command					: whitespace = PostCommand, '=' = PreNextState,
// 			alphaNumeric = Command, default = IllegalCommandChar;
// 	PostCommand				: whitespace = PostCommand, '=' = PreNextState,
// 			alphaNumeric = MissingEqualsOrTernary, default = IllegalCommandChar;
// 	PreNextState			: whitespace = PreNextState, alphaNumeric = NextState,
// 			default = IllegalNextStateChar;
// 	NextState				: whitespace = PostNextState, ',' = PreCommand,
// 			';' = PreStateName, alphaNumeric = NextState, default = IllegalNextStateChar;
// 	PostNextState			: whitespace = PostNextState, ',' = PreCommand, ';' = PreStateName,
// 			alphaNumeric = MissingCommaOrSemicolon, default = IllegalNextStateChar;
// 		
// 	IllegalStateNameChar	: default = decline;
// 	IllegalCommandChar		: default = decline;
// 	IllegalNextStateChar	: default = decline;
// 	MissingMainColon		: default = decline;
// 	MissingEqualsOrTernary	: default = decline;
// 	MissingNestColon		: default = decline;
// 	MissingNestSemicolon	: default = decline;
// 	MissingCommaOrSemicolon	: default = decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class ParseSMState
	{
		public enum States
		{
			PreStateName = 0, 	StateName = 1, 
			PostStateName = 2, 	Separator = 3, 
			CommandOrNest = 4, 	PostCommandOrNest = 5, 
			PostNestedMachine = 6, 	NestedMachineAccept = 7, 
			PostNestedMachineAccept = 8, 	PreNestedMachineDecline = 9, 
			NestedMachineDecline = 10, 	PostNestedMachineDecline = 11, 
			PreCommand = 12, 	ParseSingleQuotes = 13, 
			ParseDoubleQuotes = 14, 	Command = 15, 
			PostCommand = 16, 	PreNextState = 17, 
			NextState = 18, 	PostNextState = 19, 
			IllegalStateNameChar = 20, 	IllegalCommandChar = 21, 
			IllegalNextStateChar = 22, 	MissingMainColon = 23, 
			MissingEqualsOrTernary = 24, 	MissingNestColon = 25, 
			MissingNestSemicolon = 26, 	MissingCommaOrSemicolon = 27, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onPreStateNameState = null;
		private Action<char> onPreStateNameEnter = null;
		private Action<char> onPreStateNameExit = null;
		private Action<char> onStateNameState = null;
		private Action<char> onStateNameEnter = null;
		private Action<char> onStateNameExit = null;
		private Action<char> onPostStateNameState = null;
		private Action<char> onPostStateNameEnter = null;
		private Action<char> onPostStateNameExit = null;
		private Action<char> onSeparatorState = null;
		private Action<char> onSeparatorEnter = null;
		private Action<char> onSeparatorExit = null;
		private Action<char> onCommandOrNestState = null;
		private Action<char> onCommandOrNestEnter = null;
		private Action<char> onCommandOrNestExit = null;
		private Action<char> onPostCommandOrNestState = null;
		private Action<char> onPostCommandOrNestEnter = null;
		private Action<char> onPostCommandOrNestExit = null;
		private Action<char> onPostNestedMachineState = null;
		private Action<char> onPostNestedMachineEnter = null;
		private Action<char> onPostNestedMachineExit = null;
		private Action<char> onNestedMachineAcceptState = null;
		private Action<char> onNestedMachineAcceptEnter = null;
		private Action<char> onNestedMachineAcceptExit = null;
		private Action<char> onPostNestedMachineAcceptState = null;
		private Action<char> onPostNestedMachineAcceptEnter = null;
		private Action<char> onPostNestedMachineAcceptExit = null;
		private Action<char> onPreNestedMachineDeclineState = null;
		private Action<char> onPreNestedMachineDeclineEnter = null;
		private Action<char> onPreNestedMachineDeclineExit = null;
		private Action<char> onNestedMachineDeclineState = null;
		private Action<char> onNestedMachineDeclineEnter = null;
		private Action<char> onNestedMachineDeclineExit = null;
		private Action<char> onPostNestedMachineDeclineState = null;
		private Action<char> onPostNestedMachineDeclineEnter = null;
		private Action<char> onPostNestedMachineDeclineExit = null;
		private Action<char> onPreCommandState = null;
		private Action<char> onPreCommandEnter = null;
		private Action<char> onPreCommandExit = null;
		private Action<char> onParseSingleQuotesState = null;
		private Action<char> onParseSingleQuotesEnter = null;
		private Action<char> onParseSingleQuotesExit = null;
		private Action<char> onParseDoubleQuotesState = null;
		private Action<char> onParseDoubleQuotesEnter = null;
		private Action<char> onParseDoubleQuotesExit = null;
		private Action<char> onCommandState = null;
		private Action<char> onCommandEnter = null;
		private Action<char> onCommandExit = null;
		private Action<char> onPostCommandState = null;
		private Action<char> onPostCommandEnter = null;
		private Action<char> onPostCommandExit = null;
		private Action<char> onPreNextStateState = null;
		private Action<char> onPreNextStateEnter = null;
		private Action<char> onPreNextStateExit = null;
		private Action<char> onNextStateState = null;
		private Action<char> onNextStateEnter = null;
		private Action<char> onNextStateExit = null;
		private Action<char> onPostNextStateState = null;
		private Action<char> onPostNextStateEnter = null;
		private Action<char> onPostNextStateExit = null;
		private Action<char> onIllegalStateNameCharState = null;
		private Action<char> onIllegalStateNameCharEnter = null;
		private Action<char> onIllegalStateNameCharExit = null;
		private Action<char> onIllegalCommandCharState = null;
		private Action<char> onIllegalCommandCharEnter = null;
		private Action<char> onIllegalCommandCharExit = null;
		private Action<char> onIllegalNextStateCharState = null;
		private Action<char> onIllegalNextStateCharEnter = null;
		private Action<char> onIllegalNextStateCharExit = null;
		private Action<char> onMissingMainColonState = null;
		private Action<char> onMissingMainColonEnter = null;
		private Action<char> onMissingMainColonExit = null;
		private Action<char> onMissingEqualsOrTernaryState = null;
		private Action<char> onMissingEqualsOrTernaryEnter = null;
		private Action<char> onMissingEqualsOrTernaryExit = null;
		private Action<char> onMissingNestColonState = null;
		private Action<char> onMissingNestColonEnter = null;
		private Action<char> onMissingNestColonExit = null;
		private Action<char> onMissingNestSemicolonState = null;
		private Action<char> onMissingNestSemicolonEnter = null;
		private Action<char> onMissingNestSemicolonExit = null;
		private Action<char> onMissingCommaOrSemicolonState = null;
		private Action<char> onMissingCommaOrSemicolonEnter = null;
		private Action<char> onMissingCommaOrSemicolonExit = null;
		private Action<char> onAccept = null;
		private Action<char> onDecline = null;
		private Action<char> onEnd = null;

		public readonly ParseSingleQuotes ParseSingleQuotesMachine = new ParseSingleQuotes();
		public readonly ParseDoubleQuotes ParseDoubleQuotesMachine = new ParseDoubleQuotes();

		public bool? Input(Queue<char> data)
		{
			if (reset)
				state = null;
			bool? result = null;
			if (data == null)
				return null;
			bool? nestResult;

Reset:
			reset = false;
			switch (state)
			{
				case null:
					if (data.Count > 0)
					{
						state = States.PreStateName;
						goto ResumePreStateName;
					}
					else
						goto End;
				case States.PreStateName:
					goto ResumePreStateName;
				case States.StateName:
					goto ResumeStateName;
				case States.PostStateName:
					goto ResumePostStateName;
				case States.Separator:
					goto ResumeSeparator;
				case States.CommandOrNest:
					goto ResumeCommandOrNest;
				case States.PostCommandOrNest:
					goto ResumePostCommandOrNest;
				case States.PostNestedMachine:
					goto ResumePostNestedMachine;
				case States.NestedMachineAccept:
					goto ResumeNestedMachineAccept;
				case States.PostNestedMachineAccept:
					goto ResumePostNestedMachineAccept;
				case States.PreNestedMachineDecline:
					goto ResumePreNestedMachineDecline;
				case States.NestedMachineDecline:
					goto ResumeNestedMachineDecline;
				case States.PostNestedMachineDecline:
					goto ResumePostNestedMachineDecline;
				case States.PreCommand:
					goto ResumePreCommand;
				case States.ParseSingleQuotes:
					goto ResumeParseSingleQuotes;
				case States.ParseDoubleQuotes:
					goto ResumeParseDoubleQuotes;
				case States.Command:
					goto ResumeCommand;
				case States.PostCommand:
					goto ResumePostCommand;
				case States.PreNextState:
					goto ResumePreNextState;
				case States.NextState:
					goto ResumeNextState;
				case States.PostNextState:
					goto ResumePostNextState;
				case States.IllegalStateNameChar:
					goto ResumeIllegalStateNameChar;
				case States.IllegalCommandChar:
					goto ResumeIllegalCommandChar;
				case States.IllegalNextStateChar:
					goto ResumeIllegalNextStateChar;
				case States.MissingMainColon:
					goto ResumeMissingMainColon;
				case States.MissingEqualsOrTernary:
					goto ResumeMissingEqualsOrTernary;
				case States.MissingNestColon:
					goto ResumeMissingNestColon;
				case States.MissingNestSemicolon:
					goto ResumeMissingNestSemicolon;
				case States.MissingCommaOrSemicolon:
					goto ResumeMissingCommaOrSemicolon;
			}


EnterPreStateName:
			state = States.PreStateName;
			if (onPreStateNameEnter != null)
				onPreStateNameEnter(currentCommand);

PreStateName:
			if (onPreStateNameState != null)
				onPreStateNameState(currentCommand);
ResumePreStateName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreStateName;
				case '\t':
					goto PreStateName;
				case '\n':
					goto PreStateName;
				case '\r':
					goto PreStateName;
				case '}':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto Accept;
				case 'a':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'b':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'c':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'd':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'e':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'f':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'g':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'h':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'i':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'j':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'k':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'l':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'm':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'n':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'o':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'p':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'q':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'r':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 's':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 't':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'u':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'v':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'w':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'x':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'y':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'z':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'A':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'B':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'C':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'D':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'E':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'F':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'G':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'H':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'I':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'J':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'K':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'L':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'M':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'N':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'O':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'P':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'Q':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'R':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'S':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'T':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'U':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'V':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'W':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'X':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'Y':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case 'Z':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '0':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '1':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '2':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '3':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '4':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '5':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '6':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '7':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '8':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '9':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '_':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				case '.':
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterStateName;
				default:
					if (onPreStateNameExit != null)
						onPreStateNameExit(currentCommand);
					goto EnterIllegalStateNameChar;
			}

EnterStateName:
			state = States.StateName;
			if (onStateNameEnter != null)
				onStateNameEnter(currentCommand);

StateName:
			if (onStateNameState != null)
				onStateNameState(currentCommand);
ResumeStateName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterPostStateName;
				case '\t':
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterPostStateName;
				case '\n':
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterPostStateName;
				case '\r':
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterPostStateName;
				case ':':
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterSeparator;
				case 'a':
					goto StateName;
				case 'b':
					goto StateName;
				case 'c':
					goto StateName;
				case 'd':
					goto StateName;
				case 'e':
					goto StateName;
				case 'f':
					goto StateName;
				case 'g':
					goto StateName;
				case 'h':
					goto StateName;
				case 'i':
					goto StateName;
				case 'j':
					goto StateName;
				case 'k':
					goto StateName;
				case 'l':
					goto StateName;
				case 'm':
					goto StateName;
				case 'n':
					goto StateName;
				case 'o':
					goto StateName;
				case 'p':
					goto StateName;
				case 'q':
					goto StateName;
				case 'r':
					goto StateName;
				case 's':
					goto StateName;
				case 't':
					goto StateName;
				case 'u':
					goto StateName;
				case 'v':
					goto StateName;
				case 'w':
					goto StateName;
				case 'x':
					goto StateName;
				case 'y':
					goto StateName;
				case 'z':
					goto StateName;
				case 'A':
					goto StateName;
				case 'B':
					goto StateName;
				case 'C':
					goto StateName;
				case 'D':
					goto StateName;
				case 'E':
					goto StateName;
				case 'F':
					goto StateName;
				case 'G':
					goto StateName;
				case 'H':
					goto StateName;
				case 'I':
					goto StateName;
				case 'J':
					goto StateName;
				case 'K':
					goto StateName;
				case 'L':
					goto StateName;
				case 'M':
					goto StateName;
				case 'N':
					goto StateName;
				case 'O':
					goto StateName;
				case 'P':
					goto StateName;
				case 'Q':
					goto StateName;
				case 'R':
					goto StateName;
				case 'S':
					goto StateName;
				case 'T':
					goto StateName;
				case 'U':
					goto StateName;
				case 'V':
					goto StateName;
				case 'W':
					goto StateName;
				case 'X':
					goto StateName;
				case 'Y':
					goto StateName;
				case 'Z':
					goto StateName;
				case '0':
					goto StateName;
				case '1':
					goto StateName;
				case '2':
					goto StateName;
				case '3':
					goto StateName;
				case '4':
					goto StateName;
				case '5':
					goto StateName;
				case '6':
					goto StateName;
				case '7':
					goto StateName;
				case '8':
					goto StateName;
				case '9':
					goto StateName;
				case '_':
					goto StateName;
				case '.':
					goto StateName;
				default:
					if (onStateNameExit != null)
						onStateNameExit(currentCommand);
					goto EnterIllegalStateNameChar;
			}

EnterPostStateName:
			state = States.PostStateName;
			if (onPostStateNameEnter != null)
				onPostStateNameEnter(currentCommand);

PostStateName:
			if (onPostStateNameState != null)
				onPostStateNameState(currentCommand);
ResumePostStateName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostStateName;
				case '\t':
					goto PostStateName;
				case '\n':
					goto PostStateName;
				case '\r':
					goto PostStateName;
				case ':':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterSeparator;
				case 'a':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'b':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'c':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'd':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'e':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'f':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'g':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'h':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'i':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'j':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'k':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'l':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'm':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'n':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'o':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'p':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'q':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'r':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 's':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 't':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'u':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'v':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'w':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'x':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'y':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'z':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'A':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'B':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'C':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'D':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'E':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'F':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'G':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'H':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'I':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'J':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'K':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'L':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'M':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'N':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'O':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'P':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'Q':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'R':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'S':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'T':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'U':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'V':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'W':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'X':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'Y':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case 'Z':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '0':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '1':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '2':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '3':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '4':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '5':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '6':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '7':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '8':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '9':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '_':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				case '.':
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterMissingMainColon;
				default:
					if (onPostStateNameExit != null)
						onPostStateNameExit(currentCommand);
					goto EnterIllegalStateNameChar;
			}

EnterSeparator:
			state = States.Separator;
			if (onSeparatorEnter != null)
				onSeparatorEnter(currentCommand);

Separator:
			if (onSeparatorState != null)
				onSeparatorState(currentCommand);
ResumeSeparator:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto Separator;
				case '\t':
					goto Separator;
				case '\n':
					goto Separator;
				case '\r':
					goto Separator;
				case '\'':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'a':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'b':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'c':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'd':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'e':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'f':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'g':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'h':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'i':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'j':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'k':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'l':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'm':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'n':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'o':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'p':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'q':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'r':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 's':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 't':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'u':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'v':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'w':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'x':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'y':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'z':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'A':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'B':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'C':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'D':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'E':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'F':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'G':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'H':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'I':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'J':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'K':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'L':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'M':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'N':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'O':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'P':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'Q':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'R':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'S':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'T':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'U':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'V':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'W':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'X':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'Y':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case 'Z':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '0':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '1':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '2':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '3':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '4':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '5':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '6':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '7':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '8':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '9':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '_':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				case '.':
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterCommandOrNest;
				default:
					if (onSeparatorExit != null)
						onSeparatorExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterCommandOrNest:
			state = States.CommandOrNest;
			if (onCommandOrNestEnter != null)
				onCommandOrNestEnter(currentCommand);

CommandOrNest:
			if (onCommandOrNestState != null)
				onCommandOrNestState(currentCommand);
ResumeCommandOrNest:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPostCommandOrNest;
				case '\t':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPostCommandOrNest;
				case '\n':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPostCommandOrNest;
				case '\r':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPostCommandOrNest;
				case '=':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPreNextState;
				case '?':
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterPostNestedMachine;
				case 'a':
					goto CommandOrNest;
				case 'b':
					goto CommandOrNest;
				case 'c':
					goto CommandOrNest;
				case 'd':
					goto CommandOrNest;
				case 'e':
					goto CommandOrNest;
				case 'f':
					goto CommandOrNest;
				case 'g':
					goto CommandOrNest;
				case 'h':
					goto CommandOrNest;
				case 'i':
					goto CommandOrNest;
				case 'j':
					goto CommandOrNest;
				case 'k':
					goto CommandOrNest;
				case 'l':
					goto CommandOrNest;
				case 'm':
					goto CommandOrNest;
				case 'n':
					goto CommandOrNest;
				case 'o':
					goto CommandOrNest;
				case 'p':
					goto CommandOrNest;
				case 'q':
					goto CommandOrNest;
				case 'r':
					goto CommandOrNest;
				case 's':
					goto CommandOrNest;
				case 't':
					goto CommandOrNest;
				case 'u':
					goto CommandOrNest;
				case 'v':
					goto CommandOrNest;
				case 'w':
					goto CommandOrNest;
				case 'x':
					goto CommandOrNest;
				case 'y':
					goto CommandOrNest;
				case 'z':
					goto CommandOrNest;
				case 'A':
					goto CommandOrNest;
				case 'B':
					goto CommandOrNest;
				case 'C':
					goto CommandOrNest;
				case 'D':
					goto CommandOrNest;
				case 'E':
					goto CommandOrNest;
				case 'F':
					goto CommandOrNest;
				case 'G':
					goto CommandOrNest;
				case 'H':
					goto CommandOrNest;
				case 'I':
					goto CommandOrNest;
				case 'J':
					goto CommandOrNest;
				case 'K':
					goto CommandOrNest;
				case 'L':
					goto CommandOrNest;
				case 'M':
					goto CommandOrNest;
				case 'N':
					goto CommandOrNest;
				case 'O':
					goto CommandOrNest;
				case 'P':
					goto CommandOrNest;
				case 'Q':
					goto CommandOrNest;
				case 'R':
					goto CommandOrNest;
				case 'S':
					goto CommandOrNest;
				case 'T':
					goto CommandOrNest;
				case 'U':
					goto CommandOrNest;
				case 'V':
					goto CommandOrNest;
				case 'W':
					goto CommandOrNest;
				case 'X':
					goto CommandOrNest;
				case 'Y':
					goto CommandOrNest;
				case 'Z':
					goto CommandOrNest;
				case '0':
					goto CommandOrNest;
				case '1':
					goto CommandOrNest;
				case '2':
					goto CommandOrNest;
				case '3':
					goto CommandOrNest;
				case '4':
					goto CommandOrNest;
				case '5':
					goto CommandOrNest;
				case '6':
					goto CommandOrNest;
				case '7':
					goto CommandOrNest;
				case '8':
					goto CommandOrNest;
				case '9':
					goto CommandOrNest;
				case '_':
					goto CommandOrNest;
				case '.':
					goto CommandOrNest;
				default:
					if (onCommandOrNestExit != null)
						onCommandOrNestExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterPostCommandOrNest:
			state = States.PostCommandOrNest;
			if (onPostCommandOrNestEnter != null)
				onPostCommandOrNestEnter(currentCommand);

PostCommandOrNest:
			if (onPostCommandOrNestState != null)
				onPostCommandOrNestState(currentCommand);
ResumePostCommandOrNest:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostCommandOrNest;
				case '\t':
					goto PostCommandOrNest;
				case '\n':
					goto PostCommandOrNest;
				case '\r':
					goto PostCommandOrNest;
				case '=':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterPreNextState;
				case '?':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterPostNestedMachine;
				case 'a':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'b':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'c':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'd':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'e':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'f':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'g':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'h':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'i':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'j':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'k':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'l':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'm':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'n':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'o':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'p':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'q':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'r':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 's':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 't':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'u':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'v':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'w':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'x':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'y':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'z':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'A':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'B':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'C':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'D':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'E':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'F':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'G':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'H':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'I':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'J':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'K':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'L':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'M':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'N':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'O':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'P':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Q':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'R':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'S':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'T':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'U':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'V':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'W':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'X':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Y':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Z':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '0':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '1':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '2':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '3':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '4':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '5':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '6':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '7':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '8':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '9':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '_':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '.':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '\'':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '"':
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				default:
					if (onPostCommandOrNestExit != null)
						onPostCommandOrNestExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterPostNestedMachine:
			state = States.PostNestedMachine;
			if (onPostNestedMachineEnter != null)
				onPostNestedMachineEnter(currentCommand);

PostNestedMachine:
			if (onPostNestedMachineState != null)
				onPostNestedMachineState(currentCommand);
ResumePostNestedMachine:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostNestedMachine;
				case '\t':
					goto PostNestedMachine;
				case '\n':
					goto PostNestedMachine;
				case '\r':
					goto PostNestedMachine;
				case 'a':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'b':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'c':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'd':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'e':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'f':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'g':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'h':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'i':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'j':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'k':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'l':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'm':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'n':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'o':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'p':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'q':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'r':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 's':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 't':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'u':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'v':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'w':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'x':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'y':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'z':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'A':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'B':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'C':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'D':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'E':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'F':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'G':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'H':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'I':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'J':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'K':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'L':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'M':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'N':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'O':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'P':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'Q':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'R':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'S':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'T':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'U':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'V':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'W':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'X':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'Y':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case 'Z':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '0':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '1':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '2':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '3':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '4':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '5':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '6':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '7':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '8':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '9':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '_':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				case '.':
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterNestedMachineAccept;
				default:
					if (onPostNestedMachineExit != null)
						onPostNestedMachineExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterNestedMachineAccept:
			state = States.NestedMachineAccept;
			if (onNestedMachineAcceptEnter != null)
				onNestedMachineAcceptEnter(currentCommand);

NestedMachineAccept:
			if (onNestedMachineAcceptState != null)
				onNestedMachineAcceptState(currentCommand);
ResumeNestedMachineAccept:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterPostNestedMachineAccept;
				case '\t':
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterPostNestedMachineAccept;
				case '\n':
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterPostNestedMachineAccept;
				case '\r':
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterPostNestedMachineAccept;
				case ':':
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterPreNestedMachineDecline;
				case 'a':
					goto NestedMachineAccept;
				case 'b':
					goto NestedMachineAccept;
				case 'c':
					goto NestedMachineAccept;
				case 'd':
					goto NestedMachineAccept;
				case 'e':
					goto NestedMachineAccept;
				case 'f':
					goto NestedMachineAccept;
				case 'g':
					goto NestedMachineAccept;
				case 'h':
					goto NestedMachineAccept;
				case 'i':
					goto NestedMachineAccept;
				case 'j':
					goto NestedMachineAccept;
				case 'k':
					goto NestedMachineAccept;
				case 'l':
					goto NestedMachineAccept;
				case 'm':
					goto NestedMachineAccept;
				case 'n':
					goto NestedMachineAccept;
				case 'o':
					goto NestedMachineAccept;
				case 'p':
					goto NestedMachineAccept;
				case 'q':
					goto NestedMachineAccept;
				case 'r':
					goto NestedMachineAccept;
				case 's':
					goto NestedMachineAccept;
				case 't':
					goto NestedMachineAccept;
				case 'u':
					goto NestedMachineAccept;
				case 'v':
					goto NestedMachineAccept;
				case 'w':
					goto NestedMachineAccept;
				case 'x':
					goto NestedMachineAccept;
				case 'y':
					goto NestedMachineAccept;
				case 'z':
					goto NestedMachineAccept;
				case 'A':
					goto NestedMachineAccept;
				case 'B':
					goto NestedMachineAccept;
				case 'C':
					goto NestedMachineAccept;
				case 'D':
					goto NestedMachineAccept;
				case 'E':
					goto NestedMachineAccept;
				case 'F':
					goto NestedMachineAccept;
				case 'G':
					goto NestedMachineAccept;
				case 'H':
					goto NestedMachineAccept;
				case 'I':
					goto NestedMachineAccept;
				case 'J':
					goto NestedMachineAccept;
				case 'K':
					goto NestedMachineAccept;
				case 'L':
					goto NestedMachineAccept;
				case 'M':
					goto NestedMachineAccept;
				case 'N':
					goto NestedMachineAccept;
				case 'O':
					goto NestedMachineAccept;
				case 'P':
					goto NestedMachineAccept;
				case 'Q':
					goto NestedMachineAccept;
				case 'R':
					goto NestedMachineAccept;
				case 'S':
					goto NestedMachineAccept;
				case 'T':
					goto NestedMachineAccept;
				case 'U':
					goto NestedMachineAccept;
				case 'V':
					goto NestedMachineAccept;
				case 'W':
					goto NestedMachineAccept;
				case 'X':
					goto NestedMachineAccept;
				case 'Y':
					goto NestedMachineAccept;
				case 'Z':
					goto NestedMachineAccept;
				case '0':
					goto NestedMachineAccept;
				case '1':
					goto NestedMachineAccept;
				case '2':
					goto NestedMachineAccept;
				case '3':
					goto NestedMachineAccept;
				case '4':
					goto NestedMachineAccept;
				case '5':
					goto NestedMachineAccept;
				case '6':
					goto NestedMachineAccept;
				case '7':
					goto NestedMachineAccept;
				case '8':
					goto NestedMachineAccept;
				case '9':
					goto NestedMachineAccept;
				case '_':
					goto NestedMachineAccept;
				case '.':
					goto NestedMachineAccept;
				default:
					if (onNestedMachineAcceptExit != null)
						onNestedMachineAcceptExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterPostNestedMachineAccept:
			state = States.PostNestedMachineAccept;
			if (onPostNestedMachineAcceptEnter != null)
				onPostNestedMachineAcceptEnter(currentCommand);

PostNestedMachineAccept:
			if (onPostNestedMachineAcceptState != null)
				onPostNestedMachineAcceptState(currentCommand);
ResumePostNestedMachineAccept:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostNestedMachineAccept;
				case '\t':
					goto PostNestedMachineAccept;
				case '\n':
					goto PostNestedMachineAccept;
				case '\r':
					goto PostNestedMachineAccept;
				case ':':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterPreNestedMachineDecline;
				case 'a':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'b':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'c':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'd':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'e':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'f':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'g':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'h':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'i':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'j':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'k':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'l':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'm':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'n':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'o':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'p':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'q':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'r':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 's':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 't':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'u':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'v':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'w':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'x':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'y':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'z':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'A':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'B':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'C':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'D':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'E':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'F':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'G':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'H':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'I':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'J':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'K':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'L':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'M':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'N':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'O':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'P':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'Q':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'R':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'S':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'T':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'U':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'V':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'W':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'X':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'Y':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case 'Z':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '0':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '1':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '2':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '3':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '4':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '5':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '6':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '7':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '8':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '9':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '_':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				case '.':
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterMissingNestColon;
				default:
					if (onPostNestedMachineAcceptExit != null)
						onPostNestedMachineAcceptExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterPreNestedMachineDecline:
			state = States.PreNestedMachineDecline;
			if (onPreNestedMachineDeclineEnter != null)
				onPreNestedMachineDeclineEnter(currentCommand);

PreNestedMachineDecline:
			if (onPreNestedMachineDeclineState != null)
				onPreNestedMachineDeclineState(currentCommand);
ResumePreNestedMachineDecline:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreNestedMachineDecline;
				case '\t':
					goto PreNestedMachineDecline;
				case '\n':
					goto PreNestedMachineDecline;
				case '\r':
					goto PreNestedMachineDecline;
				case 'a':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'b':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'c':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'd':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'e':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'f':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'g':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'h':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'i':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'j':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'k':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'l':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'm':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'n':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'o':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'p':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'q':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'r':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 's':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 't':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'u':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'v':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'w':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'x':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'y':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'z':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'A':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'B':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'C':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'D':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'E':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'F':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'G':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'H':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'I':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'J':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'K':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'L':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'M':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'N':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'O':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'P':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'Q':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'R':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'S':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'T':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'U':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'V':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'W':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'X':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'Y':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case 'Z':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '0':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '1':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '2':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '3':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '4':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '5':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '6':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '7':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '8':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '9':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '_':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				case '.':
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterNestedMachineDecline;
				default:
					if (onPreNestedMachineDeclineExit != null)
						onPreNestedMachineDeclineExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterNestedMachineDecline:
			state = States.NestedMachineDecline;
			if (onNestedMachineDeclineEnter != null)
				onNestedMachineDeclineEnter(currentCommand);

NestedMachineDecline:
			if (onNestedMachineDeclineState != null)
				onNestedMachineDeclineState(currentCommand);
ResumeNestedMachineDecline:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterPostNestedMachineDecline;
				case '\t':
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterPostNestedMachineDecline;
				case '\n':
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterPostNestedMachineDecline;
				case '\r':
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterPostNestedMachineDecline;
				case ';':
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterPreStateName;
				case 'a':
					goto NestedMachineDecline;
				case 'b':
					goto NestedMachineDecline;
				case 'c':
					goto NestedMachineDecline;
				case 'd':
					goto NestedMachineDecline;
				case 'e':
					goto NestedMachineDecline;
				case 'f':
					goto NestedMachineDecline;
				case 'g':
					goto NestedMachineDecline;
				case 'h':
					goto NestedMachineDecline;
				case 'i':
					goto NestedMachineDecline;
				case 'j':
					goto NestedMachineDecline;
				case 'k':
					goto NestedMachineDecline;
				case 'l':
					goto NestedMachineDecline;
				case 'm':
					goto NestedMachineDecline;
				case 'n':
					goto NestedMachineDecline;
				case 'o':
					goto NestedMachineDecline;
				case 'p':
					goto NestedMachineDecline;
				case 'q':
					goto NestedMachineDecline;
				case 'r':
					goto NestedMachineDecline;
				case 's':
					goto NestedMachineDecline;
				case 't':
					goto NestedMachineDecline;
				case 'u':
					goto NestedMachineDecline;
				case 'v':
					goto NestedMachineDecline;
				case 'w':
					goto NestedMachineDecline;
				case 'x':
					goto NestedMachineDecline;
				case 'y':
					goto NestedMachineDecline;
				case 'z':
					goto NestedMachineDecline;
				case 'A':
					goto NestedMachineDecline;
				case 'B':
					goto NestedMachineDecline;
				case 'C':
					goto NestedMachineDecline;
				case 'D':
					goto NestedMachineDecline;
				case 'E':
					goto NestedMachineDecline;
				case 'F':
					goto NestedMachineDecline;
				case 'G':
					goto NestedMachineDecline;
				case 'H':
					goto NestedMachineDecline;
				case 'I':
					goto NestedMachineDecline;
				case 'J':
					goto NestedMachineDecline;
				case 'K':
					goto NestedMachineDecline;
				case 'L':
					goto NestedMachineDecline;
				case 'M':
					goto NestedMachineDecline;
				case 'N':
					goto NestedMachineDecline;
				case 'O':
					goto NestedMachineDecline;
				case 'P':
					goto NestedMachineDecline;
				case 'Q':
					goto NestedMachineDecline;
				case 'R':
					goto NestedMachineDecline;
				case 'S':
					goto NestedMachineDecline;
				case 'T':
					goto NestedMachineDecline;
				case 'U':
					goto NestedMachineDecline;
				case 'V':
					goto NestedMachineDecline;
				case 'W':
					goto NestedMachineDecline;
				case 'X':
					goto NestedMachineDecline;
				case 'Y':
					goto NestedMachineDecline;
				case 'Z':
					goto NestedMachineDecline;
				case '0':
					goto NestedMachineDecline;
				case '1':
					goto NestedMachineDecline;
				case '2':
					goto NestedMachineDecline;
				case '3':
					goto NestedMachineDecline;
				case '4':
					goto NestedMachineDecline;
				case '5':
					goto NestedMachineDecline;
				case '6':
					goto NestedMachineDecline;
				case '7':
					goto NestedMachineDecline;
				case '8':
					goto NestedMachineDecline;
				case '9':
					goto NestedMachineDecline;
				case '_':
					goto NestedMachineDecline;
				case '.':
					goto NestedMachineDecline;
				default:
					if (onNestedMachineDeclineExit != null)
						onNestedMachineDeclineExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterPostNestedMachineDecline:
			state = States.PostNestedMachineDecline;
			if (onPostNestedMachineDeclineEnter != null)
				onPostNestedMachineDeclineEnter(currentCommand);

PostNestedMachineDecline:
			if (onPostNestedMachineDeclineState != null)
				onPostNestedMachineDeclineState(currentCommand);
ResumePostNestedMachineDecline:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostNestedMachineDecline;
				case '\t':
					goto PostNestedMachineDecline;
				case '\n':
					goto PostNestedMachineDecline;
				case '\r':
					goto PostNestedMachineDecline;
				case ';':
					if (onPostNestedMachineDeclineExit != null)
						onPostNestedMachineDeclineExit(currentCommand);
					goto EnterPreStateName;
				default:
					if (onPostNestedMachineDeclineExit != null)
						onPostNestedMachineDeclineExit(currentCommand);
					goto EnterMissingNestSemicolon;
			}

EnterPreCommand:
			state = States.PreCommand;
			if (onPreCommandEnter != null)
				onPreCommandEnter(currentCommand);

PreCommand:
			if (onPreCommandState != null)
				onPreCommandState(currentCommand);
ResumePreCommand:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreCommand;
				case '\t':
					goto PreCommand;
				case '\n':
					goto PreCommand;
				case '\r':
					goto PreCommand;
				case '\'':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'a':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'b':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'c':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'd':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'e':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'f':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'g':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'h':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'i':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'j':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'k':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'l':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'm':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'n':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'o':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'p':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'q':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'r':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 's':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 't':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'u':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'v':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'w':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'x':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'y':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'z':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'A':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'B':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'C':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'D':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'E':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'F':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'G':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'H':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'I':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'J':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'K':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'L':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'M':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'N':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'O':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'P':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'Q':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'R':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'S':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'T':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'U':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'V':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'W':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'X':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'Y':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case 'Z':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '0':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '1':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '2':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '3':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '4':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '5':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '6':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '7':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '8':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '9':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '_':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				case '.':
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterCommand;
				default:
					if (onPreCommandExit != null)
						onPreCommandExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterParseSingleQuotes:
			state = States.ParseSingleQuotes;
			if (onParseSingleQuotesEnter != null)
				onParseSingleQuotesEnter(currentCommand);

			if (onParseSingleQuotesState != null)
				onParseSingleQuotesState(currentCommand);
ResumeParseSingleQuotes:
			nestResult = ParseSingleQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onParseSingleQuotesExit != null)
						onParseSingleQuotesExit(ParseSingleQuotesMachine.CurrentCommand);
					goto EnterPostCommand;
				case false:
			if (onParseSingleQuotesExit != null)
						onParseSingleQuotesExit(ParseSingleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterParseDoubleQuotes:
			state = States.ParseDoubleQuotes;
			if (onParseDoubleQuotesEnter != null)
				onParseDoubleQuotesEnter(currentCommand);

			if (onParseDoubleQuotesState != null)
				onParseDoubleQuotesState(currentCommand);
ResumeParseDoubleQuotes:
			nestResult = ParseDoubleQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onParseDoubleQuotesExit != null)
						onParseDoubleQuotesExit(ParseDoubleQuotesMachine.CurrentCommand);
					goto EnterPostCommand;
				case false:
			if (onParseDoubleQuotesExit != null)
						onParseDoubleQuotesExit(ParseDoubleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterCommand:
			state = States.Command;
			if (onCommandEnter != null)
				onCommandEnter(currentCommand);

Command:
			if (onCommandState != null)
				onCommandState(currentCommand);
ResumeCommand:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterPostCommand;
				case '\t':
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterPostCommand;
				case '\n':
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterPostCommand;
				case '\r':
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterPostCommand;
				case '=':
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterPreNextState;
				case 'a':
					goto Command;
				case 'b':
					goto Command;
				case 'c':
					goto Command;
				case 'd':
					goto Command;
				case 'e':
					goto Command;
				case 'f':
					goto Command;
				case 'g':
					goto Command;
				case 'h':
					goto Command;
				case 'i':
					goto Command;
				case 'j':
					goto Command;
				case 'k':
					goto Command;
				case 'l':
					goto Command;
				case 'm':
					goto Command;
				case 'n':
					goto Command;
				case 'o':
					goto Command;
				case 'p':
					goto Command;
				case 'q':
					goto Command;
				case 'r':
					goto Command;
				case 's':
					goto Command;
				case 't':
					goto Command;
				case 'u':
					goto Command;
				case 'v':
					goto Command;
				case 'w':
					goto Command;
				case 'x':
					goto Command;
				case 'y':
					goto Command;
				case 'z':
					goto Command;
				case 'A':
					goto Command;
				case 'B':
					goto Command;
				case 'C':
					goto Command;
				case 'D':
					goto Command;
				case 'E':
					goto Command;
				case 'F':
					goto Command;
				case 'G':
					goto Command;
				case 'H':
					goto Command;
				case 'I':
					goto Command;
				case 'J':
					goto Command;
				case 'K':
					goto Command;
				case 'L':
					goto Command;
				case 'M':
					goto Command;
				case 'N':
					goto Command;
				case 'O':
					goto Command;
				case 'P':
					goto Command;
				case 'Q':
					goto Command;
				case 'R':
					goto Command;
				case 'S':
					goto Command;
				case 'T':
					goto Command;
				case 'U':
					goto Command;
				case 'V':
					goto Command;
				case 'W':
					goto Command;
				case 'X':
					goto Command;
				case 'Y':
					goto Command;
				case 'Z':
					goto Command;
				case '0':
					goto Command;
				case '1':
					goto Command;
				case '2':
					goto Command;
				case '3':
					goto Command;
				case '4':
					goto Command;
				case '5':
					goto Command;
				case '6':
					goto Command;
				case '7':
					goto Command;
				case '8':
					goto Command;
				case '9':
					goto Command;
				case '_':
					goto Command;
				case '.':
					goto Command;
				default:
					if (onCommandExit != null)
						onCommandExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterPostCommand:
			state = States.PostCommand;
			if (onPostCommandEnter != null)
				onPostCommandEnter(currentCommand);

PostCommand:
			if (onPostCommandState != null)
				onPostCommandState(currentCommand);
ResumePostCommand:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostCommand;
				case '\t':
					goto PostCommand;
				case '\n':
					goto PostCommand;
				case '\r':
					goto PostCommand;
				case '=':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterPreNextState;
				case 'a':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'b':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'c':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'd':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'e':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'f':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'g':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'h':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'i':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'j':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'k':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'l':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'm':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'n':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'o':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'p':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'q':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'r':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 's':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 't':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'u':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'v':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'w':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'x':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'y':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'z':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'A':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'B':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'C':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'D':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'E':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'F':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'G':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'H':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'I':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'J':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'K':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'L':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'M':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'N':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'O':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'P':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Q':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'R':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'S':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'T':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'U':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'V':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'W':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'X':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Y':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case 'Z':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '0':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '1':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '2':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '3':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '4':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '5':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '6':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '7':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '8':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '9':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '_':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				case '.':
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterMissingEqualsOrTernary;
				default:
					if (onPostCommandExit != null)
						onPostCommandExit(currentCommand);
					goto EnterIllegalCommandChar;
			}

EnterPreNextState:
			state = States.PreNextState;
			if (onPreNextStateEnter != null)
				onPreNextStateEnter(currentCommand);

PreNextState:
			if (onPreNextStateState != null)
				onPreNextStateState(currentCommand);
ResumePreNextState:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreNextState;
				case '\t':
					goto PreNextState;
				case '\n':
					goto PreNextState;
				case '\r':
					goto PreNextState;
				case 'a':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'b':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'c':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'd':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'e':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'f':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'g':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'h':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'i':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'j':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'k':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'l':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'm':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'n':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'o':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'p':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'q':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'r':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 's':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 't':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'u':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'v':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'w':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'x':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'y':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'z':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'A':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'B':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'C':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'D':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'E':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'F':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'G':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'H':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'I':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'J':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'K':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'L':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'M':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'N':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'O':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'P':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'Q':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'R':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'S':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'T':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'U':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'V':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'W':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'X':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'Y':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case 'Z':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '0':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '1':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '2':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '3':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '4':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '5':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '6':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '7':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '8':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '9':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '_':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				case '.':
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterNextState;
				default:
					if (onPreNextStateExit != null)
						onPreNextStateExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterNextState:
			state = States.NextState;
			if (onNextStateEnter != null)
				onNextStateEnter(currentCommand);

NextState:
			if (onNextStateState != null)
				onNextStateState(currentCommand);
ResumeNextState:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPostNextState;
				case '\t':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPostNextState;
				case '\n':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPostNextState;
				case '\r':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPostNextState;
				case ',':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPreCommand;
				case ';':
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterPreStateName;
				case 'a':
					goto NextState;
				case 'b':
					goto NextState;
				case 'c':
					goto NextState;
				case 'd':
					goto NextState;
				case 'e':
					goto NextState;
				case 'f':
					goto NextState;
				case 'g':
					goto NextState;
				case 'h':
					goto NextState;
				case 'i':
					goto NextState;
				case 'j':
					goto NextState;
				case 'k':
					goto NextState;
				case 'l':
					goto NextState;
				case 'm':
					goto NextState;
				case 'n':
					goto NextState;
				case 'o':
					goto NextState;
				case 'p':
					goto NextState;
				case 'q':
					goto NextState;
				case 'r':
					goto NextState;
				case 's':
					goto NextState;
				case 't':
					goto NextState;
				case 'u':
					goto NextState;
				case 'v':
					goto NextState;
				case 'w':
					goto NextState;
				case 'x':
					goto NextState;
				case 'y':
					goto NextState;
				case 'z':
					goto NextState;
				case 'A':
					goto NextState;
				case 'B':
					goto NextState;
				case 'C':
					goto NextState;
				case 'D':
					goto NextState;
				case 'E':
					goto NextState;
				case 'F':
					goto NextState;
				case 'G':
					goto NextState;
				case 'H':
					goto NextState;
				case 'I':
					goto NextState;
				case 'J':
					goto NextState;
				case 'K':
					goto NextState;
				case 'L':
					goto NextState;
				case 'M':
					goto NextState;
				case 'N':
					goto NextState;
				case 'O':
					goto NextState;
				case 'P':
					goto NextState;
				case 'Q':
					goto NextState;
				case 'R':
					goto NextState;
				case 'S':
					goto NextState;
				case 'T':
					goto NextState;
				case 'U':
					goto NextState;
				case 'V':
					goto NextState;
				case 'W':
					goto NextState;
				case 'X':
					goto NextState;
				case 'Y':
					goto NextState;
				case 'Z':
					goto NextState;
				case '0':
					goto NextState;
				case '1':
					goto NextState;
				case '2':
					goto NextState;
				case '3':
					goto NextState;
				case '4':
					goto NextState;
				case '5':
					goto NextState;
				case '6':
					goto NextState;
				case '7':
					goto NextState;
				case '8':
					goto NextState;
				case '9':
					goto NextState;
				case '_':
					goto NextState;
				case '.':
					goto NextState;
				default:
					if (onNextStateExit != null)
						onNextStateExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterPostNextState:
			state = States.PostNextState;
			if (onPostNextStateEnter != null)
				onPostNextStateEnter(currentCommand);

PostNextState:
			if (onPostNextStateState != null)
				onPostNextStateState(currentCommand);
ResumePostNextState:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostNextState;
				case '\t':
					goto PostNextState;
				case '\n':
					goto PostNextState;
				case '\r':
					goto PostNextState;
				case ',':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterPreCommand;
				case ';':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterPreStateName;
				case 'a':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'b':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'c':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'd':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'e':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'f':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'g':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'h':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'i':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'j':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'k':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'l':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'm':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'n':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'o':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'p':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'q':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'r':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 's':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 't':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'u':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'v':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'w':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'x':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'y':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'z':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'A':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'B':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'C':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'D':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'E':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'F':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'G':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'H':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'I':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'J':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'K':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'L':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'M':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'N':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'O':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'P':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'Q':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'R':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'S':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'T':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'U':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'V':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'W':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'X':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'Y':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case 'Z':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '0':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '1':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '2':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '3':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '4':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '5':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '6':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '7':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '8':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '9':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '_':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				case '.':
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterMissingCommaOrSemicolon;
				default:
					if (onPostNextStateExit != null)
						onPostNextStateExit(currentCommand);
					goto EnterIllegalNextStateChar;
			}

EnterIllegalStateNameChar:
			state = States.IllegalStateNameChar;
			if (onIllegalStateNameCharEnter != null)
				onIllegalStateNameCharEnter(currentCommand);

			if (onIllegalStateNameCharState != null)
				onIllegalStateNameCharState(currentCommand);
ResumeIllegalStateNameChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalStateNameCharExit != null)
						onIllegalStateNameCharExit(currentCommand);
					goto Decline;
			}

EnterIllegalCommandChar:
			state = States.IllegalCommandChar;
			if (onIllegalCommandCharEnter != null)
				onIllegalCommandCharEnter(currentCommand);

			if (onIllegalCommandCharState != null)
				onIllegalCommandCharState(currentCommand);
ResumeIllegalCommandChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalCommandCharExit != null)
						onIllegalCommandCharExit(currentCommand);
					goto Decline;
			}

EnterIllegalNextStateChar:
			state = States.IllegalNextStateChar;
			if (onIllegalNextStateCharEnter != null)
				onIllegalNextStateCharEnter(currentCommand);

			if (onIllegalNextStateCharState != null)
				onIllegalNextStateCharState(currentCommand);
ResumeIllegalNextStateChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalNextStateCharExit != null)
						onIllegalNextStateCharExit(currentCommand);
					goto Decline;
			}

EnterMissingMainColon:
			state = States.MissingMainColon;
			if (onMissingMainColonEnter != null)
				onMissingMainColonEnter(currentCommand);

			if (onMissingMainColonState != null)
				onMissingMainColonState(currentCommand);
ResumeMissingMainColon:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingMainColonExit != null)
						onMissingMainColonExit(currentCommand);
					goto Decline;
			}

EnterMissingEqualsOrTernary:
			state = States.MissingEqualsOrTernary;
			if (onMissingEqualsOrTernaryEnter != null)
				onMissingEqualsOrTernaryEnter(currentCommand);

			if (onMissingEqualsOrTernaryState != null)
				onMissingEqualsOrTernaryState(currentCommand);
ResumeMissingEqualsOrTernary:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingEqualsOrTernaryExit != null)
						onMissingEqualsOrTernaryExit(currentCommand);
					goto Decline;
			}

EnterMissingNestColon:
			state = States.MissingNestColon;
			if (onMissingNestColonEnter != null)
				onMissingNestColonEnter(currentCommand);

			if (onMissingNestColonState != null)
				onMissingNestColonState(currentCommand);
ResumeMissingNestColon:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingNestColonExit != null)
						onMissingNestColonExit(currentCommand);
					goto Decline;
			}

EnterMissingNestSemicolon:
			state = States.MissingNestSemicolon;
			if (onMissingNestSemicolonEnter != null)
				onMissingNestSemicolonEnter(currentCommand);

			if (onMissingNestSemicolonState != null)
				onMissingNestSemicolonState(currentCommand);
ResumeMissingNestSemicolon:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingNestSemicolonExit != null)
						onMissingNestSemicolonExit(currentCommand);
					goto Decline;
			}

EnterMissingCommaOrSemicolon:
			state = States.MissingCommaOrSemicolon;
			if (onMissingCommaOrSemicolonEnter != null)
				onMissingCommaOrSemicolonEnter(currentCommand);

			if (onMissingCommaOrSemicolonState != null)
				onMissingCommaOrSemicolonState(currentCommand);
ResumeMissingCommaOrSemicolon:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingCommaOrSemicolonExit != null)
						onMissingCommaOrSemicolonExit(currentCommand);
					goto Decline;
			}

Accept:
			result = true;
			state = null;
			if (onAccept != null)
				onAccept(currentCommand);
			goto End;

Decline:
			result = false;
			state = null;
			if (onDecline != null)
				onDecline(currentCommand);
			goto End;

End:
			if (onEnd != null)
				onEnd(currentCommand);
			if (reset)
			{
				goto Reset;
			}
			return result;
		}

		public void AddOnPreStateName(Action<char> addedFunc)
		{
			onPreStateNameState += addedFunc;
		}

		public void AddOnStateName(Action<char> addedFunc)
		{
			onStateNameState += addedFunc;
		}

		public void AddOnPostStateName(Action<char> addedFunc)
		{
			onPostStateNameState += addedFunc;
		}

		public void AddOnSeparator(Action<char> addedFunc)
		{
			onSeparatorState += addedFunc;
		}

		public void AddOnCommandOrNest(Action<char> addedFunc)
		{
			onCommandOrNestState += addedFunc;
		}

		public void AddOnPostCommandOrNest(Action<char> addedFunc)
		{
			onPostCommandOrNestState += addedFunc;
		}

		public void AddOnPostNestedMachine(Action<char> addedFunc)
		{
			onPostNestedMachineState += addedFunc;
		}

		public void AddOnNestedMachineAccept(Action<char> addedFunc)
		{
			onNestedMachineAcceptState += addedFunc;
		}

		public void AddOnPostNestedMachineAccept(Action<char> addedFunc)
		{
			onPostNestedMachineAcceptState += addedFunc;
		}

		public void AddOnPreNestedMachineDecline(Action<char> addedFunc)
		{
			onPreNestedMachineDeclineState += addedFunc;
		}

		public void AddOnNestedMachineDecline(Action<char> addedFunc)
		{
			onNestedMachineDeclineState += addedFunc;
		}

		public void AddOnPostNestedMachineDecline(Action<char> addedFunc)
		{
			onPostNestedMachineDeclineState += addedFunc;
		}

		public void AddOnPreCommand(Action<char> addedFunc)
		{
			onPreCommandState += addedFunc;
		}

		public void AddOnParseSingleQuotes(Action<char> addedFunc)
		{
			AddOnParseSingleQuotesEnter(addedFunc);
			ParseSingleQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnParseDoubleQuotes(Action<char> addedFunc)
		{
			AddOnParseDoubleQuotesEnter(addedFunc);
			ParseDoubleQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnCommand(Action<char> addedFunc)
		{
			onCommandState += addedFunc;
		}

		public void AddOnPostCommand(Action<char> addedFunc)
		{
			onPostCommandState += addedFunc;
		}

		public void AddOnPreNextState(Action<char> addedFunc)
		{
			onPreNextStateState += addedFunc;
		}

		public void AddOnNextState(Action<char> addedFunc)
		{
			onNextStateState += addedFunc;
		}

		public void AddOnPostNextState(Action<char> addedFunc)
		{
			onPostNextStateState += addedFunc;
		}

		public void AddOnIllegalStateNameChar(Action<char> addedFunc)
		{
			onIllegalStateNameCharState += addedFunc;
		}

		public void AddOnIllegalCommandChar(Action<char> addedFunc)
		{
			onIllegalCommandCharState += addedFunc;
		}

		public void AddOnIllegalNextStateChar(Action<char> addedFunc)
		{
			onIllegalNextStateCharState += addedFunc;
		}

		public void AddOnMissingMainColon(Action<char> addedFunc)
		{
			onMissingMainColonState += addedFunc;
		}

		public void AddOnMissingEqualsOrTernary(Action<char> addedFunc)
		{
			onMissingEqualsOrTernaryState += addedFunc;
		}

		public void AddOnMissingNestColon(Action<char> addedFunc)
		{
			onMissingNestColonState += addedFunc;
		}

		public void AddOnMissingNestSemicolon(Action<char> addedFunc)
		{
			onMissingNestSemicolonState += addedFunc;
		}

		public void AddOnMissingCommaOrSemicolon(Action<char> addedFunc)
		{
			onMissingCommaOrSemicolonState += addedFunc;
		}

		public void AddOnPreStateNameEnter(Action<char> addedFunc)
		{
			onPreStateNameEnter += addedFunc;
		}

		public void AddOnStateNameEnter(Action<char> addedFunc)
		{
			onStateNameEnter += addedFunc;
		}

		public void AddOnPostStateNameEnter(Action<char> addedFunc)
		{
			onPostStateNameEnter += addedFunc;
		}

		public void AddOnSeparatorEnter(Action<char> addedFunc)
		{
			onSeparatorEnter += addedFunc;
		}

		public void AddOnCommandOrNestEnter(Action<char> addedFunc)
		{
			onCommandOrNestEnter += addedFunc;
		}

		public void AddOnPostCommandOrNestEnter(Action<char> addedFunc)
		{
			onPostCommandOrNestEnter += addedFunc;
		}

		public void AddOnPostNestedMachineEnter(Action<char> addedFunc)
		{
			onPostNestedMachineEnter += addedFunc;
		}

		public void AddOnNestedMachineAcceptEnter(Action<char> addedFunc)
		{
			onNestedMachineAcceptEnter += addedFunc;
		}

		public void AddOnPostNestedMachineAcceptEnter(Action<char> addedFunc)
		{
			onPostNestedMachineAcceptEnter += addedFunc;
		}

		public void AddOnPreNestedMachineDeclineEnter(Action<char> addedFunc)
		{
			onPreNestedMachineDeclineEnter += addedFunc;
		}

		public void AddOnNestedMachineDeclineEnter(Action<char> addedFunc)
		{
			onNestedMachineDeclineEnter += addedFunc;
		}

		public void AddOnPostNestedMachineDeclineEnter(Action<char> addedFunc)
		{
			onPostNestedMachineDeclineEnter += addedFunc;
		}

		public void AddOnPreCommandEnter(Action<char> addedFunc)
		{
			onPreCommandEnter += addedFunc;
		}

		public void AddOnParseSingleQuotesEnter(Action<char> addedFunc)
		{
			onParseSingleQuotesEnter += addedFunc;
		}

		public void AddOnParseDoubleQuotesEnter(Action<char> addedFunc)
		{
			onParseDoubleQuotesEnter += addedFunc;
		}

		public void AddOnCommandEnter(Action<char> addedFunc)
		{
			onCommandEnter += addedFunc;
		}

		public void AddOnPostCommandEnter(Action<char> addedFunc)
		{
			onPostCommandEnter += addedFunc;
		}

		public void AddOnPreNextStateEnter(Action<char> addedFunc)
		{
			onPreNextStateEnter += addedFunc;
		}

		public void AddOnNextStateEnter(Action<char> addedFunc)
		{
			onNextStateEnter += addedFunc;
		}

		public void AddOnPostNextStateEnter(Action<char> addedFunc)
		{
			onPostNextStateEnter += addedFunc;
		}

		public void AddOnIllegalStateNameCharEnter(Action<char> addedFunc)
		{
			onIllegalStateNameCharEnter += addedFunc;
		}

		public void AddOnIllegalCommandCharEnter(Action<char> addedFunc)
		{
			onIllegalCommandCharEnter += addedFunc;
		}

		public void AddOnIllegalNextStateCharEnter(Action<char> addedFunc)
		{
			onIllegalNextStateCharEnter += addedFunc;
		}

		public void AddOnMissingMainColonEnter(Action<char> addedFunc)
		{
			onMissingMainColonEnter += addedFunc;
		}

		public void AddOnMissingEqualsOrTernaryEnter(Action<char> addedFunc)
		{
			onMissingEqualsOrTernaryEnter += addedFunc;
		}

		public void AddOnMissingNestColonEnter(Action<char> addedFunc)
		{
			onMissingNestColonEnter += addedFunc;
		}

		public void AddOnMissingNestSemicolonEnter(Action<char> addedFunc)
		{
			onMissingNestSemicolonEnter += addedFunc;
		}

		public void AddOnMissingCommaOrSemicolonEnter(Action<char> addedFunc)
		{
			onMissingCommaOrSemicolonEnter += addedFunc;
		}

		public void AddOnPreStateNameExit(Action<char> addedFunc)
		{
			onPreStateNameExit += addedFunc;
		}

		public void AddOnStateNameExit(Action<char> addedFunc)
		{
			onStateNameExit += addedFunc;
		}

		public void AddOnPostStateNameExit(Action<char> addedFunc)
		{
			onPostStateNameExit += addedFunc;
		}

		public void AddOnSeparatorExit(Action<char> addedFunc)
		{
			onSeparatorExit += addedFunc;
		}

		public void AddOnCommandOrNestExit(Action<char> addedFunc)
		{
			onCommandOrNestExit += addedFunc;
		}

		public void AddOnPostCommandOrNestExit(Action<char> addedFunc)
		{
			onPostCommandOrNestExit += addedFunc;
		}

		public void AddOnPostNestedMachineExit(Action<char> addedFunc)
		{
			onPostNestedMachineExit += addedFunc;
		}

		public void AddOnNestedMachineAcceptExit(Action<char> addedFunc)
		{
			onNestedMachineAcceptExit += addedFunc;
		}

		public void AddOnPostNestedMachineAcceptExit(Action<char> addedFunc)
		{
			onPostNestedMachineAcceptExit += addedFunc;
		}

		public void AddOnPreNestedMachineDeclineExit(Action<char> addedFunc)
		{
			onPreNestedMachineDeclineExit += addedFunc;
		}

		public void AddOnNestedMachineDeclineExit(Action<char> addedFunc)
		{
			onNestedMachineDeclineExit += addedFunc;
		}

		public void AddOnPostNestedMachineDeclineExit(Action<char> addedFunc)
		{
			onPostNestedMachineDeclineExit += addedFunc;
		}

		public void AddOnPreCommandExit(Action<char> addedFunc)
		{
			onPreCommandExit += addedFunc;
		}

		public void AddOnParseSingleQuotesExit(Action<char> addedFunc)
		{
			onParseSingleQuotesExit += addedFunc;
		}

		public void AddOnParseDoubleQuotesExit(Action<char> addedFunc)
		{
			onParseDoubleQuotesExit += addedFunc;
		}

		public void AddOnCommandExit(Action<char> addedFunc)
		{
			onCommandExit += addedFunc;
		}

		public void AddOnPostCommandExit(Action<char> addedFunc)
		{
			onPostCommandExit += addedFunc;
		}

		public void AddOnPreNextStateExit(Action<char> addedFunc)
		{
			onPreNextStateExit += addedFunc;
		}

		public void AddOnNextStateExit(Action<char> addedFunc)
		{
			onNextStateExit += addedFunc;
		}

		public void AddOnPostNextStateExit(Action<char> addedFunc)
		{
			onPostNextStateExit += addedFunc;
		}

		public void AddOnIllegalStateNameCharExit(Action<char> addedFunc)
		{
			onIllegalStateNameCharExit += addedFunc;
		}

		public void AddOnIllegalCommandCharExit(Action<char> addedFunc)
		{
			onIllegalCommandCharExit += addedFunc;
		}

		public void AddOnIllegalNextStateCharExit(Action<char> addedFunc)
		{
			onIllegalNextStateCharExit += addedFunc;
		}

		public void AddOnMissingMainColonExit(Action<char> addedFunc)
		{
			onMissingMainColonExit += addedFunc;
		}

		public void AddOnMissingEqualsOrTernaryExit(Action<char> addedFunc)
		{
			onMissingEqualsOrTernaryExit += addedFunc;
		}

		public void AddOnMissingNestColonExit(Action<char> addedFunc)
		{
			onMissingNestColonExit += addedFunc;
		}

		public void AddOnMissingNestSemicolonExit(Action<char> addedFunc)
		{
			onMissingNestSemicolonExit += addedFunc;
		}

		public void AddOnMissingCommaOrSemicolonExit(Action<char> addedFunc)
		{
			onMissingCommaOrSemicolonExit += addedFunc;
		}

		public void AddOnAccept(Action<char> addedFunc)
		{
			onAccept += addedFunc;
		}

		public void AddOnDecline(Action<char> addedFunc)
		{
			onDecline += addedFunc;
		}

		public void AddOnEnd(Action<char> addedFunc)
		{
			onEnd += addedFunc;
		}

		internal void addOnAllStates( Action<char> addedFunc )
		{
			onPreStateNameState += addedFunc;
			onStateNameState += addedFunc;
			onPostStateNameState += addedFunc;
			onSeparatorState += addedFunc;
			onCommandOrNestState += addedFunc;
			onPostCommandOrNestState += addedFunc;
			onPostNestedMachineState += addedFunc;
			onNestedMachineAcceptState += addedFunc;
			onPostNestedMachineAcceptState += addedFunc;
			onPreNestedMachineDeclineState += addedFunc;
			onNestedMachineDeclineState += addedFunc;
			onPostNestedMachineDeclineState += addedFunc;
			onPreCommandState += addedFunc;
			AddOnParseSingleQuotes(addedFunc);
			AddOnParseDoubleQuotes(addedFunc);
			onCommandState += addedFunc;
			onPostCommandState += addedFunc;
			onPreNextStateState += addedFunc;
			onNextStateState += addedFunc;
			onPostNextStateState += addedFunc;
			onIllegalStateNameCharState += addedFunc;
			onIllegalCommandCharState += addedFunc;
			onIllegalNextStateCharState += addedFunc;
			onMissingMainColonState += addedFunc;
			onMissingEqualsOrTernaryState += addedFunc;
			onMissingNestColonState += addedFunc;
			onMissingNestSemicolonState += addedFunc;
			onMissingCommaOrSemicolonState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
			ParseSingleQuotesMachine.ResetStateOnEnd();
			ParseDoubleQuotesMachine.ResetStateOnEnd();
		}
	}
}
