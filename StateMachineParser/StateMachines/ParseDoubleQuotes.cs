// ************************ ParseDoubleQuotes : char ************************
// 
// 	group newline		= { '\n', '\r' }
// 	ParseDoubleQuote	: newline = decline, '"' = accept, '\\' = EscapedChar,
// 			default = ParseDoubleQuote;
// 	EscapedChar			: newline = decline, default = ParseDoubleQuote;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class ParseDoubleQuotes
	{
		public enum States
		{
			ParseDoubleQuote = 0, 	EscapedChar = 1, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onParseDoubleQuoteState = null;
		private Action<char> onParseDoubleQuoteEnter = null;
		private Action<char> onParseDoubleQuoteExit = null;
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
						state = States.ParseDoubleQuote;
						goto ResumeParseDoubleQuote;
					}
					else
						goto End;
				case States.ParseDoubleQuote:
					goto ResumeParseDoubleQuote;
				case States.EscapedChar:
					goto ResumeEscapedChar;
			}


EnterParseDoubleQuote:
			state = States.ParseDoubleQuote;
			if (onParseDoubleQuoteEnter != null)
				onParseDoubleQuoteEnter(currentCommand);

ParseDoubleQuote:
			if (onParseDoubleQuoteState != null)
				onParseDoubleQuoteState(currentCommand);
ResumeParseDoubleQuote:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\n':
					if (onParseDoubleQuoteExit != null)
						onParseDoubleQuoteExit(currentCommand);
					goto Decline;
				case '\r':
					if (onParseDoubleQuoteExit != null)
						onParseDoubleQuoteExit(currentCommand);
					goto Decline;
				case '"':
					if (onParseDoubleQuoteExit != null)
						onParseDoubleQuoteExit(currentCommand);
					goto Accept;
				case '\\':
					if (onParseDoubleQuoteExit != null)
						onParseDoubleQuoteExit(currentCommand);
					goto EnterEscapedChar;
				default:
					goto ParseDoubleQuote;
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
					goto EnterParseDoubleQuote;
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

		public void AddOnParseDoubleQuote(Action<char> addedFunc)
		{
			onParseDoubleQuoteState += addedFunc;
		}

		public void AddOnEscapedChar(Action<char> addedFunc)
		{
			onEscapedCharState += addedFunc;
		}

		public void AddOnParseDoubleQuoteEnter(Action<char> addedFunc)
		{
			onParseDoubleQuoteEnter += addedFunc;
		}

		public void AddOnEscapedCharEnter(Action<char> addedFunc)
		{
			onEscapedCharEnter += addedFunc;
		}

		public void AddOnParseDoubleQuoteExit(Action<char> addedFunc)
		{
			onParseDoubleQuoteExit += addedFunc;
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
			onParseDoubleQuoteState += addedFunc;
			onEscapedCharState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
		}
	}
}
