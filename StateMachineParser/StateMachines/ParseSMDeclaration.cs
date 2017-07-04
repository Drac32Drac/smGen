// ************************ ParseSMDeclaration : char ************************
// 
// 	Char1		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'S' = Char2, default = decline;
// 	Char2		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			't' = Char3, default = decline;
// 	Char3		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'a' = Char4, default = decline;
// 	Char4		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			't' = Char5, default = decline;
// 	Char5		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'e' = Char6, default = decline;
// 	Char6		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'M' = Char7, default = decline;
// 	Char7		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'a' = Char8, default = decline;
// 	Char8		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'c' = Char9, default = decline;
// 	Char9		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'h' = Char10, default = decline;
// 	Char10		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'i' = Char11, default = decline;
// 	Char11		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'n' = Char12, default = decline;
// 	Char12		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'e' = accept, default = decline;
// 	ParseSingleQuotes	: ParseSingleQuotes ? decline : decline;
// 	ParseDoubleQuotes	: ParseDoubleQuotes ? decline : decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class ParseSMDeclaration
	{
		public enum States
		{
			Char1 = 0, 	Char2 = 1, 
			Char3 = 2, 	Char4 = 3, 
			Char5 = 4, 	Char6 = 5, 
			Char7 = 6, 	Char8 = 7, 
			Char9 = 8, 	Char10 = 9, 
			Char11 = 10, 	Char12 = 11, 
			ParseSingleQuotes = 12, 	ParseDoubleQuotes = 13, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onChar1State = null;
		private Action<char> onChar1Enter = null;
		private Action<char> onChar1Exit = null;
		private Action<char> onChar2State = null;
		private Action<char> onChar2Enter = null;
		private Action<char> onChar2Exit = null;
		private Action<char> onChar3State = null;
		private Action<char> onChar3Enter = null;
		private Action<char> onChar3Exit = null;
		private Action<char> onChar4State = null;
		private Action<char> onChar4Enter = null;
		private Action<char> onChar4Exit = null;
		private Action<char> onChar5State = null;
		private Action<char> onChar5Enter = null;
		private Action<char> onChar5Exit = null;
		private Action<char> onChar6State = null;
		private Action<char> onChar6Enter = null;
		private Action<char> onChar6Exit = null;
		private Action<char> onChar7State = null;
		private Action<char> onChar7Enter = null;
		private Action<char> onChar7Exit = null;
		private Action<char> onChar8State = null;
		private Action<char> onChar8Enter = null;
		private Action<char> onChar8Exit = null;
		private Action<char> onChar9State = null;
		private Action<char> onChar9Enter = null;
		private Action<char> onChar9Exit = null;
		private Action<char> onChar10State = null;
		private Action<char> onChar10Enter = null;
		private Action<char> onChar10Exit = null;
		private Action<char> onChar11State = null;
		private Action<char> onChar11Enter = null;
		private Action<char> onChar11Exit = null;
		private Action<char> onChar12State = null;
		private Action<char> onChar12Enter = null;
		private Action<char> onChar12Exit = null;
		private Action<char> onParseSingleQuotesState = null;
		private Action<char> onParseSingleQuotesEnter = null;
		private Action<char> onParseSingleQuotesExit = null;
		private Action<char> onParseDoubleQuotesState = null;
		private Action<char> onParseDoubleQuotesEnter = null;
		private Action<char> onParseDoubleQuotesExit = null;
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
						state = States.Char1;
						goto ResumeChar1;
					}
					else
						goto End;
				case States.Char1:
					goto ResumeChar1;
				case States.Char2:
					goto ResumeChar2;
				case States.Char3:
					goto ResumeChar3;
				case States.Char4:
					goto ResumeChar4;
				case States.Char5:
					goto ResumeChar5;
				case States.Char6:
					goto ResumeChar6;
				case States.Char7:
					goto ResumeChar7;
				case States.Char8:
					goto ResumeChar8;
				case States.Char9:
					goto ResumeChar9;
				case States.Char10:
					goto ResumeChar10;
				case States.Char11:
					goto ResumeChar11;
				case States.Char12:
					goto ResumeChar12;
				case States.ParseSingleQuotes:
					goto ResumeParseSingleQuotes;
				case States.ParseDoubleQuotes:
					goto ResumeParseDoubleQuotes;
			}


EnterChar1:
			state = States.Char1;
			if (onChar1Enter != null)
				onChar1Enter(currentCommand);

			if (onChar1State != null)
				onChar1State(currentCommand);
ResumeChar1:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar1Exit != null)
						onChar1Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar1Exit != null)
						onChar1Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'S':
					if (onChar1Exit != null)
						onChar1Exit(currentCommand);
					goto EnterChar2;
				default:
					if (onChar1Exit != null)
						onChar1Exit(currentCommand);
					goto Decline;
			}

EnterChar2:
			state = States.Char2;
			if (onChar2Enter != null)
				onChar2Enter(currentCommand);

			if (onChar2State != null)
				onChar2State(currentCommand);
ResumeChar2:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar2Exit != null)
						onChar2Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar2Exit != null)
						onChar2Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 't':
					if (onChar2Exit != null)
						onChar2Exit(currentCommand);
					goto EnterChar3;
				default:
					if (onChar2Exit != null)
						onChar2Exit(currentCommand);
					goto Decline;
			}

EnterChar3:
			state = States.Char3;
			if (onChar3Enter != null)
				onChar3Enter(currentCommand);

			if (onChar3State != null)
				onChar3State(currentCommand);
ResumeChar3:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar3Exit != null)
						onChar3Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar3Exit != null)
						onChar3Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'a':
					if (onChar3Exit != null)
						onChar3Exit(currentCommand);
					goto EnterChar4;
				default:
					if (onChar3Exit != null)
						onChar3Exit(currentCommand);
					goto Decline;
			}

EnterChar4:
			state = States.Char4;
			if (onChar4Enter != null)
				onChar4Enter(currentCommand);

			if (onChar4State != null)
				onChar4State(currentCommand);
ResumeChar4:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar4Exit != null)
						onChar4Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar4Exit != null)
						onChar4Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 't':
					if (onChar4Exit != null)
						onChar4Exit(currentCommand);
					goto EnterChar5;
				default:
					if (onChar4Exit != null)
						onChar4Exit(currentCommand);
					goto Decline;
			}

EnterChar5:
			state = States.Char5;
			if (onChar5Enter != null)
				onChar5Enter(currentCommand);

			if (onChar5State != null)
				onChar5State(currentCommand);
ResumeChar5:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'e':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto EnterChar6;
				default:
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto Decline;
			}

EnterChar6:
			state = States.Char6;
			if (onChar6Enter != null)
				onChar6Enter(currentCommand);

			if (onChar6State != null)
				onChar6State(currentCommand);
ResumeChar6:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar6Exit != null)
						onChar6Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar6Exit != null)
						onChar6Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'M':
					if (onChar6Exit != null)
						onChar6Exit(currentCommand);
					goto EnterChar7;
				default:
					if (onChar6Exit != null)
						onChar6Exit(currentCommand);
					goto Decline;
			}

EnterChar7:
			state = States.Char7;
			if (onChar7Enter != null)
				onChar7Enter(currentCommand);

			if (onChar7State != null)
				onChar7State(currentCommand);
ResumeChar7:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar7Exit != null)
						onChar7Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar7Exit != null)
						onChar7Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'a':
					if (onChar7Exit != null)
						onChar7Exit(currentCommand);
					goto EnterChar8;
				default:
					if (onChar7Exit != null)
						onChar7Exit(currentCommand);
					goto Decline;
			}

EnterChar8:
			state = States.Char8;
			if (onChar8Enter != null)
				onChar8Enter(currentCommand);

			if (onChar8State != null)
				onChar8State(currentCommand);
ResumeChar8:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar8Exit != null)
						onChar8Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar8Exit != null)
						onChar8Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'c':
					if (onChar8Exit != null)
						onChar8Exit(currentCommand);
					goto EnterChar9;
				default:
					if (onChar8Exit != null)
						onChar8Exit(currentCommand);
					goto Decline;
			}

EnterChar9:
			state = States.Char9;
			if (onChar9Enter != null)
				onChar9Enter(currentCommand);

			if (onChar9State != null)
				onChar9State(currentCommand);
ResumeChar9:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar9Exit != null)
						onChar9Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar9Exit != null)
						onChar9Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'h':
					if (onChar9Exit != null)
						onChar9Exit(currentCommand);
					goto EnterChar10;
				default:
					if (onChar9Exit != null)
						onChar9Exit(currentCommand);
					goto Decline;
			}

EnterChar10:
			state = States.Char10;
			if (onChar10Enter != null)
				onChar10Enter(currentCommand);

			if (onChar10State != null)
				onChar10State(currentCommand);
ResumeChar10:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar10Exit != null)
						onChar10Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar10Exit != null)
						onChar10Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'i':
					if (onChar10Exit != null)
						onChar10Exit(currentCommand);
					goto EnterChar11;
				default:
					if (onChar10Exit != null)
						onChar10Exit(currentCommand);
					goto Decline;
			}

EnterChar11:
			state = States.Char11;
			if (onChar11Enter != null)
				onChar11Enter(currentCommand);

			if (onChar11State != null)
				onChar11State(currentCommand);
ResumeChar11:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar11Exit != null)
						onChar11Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar11Exit != null)
						onChar11Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'n':
					if (onChar11Exit != null)
						onChar11Exit(currentCommand);
					goto EnterChar12;
				default:
					if (onChar11Exit != null)
						onChar11Exit(currentCommand);
					goto Decline;
			}

EnterChar12:
			state = States.Char12;
			if (onChar12Enter != null)
				onChar12Enter(currentCommand);

			if (onChar12State != null)
				onChar12State(currentCommand);
ResumeChar12:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar12Exit != null)
						onChar12Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar12Exit != null)
						onChar12Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'e':
					if (onChar12Exit != null)
						onChar12Exit(currentCommand);
					goto Accept;
				default:
					if (onChar12Exit != null)
						onChar12Exit(currentCommand);
					goto Decline;
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
					goto Decline;
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
					goto Decline;
				case false:
			if (onParseDoubleQuotesExit != null)
						onParseDoubleQuotesExit(ParseDoubleQuotesMachine.CurrentCommand);
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

		public void AddOnChar1(Action<char> addedFunc)
		{
			onChar1State += addedFunc;
		}

		public void AddOnChar2(Action<char> addedFunc)
		{
			onChar2State += addedFunc;
		}

		public void AddOnChar3(Action<char> addedFunc)
		{
			onChar3State += addedFunc;
		}

		public void AddOnChar4(Action<char> addedFunc)
		{
			onChar4State += addedFunc;
		}

		public void AddOnChar5(Action<char> addedFunc)
		{
			onChar5State += addedFunc;
		}

		public void AddOnChar6(Action<char> addedFunc)
		{
			onChar6State += addedFunc;
		}

		public void AddOnChar7(Action<char> addedFunc)
		{
			onChar7State += addedFunc;
		}

		public void AddOnChar8(Action<char> addedFunc)
		{
			onChar8State += addedFunc;
		}

		public void AddOnChar9(Action<char> addedFunc)
		{
			onChar9State += addedFunc;
		}

		public void AddOnChar10(Action<char> addedFunc)
		{
			onChar10State += addedFunc;
		}

		public void AddOnChar11(Action<char> addedFunc)
		{
			onChar11State += addedFunc;
		}

		public void AddOnChar12(Action<char> addedFunc)
		{
			onChar12State += addedFunc;
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

		public void AddOnChar1Enter(Action<char> addedFunc)
		{
			onChar1Enter += addedFunc;
		}

		public void AddOnChar2Enter(Action<char> addedFunc)
		{
			onChar2Enter += addedFunc;
		}

		public void AddOnChar3Enter(Action<char> addedFunc)
		{
			onChar3Enter += addedFunc;
		}

		public void AddOnChar4Enter(Action<char> addedFunc)
		{
			onChar4Enter += addedFunc;
		}

		public void AddOnChar5Enter(Action<char> addedFunc)
		{
			onChar5Enter += addedFunc;
		}

		public void AddOnChar6Enter(Action<char> addedFunc)
		{
			onChar6Enter += addedFunc;
		}

		public void AddOnChar7Enter(Action<char> addedFunc)
		{
			onChar7Enter += addedFunc;
		}

		public void AddOnChar8Enter(Action<char> addedFunc)
		{
			onChar8Enter += addedFunc;
		}

		public void AddOnChar9Enter(Action<char> addedFunc)
		{
			onChar9Enter += addedFunc;
		}

		public void AddOnChar10Enter(Action<char> addedFunc)
		{
			onChar10Enter += addedFunc;
		}

		public void AddOnChar11Enter(Action<char> addedFunc)
		{
			onChar11Enter += addedFunc;
		}

		public void AddOnChar12Enter(Action<char> addedFunc)
		{
			onChar12Enter += addedFunc;
		}

		public void AddOnParseSingleQuotesEnter(Action<char> addedFunc)
		{
			onParseSingleQuotesEnter += addedFunc;
		}

		public void AddOnParseDoubleQuotesEnter(Action<char> addedFunc)
		{
			onParseDoubleQuotesEnter += addedFunc;
		}

		public void AddOnChar1Exit(Action<char> addedFunc)
		{
			onChar1Exit += addedFunc;
		}

		public void AddOnChar2Exit(Action<char> addedFunc)
		{
			onChar2Exit += addedFunc;
		}

		public void AddOnChar3Exit(Action<char> addedFunc)
		{
			onChar3Exit += addedFunc;
		}

		public void AddOnChar4Exit(Action<char> addedFunc)
		{
			onChar4Exit += addedFunc;
		}

		public void AddOnChar5Exit(Action<char> addedFunc)
		{
			onChar5Exit += addedFunc;
		}

		public void AddOnChar6Exit(Action<char> addedFunc)
		{
			onChar6Exit += addedFunc;
		}

		public void AddOnChar7Exit(Action<char> addedFunc)
		{
			onChar7Exit += addedFunc;
		}

		public void AddOnChar8Exit(Action<char> addedFunc)
		{
			onChar8Exit += addedFunc;
		}

		public void AddOnChar9Exit(Action<char> addedFunc)
		{
			onChar9Exit += addedFunc;
		}

		public void AddOnChar10Exit(Action<char> addedFunc)
		{
			onChar10Exit += addedFunc;
		}

		public void AddOnChar11Exit(Action<char> addedFunc)
		{
			onChar11Exit += addedFunc;
		}

		public void AddOnChar12Exit(Action<char> addedFunc)
		{
			onChar12Exit += addedFunc;
		}

		public void AddOnParseSingleQuotesExit(Action<char> addedFunc)
		{
			onParseSingleQuotesExit += addedFunc;
		}

		public void AddOnParseDoubleQuotesExit(Action<char> addedFunc)
		{
			onParseDoubleQuotesExit += addedFunc;
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
			onChar1State += addedFunc;
			onChar2State += addedFunc;
			onChar3State += addedFunc;
			onChar4State += addedFunc;
			onChar5State += addedFunc;
			onChar6State += addedFunc;
			onChar7State += addedFunc;
			onChar8State += addedFunc;
			onChar9State += addedFunc;
			onChar10State += addedFunc;
			onChar11State += addedFunc;
			onChar12State += addedFunc;
			AddOnParseSingleQuotes(addedFunc);
			AddOnParseDoubleQuotes(addedFunc);
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
