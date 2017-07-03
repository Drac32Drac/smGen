// ************************ ParseSMFile : char ************************
// 
// 	group whitespace		= { ' ', '\t', '\r', '\n' }
// 	group stateSpecialChars = { '=', ':', '?', ',', ';' }
// 	group alphaNumeric		= { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
// 			'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
// 			'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
// 			'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
// 			'8', '9', '_', '.' }
// 	ParseDeclaration		: ParseSMDeclaration ? EndParseDeclaration : ParseDeclaration;
// 	EndParseDeclaration		: whitespace = EndParseDeclaration,
// 			alphaNumeric = ParseMachineName, default = IllegalDeclarationChar;
// 	ParseMachineName		: whitespace = EndParseMachineName, ':' = ParseInputTypeSeparator,
// 			alphaNumeric = ParseMachineName, default = IllegalDeclarationChar;
// 	EndParseMachineName		: whitespace = EndParseMachineName, ':' = ParseInputTypeSeparator,
// 			default = IllegalDeclarationChar;
// 	ParseInputTypeSeparator	: whitespace = ParseInputTypeSeparator,
// 			 alphaNumeric = ParseInputType, default = IllegalDeclarationChar;
// 	ParseInputType			: whitespace = EndParseInputType, '{' = BeginMachine,
// 			alphaNumeric = ParseInputType, default = IllegalDeclarationChar;
// 	EndParseInputType		: whitespace = EndParseInputType, '{' = BeginMachine,
// 			default = IllegalDeclarationChar;
// 	BeginMachine			: '}' = accept, whitespace = ParseStates,
// 			alphaNumeric = ParseStates, default = IllegalStateIdentifier;
// 	ParseStates				: '{' = NestedBrace, '"' = ParseDoubleQuotes,
// 			'\'' = ParseSingleQuotes, '}' = accept, whitespace = ParseStates,
// 			stateSpecialChars = ParseStates, alphaNumeric = ParseStates,
// 			default = IllegalStateContent;
// 		
// 	ParseSingleQuotes		: ParseSingleQuotes ? ParseStates : decline;
// 	ParseDoubleQuotes		: ParseDoubleQuotes ? ParseStates : decline;
// 	NestedBrace				: '}' = ParseStates, '\'' = NestedBraceSingeQuotes,
// 			'"' = NestedBraceDoubleQuotes, whitespace = NestedBrace,
// 			stateSpecialChars = NestedBrace, alphaNumeric = NestedBrace,
// 			default = IllegalNestedStateContent;
// 		
// 	NestedBraceSingeQuotes	: ParseSingleQuotes ? NestedBrace : decline;
// 	NestedBraceDoubleQuotes : ParseDoubleQuotes ? NestedBrace : decline;
// 		
// 	IllegalDeclarationChar		: default = decline;
// 	IllegalStateIdentifier		: default = decline;
// 	IllegalStateContent			: default = decline;
// 	IllegalNestedStateContent	: default = decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace test
{
	public class ParseSMFile
	{
		public enum States
		{
			ParseDeclaration = 0, 	EndParseDeclaration = 1, 
			ParseMachineName = 2, 	EndParseMachineName = 3, 
			ParseInputTypeSeparator = 4, 	ParseInputType = 5, 
			EndParseInputType = 6, 	BeginMachine = 7, 
			ParseStates = 8, 	ParseSingleQuotes = 9, 
			ParseDoubleQuotes = 10, 	NestedBrace = 11, 
			NestedBraceSingeQuotes = 12, 	NestedBraceDoubleQuotes = 13, 
			IllegalDeclarationChar = 14, 	IllegalStateIdentifier = 15, 
			IllegalStateContent = 16, 	IllegalNestedStateContent = 17, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onParseDeclarationState = null;
		private Action<char> onParseDeclarationEnter = null;
		private Action<char> onParseDeclarationExit = null;
		private Action<char> onEndParseDeclarationState = null;
		private Action<char> onEndParseDeclarationEnter = null;
		private Action<char> onEndParseDeclarationExit = null;
		private Action<char> onParseMachineNameState = null;
		private Action<char> onParseMachineNameEnter = null;
		private Action<char> onParseMachineNameExit = null;
		private Action<char> onEndParseMachineNameState = null;
		private Action<char> onEndParseMachineNameEnter = null;
		private Action<char> onEndParseMachineNameExit = null;
		private Action<char> onParseInputTypeSeparatorState = null;
		private Action<char> onParseInputTypeSeparatorEnter = null;
		private Action<char> onParseInputTypeSeparatorExit = null;
		private Action<char> onParseInputTypeState = null;
		private Action<char> onParseInputTypeEnter = null;
		private Action<char> onParseInputTypeExit = null;
		private Action<char> onEndParseInputTypeState = null;
		private Action<char> onEndParseInputTypeEnter = null;
		private Action<char> onEndParseInputTypeExit = null;
		private Action<char> onBeginMachineState = null;
		private Action<char> onBeginMachineEnter = null;
		private Action<char> onBeginMachineExit = null;
		private Action<char> onParseStatesState = null;
		private Action<char> onParseStatesEnter = null;
		private Action<char> onParseStatesExit = null;
		private Action<char> onParseSingleQuotesState = null;
		private Action<char> onParseSingleQuotesEnter = null;
		private Action<char> onParseSingleQuotesExit = null;
		private Action<char> onParseDoubleQuotesState = null;
		private Action<char> onParseDoubleQuotesEnter = null;
		private Action<char> onParseDoubleQuotesExit = null;
		private Action<char> onNestedBraceState = null;
		private Action<char> onNestedBraceEnter = null;
		private Action<char> onNestedBraceExit = null;
		private Action<char> onNestedBraceSingeQuotesState = null;
		private Action<char> onNestedBraceSingeQuotesEnter = null;
		private Action<char> onNestedBraceSingeQuotesExit = null;
		private Action<char> onNestedBraceDoubleQuotesState = null;
		private Action<char> onNestedBraceDoubleQuotesEnter = null;
		private Action<char> onNestedBraceDoubleQuotesExit = null;
		private Action<char> onIllegalDeclarationCharState = null;
		private Action<char> onIllegalDeclarationCharEnter = null;
		private Action<char> onIllegalDeclarationCharExit = null;
		private Action<char> onIllegalStateIdentifierState = null;
		private Action<char> onIllegalStateIdentifierEnter = null;
		private Action<char> onIllegalStateIdentifierExit = null;
		private Action<char> onIllegalStateContentState = null;
		private Action<char> onIllegalStateContentEnter = null;
		private Action<char> onIllegalStateContentExit = null;
		private Action<char> onIllegalNestedStateContentState = null;
		private Action<char> onIllegalNestedStateContentEnter = null;
		private Action<char> onIllegalNestedStateContentExit = null;
		private Action<char> onAccept = null;
		private Action<char> onDecline = null;
		private Action<char> onEnd = null;

		public readonly ParseSMDeclaration ParseDeclarationMachine = new ParseSMDeclaration();
		public readonly ParseSingleQuotes ParseSingleQuotesMachine = new ParseSingleQuotes();
		public readonly ParseDoubleQuotes ParseDoubleQuotesMachine = new ParseDoubleQuotes();
		public readonly ParseSingleQuotes NestedBraceSingeQuotesMachine = new ParseSingleQuotes();
		public readonly ParseDoubleQuotes NestedBraceDoubleQuotesMachine = new ParseDoubleQuotes();

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
						state = States.ParseDeclaration;
						goto ResumeParseDeclaration;
					}
					else
						goto End;
				case States.ParseDeclaration:
					goto ResumeParseDeclaration;
				case States.EndParseDeclaration:
					goto ResumeEndParseDeclaration;
				case States.ParseMachineName:
					goto ResumeParseMachineName;
				case States.EndParseMachineName:
					goto ResumeEndParseMachineName;
				case States.ParseInputTypeSeparator:
					goto ResumeParseInputTypeSeparator;
				case States.ParseInputType:
					goto ResumeParseInputType;
				case States.EndParseInputType:
					goto ResumeEndParseInputType;
				case States.BeginMachine:
					goto ResumeBeginMachine;
				case States.ParseStates:
					goto ResumeParseStates;
				case States.ParseSingleQuotes:
					goto ResumeParseSingleQuotes;
				case States.ParseDoubleQuotes:
					goto ResumeParseDoubleQuotes;
				case States.NestedBrace:
					goto ResumeNestedBrace;
				case States.NestedBraceSingeQuotes:
					goto ResumeNestedBraceSingeQuotes;
				case States.NestedBraceDoubleQuotes:
					goto ResumeNestedBraceDoubleQuotes;
				case States.IllegalDeclarationChar:
					goto ResumeIllegalDeclarationChar;
				case States.IllegalStateIdentifier:
					goto ResumeIllegalStateIdentifier;
				case States.IllegalStateContent:
					goto ResumeIllegalStateContent;
				case States.IllegalNestedStateContent:
					goto ResumeIllegalNestedStateContent;
			}


EnterParseDeclaration:
			state = States.ParseDeclaration;
			if (onParseDeclarationEnter != null)
				onParseDeclarationEnter(currentCommand);

ParseDeclaration:
			if (onParseDeclarationState != null)
				onParseDeclarationState(currentCommand);
ResumeParseDeclaration:
			nestResult = ParseDeclarationMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onParseDeclarationExit != null)
						onParseDeclarationExit(ParseDeclarationMachine.CurrentCommand);
					goto EnterEndParseDeclaration;
				case false:
					goto ParseDeclaration;
			}

EnterEndParseDeclaration:
			state = States.EndParseDeclaration;
			if (onEndParseDeclarationEnter != null)
				onEndParseDeclarationEnter(currentCommand);

EndParseDeclaration:
			if (onEndParseDeclarationState != null)
				onEndParseDeclarationState(currentCommand);
ResumeEndParseDeclaration:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto EndParseDeclaration;
				case '\t':
					goto EndParseDeclaration;
				case '\r':
					goto EndParseDeclaration;
				case '\n':
					goto EndParseDeclaration;
				case 'a':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'b':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'c':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'd':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'e':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'f':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'g':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'h':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'i':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'j':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'k':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'l':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'm':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'n':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'o':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'p':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'q':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'r':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 's':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 't':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'u':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'v':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'w':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'x':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'y':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'z':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'A':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'B':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'C':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'D':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'E':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'F':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'G':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'H':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'I':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'J':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'K':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'L':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'M':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'N':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'O':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'P':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'Q':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'R':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'S':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'T':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'U':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'V':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'W':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'X':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'Y':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case 'Z':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '0':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '1':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '2':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '3':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '4':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '5':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '6':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '7':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '8':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '9':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '_':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				case '.':
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterParseMachineName;
				default:
					if (onEndParseDeclarationExit != null)
						onEndParseDeclarationExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterParseMachineName:
			state = States.ParseMachineName;
			if (onParseMachineNameEnter != null)
				onParseMachineNameEnter(currentCommand);

ParseMachineName:
			if (onParseMachineNameState != null)
				onParseMachineNameState(currentCommand);
ResumeParseMachineName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterEndParseMachineName;
				case '\t':
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterEndParseMachineName;
				case '\r':
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterEndParseMachineName;
				case '\n':
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterEndParseMachineName;
				case ':':
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterParseInputTypeSeparator;
				case 'a':
					goto ParseMachineName;
				case 'b':
					goto ParseMachineName;
				case 'c':
					goto ParseMachineName;
				case 'd':
					goto ParseMachineName;
				case 'e':
					goto ParseMachineName;
				case 'f':
					goto ParseMachineName;
				case 'g':
					goto ParseMachineName;
				case 'h':
					goto ParseMachineName;
				case 'i':
					goto ParseMachineName;
				case 'j':
					goto ParseMachineName;
				case 'k':
					goto ParseMachineName;
				case 'l':
					goto ParseMachineName;
				case 'm':
					goto ParseMachineName;
				case 'n':
					goto ParseMachineName;
				case 'o':
					goto ParseMachineName;
				case 'p':
					goto ParseMachineName;
				case 'q':
					goto ParseMachineName;
				case 'r':
					goto ParseMachineName;
				case 's':
					goto ParseMachineName;
				case 't':
					goto ParseMachineName;
				case 'u':
					goto ParseMachineName;
				case 'v':
					goto ParseMachineName;
				case 'w':
					goto ParseMachineName;
				case 'x':
					goto ParseMachineName;
				case 'y':
					goto ParseMachineName;
				case 'z':
					goto ParseMachineName;
				case 'A':
					goto ParseMachineName;
				case 'B':
					goto ParseMachineName;
				case 'C':
					goto ParseMachineName;
				case 'D':
					goto ParseMachineName;
				case 'E':
					goto ParseMachineName;
				case 'F':
					goto ParseMachineName;
				case 'G':
					goto ParseMachineName;
				case 'H':
					goto ParseMachineName;
				case 'I':
					goto ParseMachineName;
				case 'J':
					goto ParseMachineName;
				case 'K':
					goto ParseMachineName;
				case 'L':
					goto ParseMachineName;
				case 'M':
					goto ParseMachineName;
				case 'N':
					goto ParseMachineName;
				case 'O':
					goto ParseMachineName;
				case 'P':
					goto ParseMachineName;
				case 'Q':
					goto ParseMachineName;
				case 'R':
					goto ParseMachineName;
				case 'S':
					goto ParseMachineName;
				case 'T':
					goto ParseMachineName;
				case 'U':
					goto ParseMachineName;
				case 'V':
					goto ParseMachineName;
				case 'W':
					goto ParseMachineName;
				case 'X':
					goto ParseMachineName;
				case 'Y':
					goto ParseMachineName;
				case 'Z':
					goto ParseMachineName;
				case '0':
					goto ParseMachineName;
				case '1':
					goto ParseMachineName;
				case '2':
					goto ParseMachineName;
				case '3':
					goto ParseMachineName;
				case '4':
					goto ParseMachineName;
				case '5':
					goto ParseMachineName;
				case '6':
					goto ParseMachineName;
				case '7':
					goto ParseMachineName;
				case '8':
					goto ParseMachineName;
				case '9':
					goto ParseMachineName;
				case '_':
					goto ParseMachineName;
				case '.':
					goto ParseMachineName;
				default:
					if (onParseMachineNameExit != null)
						onParseMachineNameExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterEndParseMachineName:
			state = States.EndParseMachineName;
			if (onEndParseMachineNameEnter != null)
				onEndParseMachineNameEnter(currentCommand);

EndParseMachineName:
			if (onEndParseMachineNameState != null)
				onEndParseMachineNameState(currentCommand);
ResumeEndParseMachineName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto EndParseMachineName;
				case '\t':
					goto EndParseMachineName;
				case '\r':
					goto EndParseMachineName;
				case '\n':
					goto EndParseMachineName;
				case ':':
					if (onEndParseMachineNameExit != null)
						onEndParseMachineNameExit(currentCommand);
					goto EnterParseInputTypeSeparator;
				default:
					if (onEndParseMachineNameExit != null)
						onEndParseMachineNameExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterParseInputTypeSeparator:
			state = States.ParseInputTypeSeparator;
			if (onParseInputTypeSeparatorEnter != null)
				onParseInputTypeSeparatorEnter(currentCommand);

ParseInputTypeSeparator:
			if (onParseInputTypeSeparatorState != null)
				onParseInputTypeSeparatorState(currentCommand);
ResumeParseInputTypeSeparator:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto ParseInputTypeSeparator;
				case '\t':
					goto ParseInputTypeSeparator;
				case '\r':
					goto ParseInputTypeSeparator;
				case '\n':
					goto ParseInputTypeSeparator;
				case 'a':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'b':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'c':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'd':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'e':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'f':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'g':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'h':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'i':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'j':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'k':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'l':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'm':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'n':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'o':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'p':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'q':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'r':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 's':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 't':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'u':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'v':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'w':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'x':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'y':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'z':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'A':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'B':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'C':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'D':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'E':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'F':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'G':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'H':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'I':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'J':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'K':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'L':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'M':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'N':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'O':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'P':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'Q':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'R':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'S':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'T':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'U':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'V':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'W':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'X':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'Y':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case 'Z':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '0':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '1':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '2':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '3':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '4':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '5':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '6':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '7':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '8':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '9':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '_':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				case '.':
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterParseInputType;
				default:
					if (onParseInputTypeSeparatorExit != null)
						onParseInputTypeSeparatorExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterParseInputType:
			state = States.ParseInputType;
			if (onParseInputTypeEnter != null)
				onParseInputTypeEnter(currentCommand);

ParseInputType:
			if (onParseInputTypeState != null)
				onParseInputTypeState(currentCommand);
ResumeParseInputType:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterEndParseInputType;
				case '\t':
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterEndParseInputType;
				case '\r':
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterEndParseInputType;
				case '\n':
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterEndParseInputType;
				case '{':
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterBeginMachine;
				case 'a':
					goto ParseInputType;
				case 'b':
					goto ParseInputType;
				case 'c':
					goto ParseInputType;
				case 'd':
					goto ParseInputType;
				case 'e':
					goto ParseInputType;
				case 'f':
					goto ParseInputType;
				case 'g':
					goto ParseInputType;
				case 'h':
					goto ParseInputType;
				case 'i':
					goto ParseInputType;
				case 'j':
					goto ParseInputType;
				case 'k':
					goto ParseInputType;
				case 'l':
					goto ParseInputType;
				case 'm':
					goto ParseInputType;
				case 'n':
					goto ParseInputType;
				case 'o':
					goto ParseInputType;
				case 'p':
					goto ParseInputType;
				case 'q':
					goto ParseInputType;
				case 'r':
					goto ParseInputType;
				case 's':
					goto ParseInputType;
				case 't':
					goto ParseInputType;
				case 'u':
					goto ParseInputType;
				case 'v':
					goto ParseInputType;
				case 'w':
					goto ParseInputType;
				case 'x':
					goto ParseInputType;
				case 'y':
					goto ParseInputType;
				case 'z':
					goto ParseInputType;
				case 'A':
					goto ParseInputType;
				case 'B':
					goto ParseInputType;
				case 'C':
					goto ParseInputType;
				case 'D':
					goto ParseInputType;
				case 'E':
					goto ParseInputType;
				case 'F':
					goto ParseInputType;
				case 'G':
					goto ParseInputType;
				case 'H':
					goto ParseInputType;
				case 'I':
					goto ParseInputType;
				case 'J':
					goto ParseInputType;
				case 'K':
					goto ParseInputType;
				case 'L':
					goto ParseInputType;
				case 'M':
					goto ParseInputType;
				case 'N':
					goto ParseInputType;
				case 'O':
					goto ParseInputType;
				case 'P':
					goto ParseInputType;
				case 'Q':
					goto ParseInputType;
				case 'R':
					goto ParseInputType;
				case 'S':
					goto ParseInputType;
				case 'T':
					goto ParseInputType;
				case 'U':
					goto ParseInputType;
				case 'V':
					goto ParseInputType;
				case 'W':
					goto ParseInputType;
				case 'X':
					goto ParseInputType;
				case 'Y':
					goto ParseInputType;
				case 'Z':
					goto ParseInputType;
				case '0':
					goto ParseInputType;
				case '1':
					goto ParseInputType;
				case '2':
					goto ParseInputType;
				case '3':
					goto ParseInputType;
				case '4':
					goto ParseInputType;
				case '5':
					goto ParseInputType;
				case '6':
					goto ParseInputType;
				case '7':
					goto ParseInputType;
				case '8':
					goto ParseInputType;
				case '9':
					goto ParseInputType;
				case '_':
					goto ParseInputType;
				case '.':
					goto ParseInputType;
				default:
					if (onParseInputTypeExit != null)
						onParseInputTypeExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterEndParseInputType:
			state = States.EndParseInputType;
			if (onEndParseInputTypeEnter != null)
				onEndParseInputTypeEnter(currentCommand);

EndParseInputType:
			if (onEndParseInputTypeState != null)
				onEndParseInputTypeState(currentCommand);
ResumeEndParseInputType:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto EndParseInputType;
				case '\t':
					goto EndParseInputType;
				case '\r':
					goto EndParseInputType;
				case '\n':
					goto EndParseInputType;
				case '{':
					if (onEndParseInputTypeExit != null)
						onEndParseInputTypeExit(currentCommand);
					goto EnterBeginMachine;
				default:
					if (onEndParseInputTypeExit != null)
						onEndParseInputTypeExit(currentCommand);
					goto EnterIllegalDeclarationChar;
			}

EnterBeginMachine:
			state = States.BeginMachine;
			if (onBeginMachineEnter != null)
				onBeginMachineEnter(currentCommand);

			if (onBeginMachineState != null)
				onBeginMachineState(currentCommand);
ResumeBeginMachine:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '}':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto Accept;
				case ' ':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '\t':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '\r':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '\n':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'a':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'b':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'c':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'd':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'e':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'f':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'g':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'h':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'i':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'j':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'k':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'l':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'm':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'n':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'o':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'p':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'q':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'r':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 's':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 't':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'u':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'v':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'w':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'x':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'y':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'z':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'A':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'B':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'C':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'D':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'E':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'F':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'G':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'H':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'I':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'J':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'K':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'L':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'M':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'N':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'O':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'P':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'Q':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'R':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'S':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'T':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'U':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'V':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'W':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'X':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'Y':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case 'Z':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '0':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '1':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '2':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '3':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '4':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '5':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '6':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '7':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '8':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '9':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '_':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				case '.':
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterParseStates;
				default:
					if (onBeginMachineExit != null)
						onBeginMachineExit(currentCommand);
					goto EnterIllegalStateIdentifier;
			}

EnterParseStates:
			state = States.ParseStates;
			if (onParseStatesEnter != null)
				onParseStatesEnter(currentCommand);

ParseStates:
			if (onParseStatesState != null)
				onParseStatesState(currentCommand);
ResumeParseStates:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '{':
					if (onParseStatesExit != null)
						onParseStatesExit(currentCommand);
					goto EnterNestedBrace;
				case '"':
					if (onParseStatesExit != null)
						onParseStatesExit(currentCommand);
					goto EnterParseDoubleQuotes;
				case '\'':
					if (onParseStatesExit != null)
						onParseStatesExit(currentCommand);
					goto EnterParseSingleQuotes;
				case '}':
					if (onParseStatesExit != null)
						onParseStatesExit(currentCommand);
					goto Accept;
				case ' ':
					goto ParseStates;
				case '\t':
					goto ParseStates;
				case '\r':
					goto ParseStates;
				case '\n':
					goto ParseStates;
				case '=':
					goto ParseStates;
				case ':':
					goto ParseStates;
				case '?':
					goto ParseStates;
				case ',':
					goto ParseStates;
				case ';':
					goto ParseStates;
				case 'a':
					goto ParseStates;
				case 'b':
					goto ParseStates;
				case 'c':
					goto ParseStates;
				case 'd':
					goto ParseStates;
				case 'e':
					goto ParseStates;
				case 'f':
					goto ParseStates;
				case 'g':
					goto ParseStates;
				case 'h':
					goto ParseStates;
				case 'i':
					goto ParseStates;
				case 'j':
					goto ParseStates;
				case 'k':
					goto ParseStates;
				case 'l':
					goto ParseStates;
				case 'm':
					goto ParseStates;
				case 'n':
					goto ParseStates;
				case 'o':
					goto ParseStates;
				case 'p':
					goto ParseStates;
				case 'q':
					goto ParseStates;
				case 'r':
					goto ParseStates;
				case 's':
					goto ParseStates;
				case 't':
					goto ParseStates;
				case 'u':
					goto ParseStates;
				case 'v':
					goto ParseStates;
				case 'w':
					goto ParseStates;
				case 'x':
					goto ParseStates;
				case 'y':
					goto ParseStates;
				case 'z':
					goto ParseStates;
				case 'A':
					goto ParseStates;
				case 'B':
					goto ParseStates;
				case 'C':
					goto ParseStates;
				case 'D':
					goto ParseStates;
				case 'E':
					goto ParseStates;
				case 'F':
					goto ParseStates;
				case 'G':
					goto ParseStates;
				case 'H':
					goto ParseStates;
				case 'I':
					goto ParseStates;
				case 'J':
					goto ParseStates;
				case 'K':
					goto ParseStates;
				case 'L':
					goto ParseStates;
				case 'M':
					goto ParseStates;
				case 'N':
					goto ParseStates;
				case 'O':
					goto ParseStates;
				case 'P':
					goto ParseStates;
				case 'Q':
					goto ParseStates;
				case 'R':
					goto ParseStates;
				case 'S':
					goto ParseStates;
				case 'T':
					goto ParseStates;
				case 'U':
					goto ParseStates;
				case 'V':
					goto ParseStates;
				case 'W':
					goto ParseStates;
				case 'X':
					goto ParseStates;
				case 'Y':
					goto ParseStates;
				case 'Z':
					goto ParseStates;
				case '0':
					goto ParseStates;
				case '1':
					goto ParseStates;
				case '2':
					goto ParseStates;
				case '3':
					goto ParseStates;
				case '4':
					goto ParseStates;
				case '5':
					goto ParseStates;
				case '6':
					goto ParseStates;
				case '7':
					goto ParseStates;
				case '8':
					goto ParseStates;
				case '9':
					goto ParseStates;
				case '_':
					goto ParseStates;
				case '.':
					goto ParseStates;
				default:
					if (onParseStatesExit != null)
						onParseStatesExit(currentCommand);
					goto EnterIllegalStateContent;
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
					goto EnterParseStates;
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
					goto EnterParseStates;
				case false:
			if (onParseDoubleQuotesExit != null)
						onParseDoubleQuotesExit(ParseDoubleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterNestedBrace:
			state = States.NestedBrace;
			if (onNestedBraceEnter != null)
				onNestedBraceEnter(currentCommand);

NestedBrace:
			if (onNestedBraceState != null)
				onNestedBraceState(currentCommand);
ResumeNestedBrace:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '}':
					if (onNestedBraceExit != null)
						onNestedBraceExit(currentCommand);
					goto EnterParseStates;
				case '\'':
					if (onNestedBraceExit != null)
						onNestedBraceExit(currentCommand);
					goto EnterNestedBraceSingeQuotes;
				case '"':
					if (onNestedBraceExit != null)
						onNestedBraceExit(currentCommand);
					goto EnterNestedBraceDoubleQuotes;
				case ' ':
					goto NestedBrace;
				case '\t':
					goto NestedBrace;
				case '\r':
					goto NestedBrace;
				case '\n':
					goto NestedBrace;
				case '=':
					goto NestedBrace;
				case ':':
					goto NestedBrace;
				case '?':
					goto NestedBrace;
				case ',':
					goto NestedBrace;
				case ';':
					goto NestedBrace;
				case 'a':
					goto NestedBrace;
				case 'b':
					goto NestedBrace;
				case 'c':
					goto NestedBrace;
				case 'd':
					goto NestedBrace;
				case 'e':
					goto NestedBrace;
				case 'f':
					goto NestedBrace;
				case 'g':
					goto NestedBrace;
				case 'h':
					goto NestedBrace;
				case 'i':
					goto NestedBrace;
				case 'j':
					goto NestedBrace;
				case 'k':
					goto NestedBrace;
				case 'l':
					goto NestedBrace;
				case 'm':
					goto NestedBrace;
				case 'n':
					goto NestedBrace;
				case 'o':
					goto NestedBrace;
				case 'p':
					goto NestedBrace;
				case 'q':
					goto NestedBrace;
				case 'r':
					goto NestedBrace;
				case 's':
					goto NestedBrace;
				case 't':
					goto NestedBrace;
				case 'u':
					goto NestedBrace;
				case 'v':
					goto NestedBrace;
				case 'w':
					goto NestedBrace;
				case 'x':
					goto NestedBrace;
				case 'y':
					goto NestedBrace;
				case 'z':
					goto NestedBrace;
				case 'A':
					goto NestedBrace;
				case 'B':
					goto NestedBrace;
				case 'C':
					goto NestedBrace;
				case 'D':
					goto NestedBrace;
				case 'E':
					goto NestedBrace;
				case 'F':
					goto NestedBrace;
				case 'G':
					goto NestedBrace;
				case 'H':
					goto NestedBrace;
				case 'I':
					goto NestedBrace;
				case 'J':
					goto NestedBrace;
				case 'K':
					goto NestedBrace;
				case 'L':
					goto NestedBrace;
				case 'M':
					goto NestedBrace;
				case 'N':
					goto NestedBrace;
				case 'O':
					goto NestedBrace;
				case 'P':
					goto NestedBrace;
				case 'Q':
					goto NestedBrace;
				case 'R':
					goto NestedBrace;
				case 'S':
					goto NestedBrace;
				case 'T':
					goto NestedBrace;
				case 'U':
					goto NestedBrace;
				case 'V':
					goto NestedBrace;
				case 'W':
					goto NestedBrace;
				case 'X':
					goto NestedBrace;
				case 'Y':
					goto NestedBrace;
				case 'Z':
					goto NestedBrace;
				case '0':
					goto NestedBrace;
				case '1':
					goto NestedBrace;
				case '2':
					goto NestedBrace;
				case '3':
					goto NestedBrace;
				case '4':
					goto NestedBrace;
				case '5':
					goto NestedBrace;
				case '6':
					goto NestedBrace;
				case '7':
					goto NestedBrace;
				case '8':
					goto NestedBrace;
				case '9':
					goto NestedBrace;
				case '_':
					goto NestedBrace;
				case '.':
					goto NestedBrace;
				default:
					if (onNestedBraceExit != null)
						onNestedBraceExit(currentCommand);
					goto EnterIllegalNestedStateContent;
			}

EnterNestedBraceSingeQuotes:
			state = States.NestedBraceSingeQuotes;
			if (onNestedBraceSingeQuotesEnter != null)
				onNestedBraceSingeQuotesEnter(currentCommand);

			if (onNestedBraceSingeQuotesState != null)
				onNestedBraceSingeQuotesState(currentCommand);
ResumeNestedBraceSingeQuotes:
			nestResult = NestedBraceSingeQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onNestedBraceSingeQuotesExit != null)
						onNestedBraceSingeQuotesExit(NestedBraceSingeQuotesMachine.CurrentCommand);
					goto EnterNestedBrace;
				case false:
			if (onNestedBraceSingeQuotesExit != null)
						onNestedBraceSingeQuotesExit(NestedBraceSingeQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterNestedBraceDoubleQuotes:
			state = States.NestedBraceDoubleQuotes;
			if (onNestedBraceDoubleQuotesEnter != null)
				onNestedBraceDoubleQuotesEnter(currentCommand);

			if (onNestedBraceDoubleQuotesState != null)
				onNestedBraceDoubleQuotesState(currentCommand);
ResumeNestedBraceDoubleQuotes:
			nestResult = NestedBraceDoubleQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onNestedBraceDoubleQuotesExit != null)
						onNestedBraceDoubleQuotesExit(NestedBraceDoubleQuotesMachine.CurrentCommand);
					goto EnterNestedBrace;
				case false:
			if (onNestedBraceDoubleQuotesExit != null)
						onNestedBraceDoubleQuotesExit(NestedBraceDoubleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterIllegalDeclarationChar:
			state = States.IllegalDeclarationChar;
			if (onIllegalDeclarationCharEnter != null)
				onIllegalDeclarationCharEnter(currentCommand);

			if (onIllegalDeclarationCharState != null)
				onIllegalDeclarationCharState(currentCommand);
ResumeIllegalDeclarationChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalDeclarationCharExit != null)
						onIllegalDeclarationCharExit(currentCommand);
					goto Decline;
			}

EnterIllegalStateIdentifier:
			state = States.IllegalStateIdentifier;
			if (onIllegalStateIdentifierEnter != null)
				onIllegalStateIdentifierEnter(currentCommand);

			if (onIllegalStateIdentifierState != null)
				onIllegalStateIdentifierState(currentCommand);
ResumeIllegalStateIdentifier:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalStateIdentifierExit != null)
						onIllegalStateIdentifierExit(currentCommand);
					goto Decline;
			}

EnterIllegalStateContent:
			state = States.IllegalStateContent;
			if (onIllegalStateContentEnter != null)
				onIllegalStateContentEnter(currentCommand);

			if (onIllegalStateContentState != null)
				onIllegalStateContentState(currentCommand);
ResumeIllegalStateContent:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalStateContentExit != null)
						onIllegalStateContentExit(currentCommand);
					goto Decline;
			}

EnterIllegalNestedStateContent:
			state = States.IllegalNestedStateContent;
			if (onIllegalNestedStateContentEnter != null)
				onIllegalNestedStateContentEnter(currentCommand);

			if (onIllegalNestedStateContentState != null)
				onIllegalNestedStateContentState(currentCommand);
ResumeIllegalNestedStateContent:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalNestedStateContentExit != null)
						onIllegalNestedStateContentExit(currentCommand);
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

		public void AddOnParseDeclaration(Action<char> addedFunc)
		{
			AddOnParseDeclarationEnter(addedFunc);
			ParseDeclarationMachine.addOnAllStates(addedFunc);
		}

		public void AddOnEndParseDeclaration(Action<char> addedFunc)
		{
			onEndParseDeclarationState += addedFunc;
		}

		public void AddOnParseMachineName(Action<char> addedFunc)
		{
			onParseMachineNameState += addedFunc;
		}

		public void AddOnEndParseMachineName(Action<char> addedFunc)
		{
			onEndParseMachineNameState += addedFunc;
		}

		public void AddOnParseInputTypeSeparator(Action<char> addedFunc)
		{
			onParseInputTypeSeparatorState += addedFunc;
		}

		public void AddOnParseInputType(Action<char> addedFunc)
		{
			onParseInputTypeState += addedFunc;
		}

		public void AddOnEndParseInputType(Action<char> addedFunc)
		{
			onEndParseInputTypeState += addedFunc;
		}

		public void AddOnBeginMachine(Action<char> addedFunc)
		{
			onBeginMachineState += addedFunc;
		}

		public void AddOnParseStates(Action<char> addedFunc)
		{
			onParseStatesState += addedFunc;
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

		public void AddOnNestedBrace(Action<char> addedFunc)
		{
			onNestedBraceState += addedFunc;
		}

		public void AddOnNestedBraceSingeQuotes(Action<char> addedFunc)
		{
			AddOnNestedBraceSingeQuotesEnter(addedFunc);
			NestedBraceSingeQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnNestedBraceDoubleQuotes(Action<char> addedFunc)
		{
			AddOnNestedBraceDoubleQuotesEnter(addedFunc);
			NestedBraceDoubleQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnIllegalDeclarationChar(Action<char> addedFunc)
		{
			onIllegalDeclarationCharState += addedFunc;
		}

		public void AddOnIllegalStateIdentifier(Action<char> addedFunc)
		{
			onIllegalStateIdentifierState += addedFunc;
		}

		public void AddOnIllegalStateContent(Action<char> addedFunc)
		{
			onIllegalStateContentState += addedFunc;
		}

		public void AddOnIllegalNestedStateContent(Action<char> addedFunc)
		{
			onIllegalNestedStateContentState += addedFunc;
		}

		public void AddOnParseDeclarationEnter(Action<char> addedFunc)
		{
			onParseDeclarationEnter += addedFunc;
		}

		public void AddOnEndParseDeclarationEnter(Action<char> addedFunc)
		{
			onEndParseDeclarationEnter += addedFunc;
		}

		public void AddOnParseMachineNameEnter(Action<char> addedFunc)
		{
			onParseMachineNameEnter += addedFunc;
		}

		public void AddOnEndParseMachineNameEnter(Action<char> addedFunc)
		{
			onEndParseMachineNameEnter += addedFunc;
		}

		public void AddOnParseInputTypeSeparatorEnter(Action<char> addedFunc)
		{
			onParseInputTypeSeparatorEnter += addedFunc;
		}

		public void AddOnParseInputTypeEnter(Action<char> addedFunc)
		{
			onParseInputTypeEnter += addedFunc;
		}

		public void AddOnEndParseInputTypeEnter(Action<char> addedFunc)
		{
			onEndParseInputTypeEnter += addedFunc;
		}

		public void AddOnBeginMachineEnter(Action<char> addedFunc)
		{
			onBeginMachineEnter += addedFunc;
		}

		public void AddOnParseStatesEnter(Action<char> addedFunc)
		{
			onParseStatesEnter += addedFunc;
		}

		public void AddOnParseSingleQuotesEnter(Action<char> addedFunc)
		{
			onParseSingleQuotesEnter += addedFunc;
		}

		public void AddOnParseDoubleQuotesEnter(Action<char> addedFunc)
		{
			onParseDoubleQuotesEnter += addedFunc;
		}

		public void AddOnNestedBraceEnter(Action<char> addedFunc)
		{
			onNestedBraceEnter += addedFunc;
		}

		public void AddOnNestedBraceSingeQuotesEnter(Action<char> addedFunc)
		{
			onNestedBraceSingeQuotesEnter += addedFunc;
		}

		public void AddOnNestedBraceDoubleQuotesEnter(Action<char> addedFunc)
		{
			onNestedBraceDoubleQuotesEnter += addedFunc;
		}

		public void AddOnIllegalDeclarationCharEnter(Action<char> addedFunc)
		{
			onIllegalDeclarationCharEnter += addedFunc;
		}

		public void AddOnIllegalStateIdentifierEnter(Action<char> addedFunc)
		{
			onIllegalStateIdentifierEnter += addedFunc;
		}

		public void AddOnIllegalStateContentEnter(Action<char> addedFunc)
		{
			onIllegalStateContentEnter += addedFunc;
		}

		public void AddOnIllegalNestedStateContentEnter(Action<char> addedFunc)
		{
			onIllegalNestedStateContentEnter += addedFunc;
		}

		public void AddOnParseDeclarationExit(Action<char> addedFunc)
		{
			onParseDeclarationExit += addedFunc;
		}

		public void AddOnEndParseDeclarationExit(Action<char> addedFunc)
		{
			onEndParseDeclarationExit += addedFunc;
		}

		public void AddOnParseMachineNameExit(Action<char> addedFunc)
		{
			onParseMachineNameExit += addedFunc;
		}

		public void AddOnEndParseMachineNameExit(Action<char> addedFunc)
		{
			onEndParseMachineNameExit += addedFunc;
		}

		public void AddOnParseInputTypeSeparatorExit(Action<char> addedFunc)
		{
			onParseInputTypeSeparatorExit += addedFunc;
		}

		public void AddOnParseInputTypeExit(Action<char> addedFunc)
		{
			onParseInputTypeExit += addedFunc;
		}

		public void AddOnEndParseInputTypeExit(Action<char> addedFunc)
		{
			onEndParseInputTypeExit += addedFunc;
		}

		public void AddOnBeginMachineExit(Action<char> addedFunc)
		{
			onBeginMachineExit += addedFunc;
		}

		public void AddOnParseStatesExit(Action<char> addedFunc)
		{
			onParseStatesExit += addedFunc;
		}

		public void AddOnParseSingleQuotesExit(Action<char> addedFunc)
		{
			onParseSingleQuotesExit += addedFunc;
		}

		public void AddOnParseDoubleQuotesExit(Action<char> addedFunc)
		{
			onParseDoubleQuotesExit += addedFunc;
		}

		public void AddOnNestedBraceExit(Action<char> addedFunc)
		{
			onNestedBraceExit += addedFunc;
		}

		public void AddOnNestedBraceSingeQuotesExit(Action<char> addedFunc)
		{
			onNestedBraceSingeQuotesExit += addedFunc;
		}

		public void AddOnNestedBraceDoubleQuotesExit(Action<char> addedFunc)
		{
			onNestedBraceDoubleQuotesExit += addedFunc;
		}

		public void AddOnIllegalDeclarationCharExit(Action<char> addedFunc)
		{
			onIllegalDeclarationCharExit += addedFunc;
		}

		public void AddOnIllegalStateIdentifierExit(Action<char> addedFunc)
		{
			onIllegalStateIdentifierExit += addedFunc;
		}

		public void AddOnIllegalStateContentExit(Action<char> addedFunc)
		{
			onIllegalStateContentExit += addedFunc;
		}

		public void AddOnIllegalNestedStateContentExit(Action<char> addedFunc)
		{
			onIllegalNestedStateContentExit += addedFunc;
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
			AddOnParseDeclaration(addedFunc);
			onEndParseDeclarationState += addedFunc;
			onParseMachineNameState += addedFunc;
			onEndParseMachineNameState += addedFunc;
			onParseInputTypeSeparatorState += addedFunc;
			onParseInputTypeState += addedFunc;
			onEndParseInputTypeState += addedFunc;
			onBeginMachineState += addedFunc;
			onParseStatesState += addedFunc;
			AddOnParseSingleQuotes(addedFunc);
			AddOnParseDoubleQuotes(addedFunc);
			onNestedBraceState += addedFunc;
			AddOnNestedBraceSingeQuotes(addedFunc);
			AddOnNestedBraceDoubleQuotes(addedFunc);
			onIllegalDeclarationCharState += addedFunc;
			onIllegalStateIdentifierState += addedFunc;
			onIllegalStateContentState += addedFunc;
			onIllegalNestedStateContentState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
			ParseDeclarationMachine.ResetStateOnEnd();
			ParseSingleQuotesMachine.ResetStateOnEnd();
			ParseDoubleQuotesMachine.ResetStateOnEnd();
			NestedBraceSingeQuotesMachine.ResetStateOnEnd();
			NestedBraceDoubleQuotesMachine.ResetStateOnEnd();
		}
	}
}
