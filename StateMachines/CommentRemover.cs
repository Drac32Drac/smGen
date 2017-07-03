// ************************ CommentRemover : char ************************
// 
// 	Parse					: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes,
// 			'/' = ParseCommentType, default = Parse;
// 	ParseCommentType		: '/' = ParseSingleComment, '*' = ParseMultiComment,
// 			default = IllegalCommentType;
// 	ParseSingleComment		: '\r' = Parse, '\n' = Parse, default = ParseSingleComment;
// 	ParseMultiComment		: '*' = TestEndMultiComment, default = ParseMultiComment;
// 	TestEndMultiComment		: '/' = EndComment, default = ParseMultiComment;
// 	EndComment				: '\'' = ParseSingleQuotes, '"' = ParseDoubleQuotes,
// 			'/' = ParseCommentType, default = Parse;
// 	ParseSingleQuotes		: ParseSingleQuotes ? Parse : IllegalSingleQuotes;
// 	ParseDoubleQuotes		: ParseDoubleQuotes ? Parse : IllegalDoubleQuotes;
// 		
// 	IllegalCommentType		: default = decline;
// 	IllegalSingleQuotes		: default = decline;
// 	IllegalDoubleQuotes		: default = decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace test
{
	public class CommentRemover
	{
		public enum States
		{
			Parse = 0, 	ParseCommentType = 1, 
			ParseSingleComment = 2, 	ParseMultiComment = 3, 
			TestEndMultiComment = 4, 	EndComment = 5, 
			ParseSingleQuotes = 6, 	ParseDoubleQuotes = 7, 
			IllegalCommentType = 8, 	IllegalSingleQuotes = 9, 
			IllegalDoubleQuotes = 10, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onParseState = null;
		private Action<char> onParseEnter = null;
		private Action<char> onParseExit = null;
		private Action<char> onParseCommentTypeState = null;
		private Action<char> onParseCommentTypeEnter = null;
		private Action<char> onParseCommentTypeExit = null;
		private Action<char> onParseSingleCommentState = null;
		private Action<char> onParseSingleCommentEnter = null;
		private Action<char> onParseSingleCommentExit = null;
		private Action<char> onParseMultiCommentState = null;
		private Action<char> onParseMultiCommentEnter = null;
		private Action<char> onParseMultiCommentExit = null;
		private Action<char> onTestEndMultiCommentState = null;
		private Action<char> onTestEndMultiCommentEnter = null;
		private Action<char> onTestEndMultiCommentExit = null;
		private Action<char> onEndCommentState = null;
		private Action<char> onEndCommentEnter = null;
		private Action<char> onEndCommentExit = null;
		private Action<char> onParseSingleQuotesState = null;
		private Action<char> onParseSingleQuotesEnter = null;
		private Action<char> onParseSingleQuotesExit = null;
		private Action<char> onParseDoubleQuotesState = null;
		private Action<char> onParseDoubleQuotesEnter = null;
		private Action<char> onParseDoubleQuotesExit = null;
		private Action<char> onIllegalCommentTypeState = null;
		private Action<char> onIllegalCommentTypeEnter = null;
		private Action<char> onIllegalCommentTypeExit = null;
		private Action<char> onIllegalSingleQuotesState = null;
		private Action<char> onIllegalSingleQuotesEnter = null;
		private Action<char> onIllegalSingleQuotesExit = null;
		private Action<char> onIllegalDoubleQuotesState = null;
		private Action<char> onIllegalDoubleQuotesEnter = null;
		private Action<char> onIllegalDoubleQuotesExit = null;
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
						state = States.Parse;
						goto ResumeParse;
					}
					else
						goto End;
				case States.Parse:
					goto ResumeParse;
				case States.ParseCommentType:
					goto ResumeParseCommentType;
				case States.ParseSingleComment:
					goto ResumeParseSingleComment;
				case States.ParseMultiComment:
					goto ResumeParseMultiComment;
				case States.TestEndMultiComment:
					goto ResumeTestEndMultiComment;
				case States.EndComment:
					goto ResumeEndComment;
				case States.ParseSingleQuotes:
					goto ResumeParseSingleQuotes;
				case States.ParseDoubleQuotes:
					goto ResumeParseDoubleQuotes;
				case States.IllegalCommentType:
					goto ResumeIllegalCommentType;
				case States.IllegalSingleQuotes:
					goto ResumeIllegalSingleQuotes;
				case States.IllegalDoubleQuotes:
					goto ResumeIllegalDoubleQuotes;
			}


EnterParse:
			state = States.Parse;
			if (onParseEnter != null)
				onParseEnter(currentCommand);

Parse:
			if (onParseState != null)
				onParseState(currentCommand);
ResumeParse:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onParseExit != null)
						onParseExit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onParseExit != null)
						onParseExit(currentCommand);
					goto EnterParseDoubleQuotes;
				case '/':
					if (onParseExit != null)
						onParseExit(currentCommand);
					goto EnterParseCommentType;
				default:
					goto Parse;
			}

EnterParseCommentType:
			state = States.ParseCommentType;
			if (onParseCommentTypeEnter != null)
				onParseCommentTypeEnter(currentCommand);

			if (onParseCommentTypeState != null)
				onParseCommentTypeState(currentCommand);
ResumeParseCommentType:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '/':
					if (onParseCommentTypeExit != null)
						onParseCommentTypeExit(currentCommand);
					goto EnterParseSingleComment;
				case '*':
					if (onParseCommentTypeExit != null)
						onParseCommentTypeExit(currentCommand);
					goto EnterParseMultiComment;
				default:
					if (onParseCommentTypeExit != null)
						onParseCommentTypeExit(currentCommand);
					goto EnterIllegalCommentType;
			}

EnterParseSingleComment:
			state = States.ParseSingleComment;
			if (onParseSingleCommentEnter != null)
				onParseSingleCommentEnter(currentCommand);

ParseSingleComment:
			if (onParseSingleCommentState != null)
				onParseSingleCommentState(currentCommand);
ResumeParseSingleComment:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\r':
					if (onParseSingleCommentExit != null)
						onParseSingleCommentExit(currentCommand);
					goto EnterParse;
				case '\n':
					if (onParseSingleCommentExit != null)
						onParseSingleCommentExit(currentCommand);
					goto EnterParse;
				default:
					goto ParseSingleComment;
			}

EnterParseMultiComment:
			state = States.ParseMultiComment;
			if (onParseMultiCommentEnter != null)
				onParseMultiCommentEnter(currentCommand);

ParseMultiComment:
			if (onParseMultiCommentState != null)
				onParseMultiCommentState(currentCommand);
ResumeParseMultiComment:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '*':
					if (onParseMultiCommentExit != null)
						onParseMultiCommentExit(currentCommand);
					goto EnterTestEndMultiComment;
				default:
					goto ParseMultiComment;
			}

EnterTestEndMultiComment:
			state = States.TestEndMultiComment;
			if (onTestEndMultiCommentEnter != null)
				onTestEndMultiCommentEnter(currentCommand);

			if (onTestEndMultiCommentState != null)
				onTestEndMultiCommentState(currentCommand);
ResumeTestEndMultiComment:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '/':
					if (onTestEndMultiCommentExit != null)
						onTestEndMultiCommentExit(currentCommand);
					goto EnterEndComment;
				default:
					if (onTestEndMultiCommentExit != null)
						onTestEndMultiCommentExit(currentCommand);
					goto EnterParseMultiComment;
			}

EnterEndComment:
			state = States.EndComment;
			if (onEndCommentEnter != null)
				onEndCommentEnter(currentCommand);

			if (onEndCommentState != null)
				onEndCommentState(currentCommand);
ResumeEndComment:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '\'':
					if (onEndCommentExit != null)
						onEndCommentExit(currentCommand);
					goto EnterParseSingleQuotes;
				case '"':
					if (onEndCommentExit != null)
						onEndCommentExit(currentCommand);
					goto EnterParseDoubleQuotes;
				case '/':
					if (onEndCommentExit != null)
						onEndCommentExit(currentCommand);
					goto EnterParseCommentType;
				default:
					if (onEndCommentExit != null)
						onEndCommentExit(currentCommand);
					goto EnterParse;
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
					goto EnterParse;
				case false:
			if (onParseSingleQuotesExit != null)
						onParseSingleQuotesExit(ParseSingleQuotesMachine.CurrentCommand);
					goto EnterIllegalSingleQuotes;
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
					goto EnterParse;
				case false:
			if (onParseDoubleQuotesExit != null)
						onParseDoubleQuotesExit(ParseDoubleQuotesMachine.CurrentCommand);
					goto EnterIllegalDoubleQuotes;
			}

EnterIllegalCommentType:
			state = States.IllegalCommentType;
			if (onIllegalCommentTypeEnter != null)
				onIllegalCommentTypeEnter(currentCommand);

			if (onIllegalCommentTypeState != null)
				onIllegalCommentTypeState(currentCommand);
ResumeIllegalCommentType:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalCommentTypeExit != null)
						onIllegalCommentTypeExit(currentCommand);
					goto Decline;
			}

EnterIllegalSingleQuotes:
			state = States.IllegalSingleQuotes;
			if (onIllegalSingleQuotesEnter != null)
				onIllegalSingleQuotesEnter(currentCommand);

			if (onIllegalSingleQuotesState != null)
				onIllegalSingleQuotesState(currentCommand);
ResumeIllegalSingleQuotes:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalSingleQuotesExit != null)
						onIllegalSingleQuotesExit(currentCommand);
					goto Decline;
			}

EnterIllegalDoubleQuotes:
			state = States.IllegalDoubleQuotes;
			if (onIllegalDoubleQuotesEnter != null)
				onIllegalDoubleQuotesEnter(currentCommand);

			if (onIllegalDoubleQuotesState != null)
				onIllegalDoubleQuotesState(currentCommand);
ResumeIllegalDoubleQuotes:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalDoubleQuotesExit != null)
						onIllegalDoubleQuotesExit(currentCommand);
					goto Decline;
			}

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

		public void AddOnParse(Action<char> addedFunc)
		{
			onParseState += addedFunc;
		}

		public void AddOnParseCommentType(Action<char> addedFunc)
		{
			onParseCommentTypeState += addedFunc;
		}

		public void AddOnParseSingleComment(Action<char> addedFunc)
		{
			onParseSingleCommentState += addedFunc;
		}

		public void AddOnParseMultiComment(Action<char> addedFunc)
		{
			onParseMultiCommentState += addedFunc;
		}

		public void AddOnTestEndMultiComment(Action<char> addedFunc)
		{
			onTestEndMultiCommentState += addedFunc;
		}

		public void AddOnEndComment(Action<char> addedFunc)
		{
			onEndCommentState += addedFunc;
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

		public void AddOnIllegalCommentType(Action<char> addedFunc)
		{
			onIllegalCommentTypeState += addedFunc;
		}

		public void AddOnIllegalSingleQuotes(Action<char> addedFunc)
		{
			onIllegalSingleQuotesState += addedFunc;
		}

		public void AddOnIllegalDoubleQuotes(Action<char> addedFunc)
		{
			onIllegalDoubleQuotesState += addedFunc;
		}

		public void AddOnParseEnter(Action<char> addedFunc)
		{
			onParseEnter += addedFunc;
		}

		public void AddOnParseCommentTypeEnter(Action<char> addedFunc)
		{
			onParseCommentTypeEnter += addedFunc;
		}

		public void AddOnParseSingleCommentEnter(Action<char> addedFunc)
		{
			onParseSingleCommentEnter += addedFunc;
		}

		public void AddOnParseMultiCommentEnter(Action<char> addedFunc)
		{
			onParseMultiCommentEnter += addedFunc;
		}

		public void AddOnTestEndMultiCommentEnter(Action<char> addedFunc)
		{
			onTestEndMultiCommentEnter += addedFunc;
		}

		public void AddOnEndCommentEnter(Action<char> addedFunc)
		{
			onEndCommentEnter += addedFunc;
		}

		public void AddOnParseSingleQuotesEnter(Action<char> addedFunc)
		{
			onParseSingleQuotesEnter += addedFunc;
		}

		public void AddOnParseDoubleQuotesEnter(Action<char> addedFunc)
		{
			onParseDoubleQuotesEnter += addedFunc;
		}

		public void AddOnIllegalCommentTypeEnter(Action<char> addedFunc)
		{
			onIllegalCommentTypeEnter += addedFunc;
		}

		public void AddOnIllegalSingleQuotesEnter(Action<char> addedFunc)
		{
			onIllegalSingleQuotesEnter += addedFunc;
		}

		public void AddOnIllegalDoubleQuotesEnter(Action<char> addedFunc)
		{
			onIllegalDoubleQuotesEnter += addedFunc;
		}

		public void AddOnParseExit(Action<char> addedFunc)
		{
			onParseExit += addedFunc;
		}

		public void AddOnParseCommentTypeExit(Action<char> addedFunc)
		{
			onParseCommentTypeExit += addedFunc;
		}

		public void AddOnParseSingleCommentExit(Action<char> addedFunc)
		{
			onParseSingleCommentExit += addedFunc;
		}

		public void AddOnParseMultiCommentExit(Action<char> addedFunc)
		{
			onParseMultiCommentExit += addedFunc;
		}

		public void AddOnTestEndMultiCommentExit(Action<char> addedFunc)
		{
			onTestEndMultiCommentExit += addedFunc;
		}

		public void AddOnEndCommentExit(Action<char> addedFunc)
		{
			onEndCommentExit += addedFunc;
		}

		public void AddOnParseSingleQuotesExit(Action<char> addedFunc)
		{
			onParseSingleQuotesExit += addedFunc;
		}

		public void AddOnParseDoubleQuotesExit(Action<char> addedFunc)
		{
			onParseDoubleQuotesExit += addedFunc;
		}

		public void AddOnIllegalCommentTypeExit(Action<char> addedFunc)
		{
			onIllegalCommentTypeExit += addedFunc;
		}

		public void AddOnIllegalSingleQuotesExit(Action<char> addedFunc)
		{
			onIllegalSingleQuotesExit += addedFunc;
		}

		public void AddOnIllegalDoubleQuotesExit(Action<char> addedFunc)
		{
			onIllegalDoubleQuotesExit += addedFunc;
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
			onParseState += addedFunc;
			onParseCommentTypeState += addedFunc;
			onParseSingleCommentState += addedFunc;
			onParseMultiCommentState += addedFunc;
			onTestEndMultiCommentState += addedFunc;
			onEndCommentState += addedFunc;
			AddOnParseSingleQuotes(addedFunc);
			AddOnParseDoubleQuotes(addedFunc);
			onIllegalCommentTypeState += addedFunc;
			onIllegalSingleQuotesState += addedFunc;
			onIllegalDoubleQuotesState += addedFunc;
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
