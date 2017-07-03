// ************************ ParseSMGroupDeclaration : char ************************
// 
// 	Char0		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'g' = Char1, default = decline;
// 	Char1		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'r' = Char2, default = decline;
// 	Char2		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'o' = Char3, default = decline;
// 	Char3		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'u' = Char4, default = decline;
// 	Char4		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			'p' = Char5, default = decline;
// 	Char5		: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes, 
// 			' ' = accept, '\t' = accept, '\r' = accept, '\n' = accept, default = decline;
// 	ParseSingleQuotes	: ParseSingleQuotes ? decline : decline;
// 	ParseDoubleQuotes	: ParseDoubleQuotes ? decline : decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace test
{
	public class ParseSMGroupDeclaration
	{
		public enum States
		{
			Char0 = 0, 	Char1 = 1, 
			Char2 = 2, 	Char3 = 3, 
			Char4 = 4, 	Char5 = 5, 
			ParseSingleQuotes = 6, 	ParseDoubleQuotes = 7, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onChar0State = null;
		private Action<char> onChar0Enter = null;
		private Action<char> onChar0Exit = null;
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
						state = States.Char0;
						goto ResumeChar0;
					}
					else
						goto End;
				case States.Char0:
					goto ResumeChar0;
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
				case States.ParseSingleQuotes:
					goto ResumeParseSingleQuotes;
				case States.ParseDoubleQuotes:
					goto ResumeParseDoubleQuotes;
			}


EnterChar0:
			state = States.Char0;
			if (onChar0Enter != null)
				onChar0Enter(currentCommand);

			if (onChar0State != null)
				onChar0State(currentCommand);
ResumeChar0:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onChar0Exit != null)
						onChar0Exit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onChar0Exit != null)
						onChar0Exit(currentCommand);
					goto EnterParseDoubleQuotes;
				case 'g':
					if (onChar0Exit != null)
						onChar0Exit(currentCommand);
					goto EnterChar1;
				default:
					if (onChar0Exit != null)
						onChar0Exit(currentCommand);
					goto Decline;
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
				case 'r':
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
				case 'o':
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
				case 'u':
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
				case 'p':
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
				case ' ':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto Accept;
				case '\t':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto Accept;
				case '\r':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto Accept;
				case '\n':
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
					goto Accept;
				default:
					if (onChar5Exit != null)
						onChar5Exit(currentCommand);
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

		public void AddOnChar0(Action<char> addedFunc)
		{
			onChar0State += addedFunc;
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

		public void AddOnChar0Enter(Action<char> addedFunc)
		{
			onChar0Enter += addedFunc;
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

		public void AddOnParseSingleQuotesEnter(Action<char> addedFunc)
		{
			onParseSingleQuotesEnter += addedFunc;
		}

		public void AddOnParseDoubleQuotesEnter(Action<char> addedFunc)
		{
			onParseDoubleQuotesEnter += addedFunc;
		}

		public void AddOnChar0Exit(Action<char> addedFunc)
		{
			onChar0Exit += addedFunc;
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
			onChar0State += addedFunc;
			onChar1State += addedFunc;
			onChar2State += addedFunc;
			onChar3State += addedFunc;
			onChar4State += addedFunc;
			onChar5State += addedFunc;
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
