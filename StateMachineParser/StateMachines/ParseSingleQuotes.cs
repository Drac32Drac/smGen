// ************************ ParseSingleQuotes : char ************************
// 
// 	group newline		= { '\n', '\r' }
// 	ParseSingleQuote	: newline = decline, '\'' = accept, '\\' = EscapedChar,
// 			default = ParseSingleQuote;
// 	EscapedChar			: newline = decline, default = ParseSingleQuote;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class ParseSingleQuotes
	{
		public enum States
		{
			ParseSingleQuote = 0, 	EscapedChar = 1, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onParseSingleQuoteState = null;
		private Action<char> onParseSingleQuoteEnter = null;
		private Action<char> onParseSingleQuoteExit = null;
		private Action<char> onEscapedCharState = null;
		private Action<char> onEscapedCharEnter = null;
		private Action<char> onEscapedCharExit = null;
		private Action<char> onAccept = null;
		private Action<char> onDecline = null;
		private Action<char> onEnd = null;


		public bool? Input(Queue<char> data)
		{
			if (reset)
				state = null;
			bool? result = null;
			if (data == null)
				return null;

Reset:
			reset = false;
			switch (state)
			{
				case null:
					if (data.Count > 0)
					{
						state = States.ParseSingleQuote;
						goto ResumeParseSingleQuote;
					}
					else
						goto End;
				case States.ParseSingleQuote:
					goto ResumeParseSingleQuote;
				case States.EscapedChar:
					goto ResumeEscapedChar;
			}


EnterParseSingleQuote:
			state = States.ParseSingleQuote;
			if (onParseSingleQuoteEnter != null)
				onParseSingleQuoteEnter(currentCommand);

ParseSingleQuote:
			if (onParseSingleQuoteState != null)
				onParseSingleQuoteState(currentCommand);
ResumeParseSingleQuote:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\n':
					if (onParseSingleQuoteExit != null)
						onParseSingleQuoteExit(currentCommand);
					goto Decline;
				case '\r':
					if (onParseSingleQuoteExit != null)
						onParseSingleQuoteExit(currentCommand);
					goto Decline;
				case '\'':
					if (onParseSingleQuoteExit != null)
						onParseSingleQuoteExit(currentCommand);
					goto Accept;
				case '\\':
					if (onParseSingleQuoteExit != null)
						onParseSingleQuoteExit(currentCommand);
					goto EnterEscapedChar;
				default:
					goto ParseSingleQuote;
			}

EnterEscapedChar:
			state = States.EscapedChar;
			if (onEscapedCharEnter != null)
				onEscapedCharEnter(currentCommand);

			if (onEscapedCharState != null)
				onEscapedCharState(currentCommand);
ResumeEscapedChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\n':
					if (onEscapedCharExit != null)
						onEscapedCharExit(currentCommand);
					goto Decline;
				case '\r':
					if (onEscapedCharExit != null)
						onEscapedCharExit(currentCommand);
					goto Decline;
				default:
					if (onEscapedCharExit != null)
						onEscapedCharExit(currentCommand);
					goto EnterParseSingleQuote;
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

		public void AddOnParseSingleQuote(Action<char> addedFunc)
		{
			onParseSingleQuoteState += addedFunc;
		}

		public void AddOnEscapedChar(Action<char> addedFunc)
		{
			onEscapedCharState += addedFunc;
		}

		public void AddOnParseSingleQuoteEnter(Action<char> addedFunc)
		{
			onParseSingleQuoteEnter += addedFunc;
		}

		public void AddOnEscapedCharEnter(Action<char> addedFunc)
		{
			onEscapedCharEnter += addedFunc;
		}

		public void AddOnParseSingleQuoteExit(Action<char> addedFunc)
		{
			onParseSingleQuoteExit += addedFunc;
		}

		public void AddOnEscapedCharExit(Action<char> addedFunc)
		{
			onEscapedCharExit += addedFunc;
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
			onParseSingleQuoteState += addedFunc;
			onEscapedCharState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
		}
	}
}
