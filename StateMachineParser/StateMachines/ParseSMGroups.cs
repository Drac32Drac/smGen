// ************************ ParseSMGroups : char ************************
// 
// 	group whitespace		= { ' ', '\t', '\r', '\n' }
// 	group alphaNumeric		= { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
// 			'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
// 			'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
// 			'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
// 			'8', '9', '_', '.' }
// 	ParseGroupDeclaration	: ParseSMGroupDeclaration ? PreGroupName : ParseGroupDeclaration;
// 	PreGroupName		: whitespace = PreGroupName, alphaNumeric = GroupName,
// 			default = IllegalGroupNameChar;
// 	GroupName			: whitespace = PostGroupName, alphaNumeric = GroupName,
// 			'=' = PreGroup, '{' = MissingGroupEquals, default = IllegalGroupTokenEquals;
// 	PostGroupName		: whitespace = PostGroupName, '=' = PreGroup, '{' = MissingGroupEquals,
// 			alphaNumeric = MissingGroupEquals, default = IllegalGroupTokenEquals;
// 	PreGroup			: whitespace = PreGroup, '{' = GroupBraces,
// 			default = IllegalGroupStart;
// 	GroupBraces			: whitespace = GroupBraces, '\'' = ItemSingleQuotes,
// 			'"' = ItemDoubleQuotes, '}' = PostGroup, alphaNumeric = GroupItem,
// 			default = IllegalGroupItemChar;
// 	GroupItem			: whitespace = PostGroupItem, '}' = PostGroup, ',' = ItemSeparator,
// 			alphaNumeric = GroupItem, default = IllegalGroupItemChar;
// 		
// 	ItemSingleQuotes	: ParseSingleQuotes ? PostGroupItem : decline;
// 	ItemDoubleQuotes	: ParseDoubleQuotes ? PostGroupItem	: decline;
// 	PostGroupItem		: whitespace = PostGroupItem, '}' = PostGroup, ',' = ItemSeparator,
// 			alphaNumeric = MissingGroupItemDelimeter, default = IllegalGroupItemChar;
// 	ItemSeparator		: whitespace = ItemSeparator, alphaNumeric = GroupItem,
// 			'\'' = ItemSingleQuotes, '"' = ItemDoubleQuotes, default = IllegalGroupItemChar;
// 	PostGroup			: default = ParseGroupDeclaration;
// 		
// 	IllegalGroupNameChar		: default = decline;
// 	IllegalGroupTokenEquals		: default = decline;
// 	IllegalGroupStart			: default = decline;
// 	IllegalGroupItemChar		: default = decline;
// 	MissingGroupEquals			: default = decline;
// 	MissingGroupItemDelimeter	: default = decline;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class ParseSMGroups
	{
		public enum States
		{
			ParseGroupDeclaration = 0, 	PreGroupName = 1, 
			GroupName = 2, 	PostGroupName = 3, 
			PreGroup = 4, 	GroupBraces = 5, 
			GroupItem = 6, 	ItemSingleQuotes = 7, 
			ItemDoubleQuotes = 8, 	PostGroupItem = 9, 
			ItemSeparator = 10, 	PostGroup = 11, 
			IllegalGroupNameChar = 12, 	IllegalGroupTokenEquals = 13, 
			IllegalGroupStart = 14, 	IllegalGroupItemChar = 15, 
			MissingGroupEquals = 16, 	MissingGroupItemDelimeter = 17, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onParseGroupDeclarationState = null;
		private Action<char> onParseGroupDeclarationEnter = null;
		private Action<char> onParseGroupDeclarationExit = null;
		private Action<char> onPreGroupNameState = null;
		private Action<char> onPreGroupNameEnter = null;
		private Action<char> onPreGroupNameExit = null;
		private Action<char> onGroupNameState = null;
		private Action<char> onGroupNameEnter = null;
		private Action<char> onGroupNameExit = null;
		private Action<char> onPostGroupNameState = null;
		private Action<char> onPostGroupNameEnter = null;
		private Action<char> onPostGroupNameExit = null;
		private Action<char> onPreGroupState = null;
		private Action<char> onPreGroupEnter = null;
		private Action<char> onPreGroupExit = null;
		private Action<char> onGroupBracesState = null;
		private Action<char> onGroupBracesEnter = null;
		private Action<char> onGroupBracesExit = null;
		private Action<char> onGroupItemState = null;
		private Action<char> onGroupItemEnter = null;
		private Action<char> onGroupItemExit = null;
		private Action<char> onItemSingleQuotesState = null;
		private Action<char> onItemSingleQuotesEnter = null;
		private Action<char> onItemSingleQuotesExit = null;
		private Action<char> onItemDoubleQuotesState = null;
		private Action<char> onItemDoubleQuotesEnter = null;
		private Action<char> onItemDoubleQuotesExit = null;
		private Action<char> onPostGroupItemState = null;
		private Action<char> onPostGroupItemEnter = null;
		private Action<char> onPostGroupItemExit = null;
		private Action<char> onItemSeparatorState = null;
		private Action<char> onItemSeparatorEnter = null;
		private Action<char> onItemSeparatorExit = null;
		private Action<char> onPostGroupState = null;
		private Action<char> onPostGroupEnter = null;
		private Action<char> onPostGroupExit = null;
		private Action<char> onIllegalGroupNameCharState = null;
		private Action<char> onIllegalGroupNameCharEnter = null;
		private Action<char> onIllegalGroupNameCharExit = null;
		private Action<char> onIllegalGroupTokenEqualsState = null;
		private Action<char> onIllegalGroupTokenEqualsEnter = null;
		private Action<char> onIllegalGroupTokenEqualsExit = null;
		private Action<char> onIllegalGroupStartState = null;
		private Action<char> onIllegalGroupStartEnter = null;
		private Action<char> onIllegalGroupStartExit = null;
		private Action<char> onIllegalGroupItemCharState = null;
		private Action<char> onIllegalGroupItemCharEnter = null;
		private Action<char> onIllegalGroupItemCharExit = null;
		private Action<char> onMissingGroupEqualsState = null;
		private Action<char> onMissingGroupEqualsEnter = null;
		private Action<char> onMissingGroupEqualsExit = null;
		private Action<char> onMissingGroupItemDelimeterState = null;
		private Action<char> onMissingGroupItemDelimeterEnter = null;
		private Action<char> onMissingGroupItemDelimeterExit = null;
		private Action<char> onAccept = null;
		private Action<char> onDecline = null;
		private Action<char> onEnd = null;

		public readonly ParseSMGroupDeclaration ParseGroupDeclarationMachine = new ParseSMGroupDeclaration();
		public readonly ParseSingleQuotes ItemSingleQuotesMachine = new ParseSingleQuotes();
		public readonly ParseDoubleQuotes ItemDoubleQuotesMachine = new ParseDoubleQuotes();

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
						state = States.ParseGroupDeclaration;
						goto ResumeParseGroupDeclaration;
					}
					else
						goto End;
				case States.ParseGroupDeclaration:
					goto ResumeParseGroupDeclaration;
				case States.PreGroupName:
					goto ResumePreGroupName;
				case States.GroupName:
					goto ResumeGroupName;
				case States.PostGroupName:
					goto ResumePostGroupName;
				case States.PreGroup:
					goto ResumePreGroup;
				case States.GroupBraces:
					goto ResumeGroupBraces;
				case States.GroupItem:
					goto ResumeGroupItem;
				case States.ItemSingleQuotes:
					goto ResumeItemSingleQuotes;
				case States.ItemDoubleQuotes:
					goto ResumeItemDoubleQuotes;
				case States.PostGroupItem:
					goto ResumePostGroupItem;
				case States.ItemSeparator:
					goto ResumeItemSeparator;
				case States.PostGroup:
					goto ResumePostGroup;
				case States.IllegalGroupNameChar:
					goto ResumeIllegalGroupNameChar;
				case States.IllegalGroupTokenEquals:
					goto ResumeIllegalGroupTokenEquals;
				case States.IllegalGroupStart:
					goto ResumeIllegalGroupStart;
				case States.IllegalGroupItemChar:
					goto ResumeIllegalGroupItemChar;
				case States.MissingGroupEquals:
					goto ResumeMissingGroupEquals;
				case States.MissingGroupItemDelimeter:
					goto ResumeMissingGroupItemDelimeter;
			}


EnterParseGroupDeclaration:
			state = States.ParseGroupDeclaration;
			if (onParseGroupDeclarationEnter != null)
				onParseGroupDeclarationEnter(currentCommand);

ParseGroupDeclaration:
			if (onParseGroupDeclarationState != null)
				onParseGroupDeclarationState(currentCommand);
ResumeParseGroupDeclaration:
			nestResult = ParseGroupDeclarationMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onParseGroupDeclarationExit != null)
						onParseGroupDeclarationExit(ParseGroupDeclarationMachine.CurrentCommand);
					goto EnterPreGroupName;
				case false:
					goto ParseGroupDeclaration;
			}

EnterPreGroupName:
			state = States.PreGroupName;
			if (onPreGroupNameEnter != null)
				onPreGroupNameEnter(currentCommand);

PreGroupName:
			if (onPreGroupNameState != null)
				onPreGroupNameState(currentCommand);
ResumePreGroupName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreGroupName;
				case '\t':
					goto PreGroupName;
				case '\r':
					goto PreGroupName;
				case '\n':
					goto PreGroupName;
				case 'a':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'b':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'c':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'd':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'e':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'f':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'g':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'h':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'i':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'j':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'k':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'l':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'm':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'n':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'o':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'p':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'q':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'r':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 's':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 't':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'u':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'v':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'w':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'x':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'y':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'z':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'A':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'B':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'C':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'D':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'E':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'F':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'G':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'H':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'I':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'J':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'K':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'L':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'M':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'N':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'O':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'P':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'Q':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'R':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'S':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'T':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'U':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'V':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'W':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'X':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'Y':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case 'Z':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '0':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '1':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '2':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '3':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '4':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '5':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '6':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '7':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '8':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '9':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '_':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				case '.':
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterGroupName;
				default:
					if (onPreGroupNameExit != null)
						onPreGroupNameExit(currentCommand);
					goto EnterIllegalGroupNameChar;
			}

EnterGroupName:
			state = States.GroupName;
			if (onGroupNameEnter != null)
				onGroupNameEnter(currentCommand);

GroupName:
			if (onGroupNameState != null)
				onGroupNameState(currentCommand);
ResumeGroupName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterPostGroupName;
				case '\t':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterPostGroupName;
				case '\r':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterPostGroupName;
				case '\n':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterPostGroupName;
				case 'a':
					goto GroupName;
				case 'b':
					goto GroupName;
				case 'c':
					goto GroupName;
				case 'd':
					goto GroupName;
				case 'e':
					goto GroupName;
				case 'f':
					goto GroupName;
				case 'g':
					goto GroupName;
				case 'h':
					goto GroupName;
				case 'i':
					goto GroupName;
				case 'j':
					goto GroupName;
				case 'k':
					goto GroupName;
				case 'l':
					goto GroupName;
				case 'm':
					goto GroupName;
				case 'n':
					goto GroupName;
				case 'o':
					goto GroupName;
				case 'p':
					goto GroupName;
				case 'q':
					goto GroupName;
				case 'r':
					goto GroupName;
				case 's':
					goto GroupName;
				case 't':
					goto GroupName;
				case 'u':
					goto GroupName;
				case 'v':
					goto GroupName;
				case 'w':
					goto GroupName;
				case 'x':
					goto GroupName;
				case 'y':
					goto GroupName;
				case 'z':
					goto GroupName;
				case 'A':
					goto GroupName;
				case 'B':
					goto GroupName;
				case 'C':
					goto GroupName;
				case 'D':
					goto GroupName;
				case 'E':
					goto GroupName;
				case 'F':
					goto GroupName;
				case 'G':
					goto GroupName;
				case 'H':
					goto GroupName;
				case 'I':
					goto GroupName;
				case 'J':
					goto GroupName;
				case 'K':
					goto GroupName;
				case 'L':
					goto GroupName;
				case 'M':
					goto GroupName;
				case 'N':
					goto GroupName;
				case 'O':
					goto GroupName;
				case 'P':
					goto GroupName;
				case 'Q':
					goto GroupName;
				case 'R':
					goto GroupName;
				case 'S':
					goto GroupName;
				case 'T':
					goto GroupName;
				case 'U':
					goto GroupName;
				case 'V':
					goto GroupName;
				case 'W':
					goto GroupName;
				case 'X':
					goto GroupName;
				case 'Y':
					goto GroupName;
				case 'Z':
					goto GroupName;
				case '0':
					goto GroupName;
				case '1':
					goto GroupName;
				case '2':
					goto GroupName;
				case '3':
					goto GroupName;
				case '4':
					goto GroupName;
				case '5':
					goto GroupName;
				case '6':
					goto GroupName;
				case '7':
					goto GroupName;
				case '8':
					goto GroupName;
				case '9':
					goto GroupName;
				case '_':
					goto GroupName;
				case '.':
					goto GroupName;
				case '=':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterPreGroup;
				case '{':
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				default:
					if (onGroupNameExit != null)
						onGroupNameExit(currentCommand);
					goto EnterIllegalGroupTokenEquals;
			}

EnterPostGroupName:
			state = States.PostGroupName;
			if (onPostGroupNameEnter != null)
				onPostGroupNameEnter(currentCommand);

PostGroupName:
			if (onPostGroupNameState != null)
				onPostGroupNameState(currentCommand);
ResumePostGroupName:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostGroupName;
				case '\t':
					goto PostGroupName;
				case '\r':
					goto PostGroupName;
				case '\n':
					goto PostGroupName;
				case '=':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterPreGroup;
				case '{':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'a':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'b':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'c':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'd':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'e':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'f':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'g':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'h':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'i':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'j':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'k':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'l':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'm':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'n':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'o':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'p':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'q':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'r':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 's':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 't':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'u':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'v':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'w':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'x':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'y':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'z':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'A':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'B':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'C':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'D':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'E':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'F':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'G':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'H':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'I':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'J':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'K':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'L':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'M':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'N':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'O':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'P':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'Q':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'R':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'S':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'T':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'U':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'V':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'W':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'X':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'Y':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case 'Z':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '0':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '1':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '2':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '3':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '4':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '5':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '6':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '7':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '8':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '9':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '_':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				case '.':
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterMissingGroupEquals;
				default:
					if (onPostGroupNameExit != null)
						onPostGroupNameExit(currentCommand);
					goto EnterIllegalGroupTokenEquals;
			}

EnterPreGroup:
			state = States.PreGroup;
			if (onPreGroupEnter != null)
				onPreGroupEnter(currentCommand);

PreGroup:
			if (onPreGroupState != null)
				onPreGroupState(currentCommand);
ResumePreGroup:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PreGroup;
				case '\t':
					goto PreGroup;
				case '\r':
					goto PreGroup;
				case '\n':
					goto PreGroup;
				case '{':
					if (onPreGroupExit != null)
						onPreGroupExit(currentCommand);
					goto EnterGroupBraces;
				default:
					if (onPreGroupExit != null)
						onPreGroupExit(currentCommand);
					goto EnterIllegalGroupStart;
			}

EnterGroupBraces:
			state = States.GroupBraces;
			if (onGroupBracesEnter != null)
				onGroupBracesEnter(currentCommand);

GroupBraces:
			if (onGroupBracesState != null)
				onGroupBracesState(currentCommand);
ResumeGroupBraces:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto GroupBraces;
				case '\t':
					goto GroupBraces;
				case '\r':
					goto GroupBraces;
				case '\n':
					goto GroupBraces;
				case '\'':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterItemSingleQuotes;
				case '"':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterItemDoubleQuotes;
				case '}':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterPostGroup;
				case 'a':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'b':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'c':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'd':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'e':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'f':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'g':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'h':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'i':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'j':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'k':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'l':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'm':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'n':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'o':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'p':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'q':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'r':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 's':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 't':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'u':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'v':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'w':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'x':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'y':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'z':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'A':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'B':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'C':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'D':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'E':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'F':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'G':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'H':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'I':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'J':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'K':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'L':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'M':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'N':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'O':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'P':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'Q':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'R':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'S':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'T':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'U':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'V':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'W':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'X':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'Y':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case 'Z':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '0':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '1':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '2':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '3':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '4':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '5':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '6':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '7':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '8':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '9':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '_':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				case '.':
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterGroupItem;
				default:
					if (onGroupBracesExit != null)
						onGroupBracesExit(currentCommand);
					goto EnterIllegalGroupItemChar;
			}

EnterGroupItem:
			state = States.GroupItem;
			if (onGroupItemEnter != null)
				onGroupItemEnter(currentCommand);

GroupItem:
			if (onGroupItemState != null)
				onGroupItemState(currentCommand);
ResumeGroupItem:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterPostGroupItem;
				case '\t':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterPostGroupItem;
				case '\r':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterPostGroupItem;
				case '\n':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterPostGroupItem;
				case '}':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterPostGroup;
				case ',':
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterItemSeparator;
				case 'a':
					goto GroupItem;
				case 'b':
					goto GroupItem;
				case 'c':
					goto GroupItem;
				case 'd':
					goto GroupItem;
				case 'e':
					goto GroupItem;
				case 'f':
					goto GroupItem;
				case 'g':
					goto GroupItem;
				case 'h':
					goto GroupItem;
				case 'i':
					goto GroupItem;
				case 'j':
					goto GroupItem;
				case 'k':
					goto GroupItem;
				case 'l':
					goto GroupItem;
				case 'm':
					goto GroupItem;
				case 'n':
					goto GroupItem;
				case 'o':
					goto GroupItem;
				case 'p':
					goto GroupItem;
				case 'q':
					goto GroupItem;
				case 'r':
					goto GroupItem;
				case 's':
					goto GroupItem;
				case 't':
					goto GroupItem;
				case 'u':
					goto GroupItem;
				case 'v':
					goto GroupItem;
				case 'w':
					goto GroupItem;
				case 'x':
					goto GroupItem;
				case 'y':
					goto GroupItem;
				case 'z':
					goto GroupItem;
				case 'A':
					goto GroupItem;
				case 'B':
					goto GroupItem;
				case 'C':
					goto GroupItem;
				case 'D':
					goto GroupItem;
				case 'E':
					goto GroupItem;
				case 'F':
					goto GroupItem;
				case 'G':
					goto GroupItem;
				case 'H':
					goto GroupItem;
				case 'I':
					goto GroupItem;
				case 'J':
					goto GroupItem;
				case 'K':
					goto GroupItem;
				case 'L':
					goto GroupItem;
				case 'M':
					goto GroupItem;
				case 'N':
					goto GroupItem;
				case 'O':
					goto GroupItem;
				case 'P':
					goto GroupItem;
				case 'Q':
					goto GroupItem;
				case 'R':
					goto GroupItem;
				case 'S':
					goto GroupItem;
				case 'T':
					goto GroupItem;
				case 'U':
					goto GroupItem;
				case 'V':
					goto GroupItem;
				case 'W':
					goto GroupItem;
				case 'X':
					goto GroupItem;
				case 'Y':
					goto GroupItem;
				case 'Z':
					goto GroupItem;
				case '0':
					goto GroupItem;
				case '1':
					goto GroupItem;
				case '2':
					goto GroupItem;
				case '3':
					goto GroupItem;
				case '4':
					goto GroupItem;
				case '5':
					goto GroupItem;
				case '6':
					goto GroupItem;
				case '7':
					goto GroupItem;
				case '8':
					goto GroupItem;
				case '9':
					goto GroupItem;
				case '_':
					goto GroupItem;
				case '.':
					goto GroupItem;
				default:
					if (onGroupItemExit != null)
						onGroupItemExit(currentCommand);
					goto EnterIllegalGroupItemChar;
			}

EnterItemSingleQuotes:
			state = States.ItemSingleQuotes;
			if (onItemSingleQuotesEnter != null)
				onItemSingleQuotesEnter(currentCommand);

			if (onItemSingleQuotesState != null)
				onItemSingleQuotesState(currentCommand);
ResumeItemSingleQuotes:
			nestResult = ItemSingleQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onItemSingleQuotesExit != null)
						onItemSingleQuotesExit(ItemSingleQuotesMachine.CurrentCommand);
					goto EnterPostGroupItem;
				case false:
			if (onItemSingleQuotesExit != null)
						onItemSingleQuotesExit(ItemSingleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterItemDoubleQuotes:
			state = States.ItemDoubleQuotes;
			if (onItemDoubleQuotesEnter != null)
				onItemDoubleQuotesEnter(currentCommand);

			if (onItemDoubleQuotesState != null)
				onItemDoubleQuotesState(currentCommand);
ResumeItemDoubleQuotes:
			nestResult = ItemDoubleQuotesMachine.Input(data);
			switch (nestResult)
			{
				case null:
					goto End;
				case true:
					if (onItemDoubleQuotesExit != null)
						onItemDoubleQuotesExit(ItemDoubleQuotesMachine.CurrentCommand);
					goto EnterPostGroupItem;
				case false:
			if (onItemDoubleQuotesExit != null)
						onItemDoubleQuotesExit(ItemDoubleQuotesMachine.CurrentCommand);
					goto Decline;
			}

EnterPostGroupItem:
			state = States.PostGroupItem;
			if (onPostGroupItemEnter != null)
				onPostGroupItemEnter(currentCommand);

PostGroupItem:
			if (onPostGroupItemState != null)
				onPostGroupItemState(currentCommand);
ResumePostGroupItem:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto PostGroupItem;
				case '\t':
					goto PostGroupItem;
				case '\r':
					goto PostGroupItem;
				case '\n':
					goto PostGroupItem;
				case '}':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterPostGroup;
				case ',':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterItemSeparator;
				case 'a':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'b':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'c':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'd':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'e':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'f':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'g':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'h':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'i':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'j':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'k':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'l':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'm':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'n':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'o':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'p':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'q':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'r':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 's':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 't':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'u':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'v':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'w':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'x':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'y':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'z':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'A':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'B':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'C':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'D':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'E':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'F':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'G':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'H':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'I':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'J':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'K':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'L':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'M':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'N':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'O':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'P':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'Q':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'R':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'S':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'T':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'U':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'V':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'W':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'X':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'Y':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case 'Z':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '0':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '1':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '2':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '3':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '4':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '5':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '6':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '7':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '8':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '9':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '_':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				case '.':
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterMissingGroupItemDelimeter;
				default:
					if (onPostGroupItemExit != null)
						onPostGroupItemExit(currentCommand);
					goto EnterIllegalGroupItemChar;
			}

EnterItemSeparator:
			state = States.ItemSeparator;
			if (onItemSeparatorEnter != null)
				onItemSeparatorEnter(currentCommand);

ItemSeparator:
			if (onItemSeparatorState != null)
				onItemSeparatorState(currentCommand);
ResumeItemSeparator:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case ' ':
					goto ItemSeparator;
				case '\t':
					goto ItemSeparator;
				case '\r':
					goto ItemSeparator;
				case '\n':
					goto ItemSeparator;
				case 'a':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'b':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'c':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'd':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'e':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'f':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'g':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'h':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'i':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'j':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'k':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'l':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'm':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'n':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'o':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'p':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'q':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'r':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 's':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 't':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'u':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'v':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'w':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'x':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'y':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'z':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'A':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'B':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'C':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'D':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'E':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'F':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'G':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'H':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'I':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'J':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'K':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'L':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'M':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'N':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'O':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'P':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'Q':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'R':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'S':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'T':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'U':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'V':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'W':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'X':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'Y':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case 'Z':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '0':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '1':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '2':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '3':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '4':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '5':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '6':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '7':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '8':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '9':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '_':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '.':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterGroupItem;
				case '\'':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterItemSingleQuotes;
				case '"':
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterItemDoubleQuotes;
				default:
					if (onItemSeparatorExit != null)
						onItemSeparatorExit(currentCommand);
					goto EnterIllegalGroupItemChar;
			}

EnterPostGroup:
			state = States.PostGroup;
			if (onPostGroupEnter != null)
				onPostGroupEnter(currentCommand);

			if (onPostGroupState != null)
				onPostGroupState(currentCommand);
ResumePostGroup:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onPostGroupExit != null)
						onPostGroupExit(currentCommand);
					goto EnterParseGroupDeclaration;
			}

EnterIllegalGroupNameChar:
			state = States.IllegalGroupNameChar;
			if (onIllegalGroupNameCharEnter != null)
				onIllegalGroupNameCharEnter(currentCommand);

			if (onIllegalGroupNameCharState != null)
				onIllegalGroupNameCharState(currentCommand);
ResumeIllegalGroupNameChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalGroupNameCharExit != null)
						onIllegalGroupNameCharExit(currentCommand);
					goto Decline;
			}

EnterIllegalGroupTokenEquals:
			state = States.IllegalGroupTokenEquals;
			if (onIllegalGroupTokenEqualsEnter != null)
				onIllegalGroupTokenEqualsEnter(currentCommand);

			if (onIllegalGroupTokenEqualsState != null)
				onIllegalGroupTokenEqualsState(currentCommand);
ResumeIllegalGroupTokenEquals:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalGroupTokenEqualsExit != null)
						onIllegalGroupTokenEqualsExit(currentCommand);
					goto Decline;
			}

EnterIllegalGroupStart:
			state = States.IllegalGroupStart;
			if (onIllegalGroupStartEnter != null)
				onIllegalGroupStartEnter(currentCommand);

			if (onIllegalGroupStartState != null)
				onIllegalGroupStartState(currentCommand);
ResumeIllegalGroupStart:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalGroupStartExit != null)
						onIllegalGroupStartExit(currentCommand);
					goto Decline;
			}

EnterIllegalGroupItemChar:
			state = States.IllegalGroupItemChar;
			if (onIllegalGroupItemCharEnter != null)
				onIllegalGroupItemCharEnter(currentCommand);

			if (onIllegalGroupItemCharState != null)
				onIllegalGroupItemCharState(currentCommand);
ResumeIllegalGroupItemChar:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onIllegalGroupItemCharExit != null)
						onIllegalGroupItemCharExit(currentCommand);
					goto Decline;
			}

EnterMissingGroupEquals:
			state = States.MissingGroupEquals;
			if (onMissingGroupEqualsEnter != null)
				onMissingGroupEqualsEnter(currentCommand);

			if (onMissingGroupEqualsState != null)
				onMissingGroupEqualsState(currentCommand);
ResumeMissingGroupEquals:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingGroupEqualsExit != null)
						onMissingGroupEqualsExit(currentCommand);
					goto Decline;
			}

EnterMissingGroupItemDelimeter:
			state = States.MissingGroupItemDelimeter;
			if (onMissingGroupItemDelimeterEnter != null)
				onMissingGroupItemDelimeterEnter(currentCommand);

			if (onMissingGroupItemDelimeterState != null)
				onMissingGroupItemDelimeterState(currentCommand);
ResumeMissingGroupItemDelimeter:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onMissingGroupItemDelimeterExit != null)
						onMissingGroupItemDelimeterExit(currentCommand);
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

		public void AddOnParseGroupDeclaration(Action<char> addedFunc)
		{
			AddOnParseGroupDeclarationEnter(addedFunc);
			ParseGroupDeclarationMachine.addOnAllStates(addedFunc);
		}

		public void AddOnPreGroupName(Action<char> addedFunc)
		{
			onPreGroupNameState += addedFunc;
		}

		public void AddOnGroupName(Action<char> addedFunc)
		{
			onGroupNameState += addedFunc;
		}

		public void AddOnPostGroupName(Action<char> addedFunc)
		{
			onPostGroupNameState += addedFunc;
		}

		public void AddOnPreGroup(Action<char> addedFunc)
		{
			onPreGroupState += addedFunc;
		}

		public void AddOnGroupBraces(Action<char> addedFunc)
		{
			onGroupBracesState += addedFunc;
		}

		public void AddOnGroupItem(Action<char> addedFunc)
		{
			onGroupItemState += addedFunc;
		}

		public void AddOnItemSingleQuotes(Action<char> addedFunc)
		{
			AddOnItemSingleQuotesEnter(addedFunc);
			ItemSingleQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnItemDoubleQuotes(Action<char> addedFunc)
		{
			AddOnItemDoubleQuotesEnter(addedFunc);
			ItemDoubleQuotesMachine.addOnAllStates(addedFunc);
		}

		public void AddOnPostGroupItem(Action<char> addedFunc)
		{
			onPostGroupItemState += addedFunc;
		}

		public void AddOnItemSeparator(Action<char> addedFunc)
		{
			onItemSeparatorState += addedFunc;
		}

		public void AddOnPostGroup(Action<char> addedFunc)
		{
			onPostGroupState += addedFunc;
		}

		public void AddOnIllegalGroupNameChar(Action<char> addedFunc)
		{
			onIllegalGroupNameCharState += addedFunc;
		}

		public void AddOnIllegalGroupTokenEquals(Action<char> addedFunc)
		{
			onIllegalGroupTokenEqualsState += addedFunc;
		}

		public void AddOnIllegalGroupStart(Action<char> addedFunc)
		{
			onIllegalGroupStartState += addedFunc;
		}

		public void AddOnIllegalGroupItemChar(Action<char> addedFunc)
		{
			onIllegalGroupItemCharState += addedFunc;
		}

		public void AddOnMissingGroupEquals(Action<char> addedFunc)
		{
			onMissingGroupEqualsState += addedFunc;
		}

		public void AddOnMissingGroupItemDelimeter(Action<char> addedFunc)
		{
			onMissingGroupItemDelimeterState += addedFunc;
		}

		public void AddOnParseGroupDeclarationEnter(Action<char> addedFunc)
		{
			onParseGroupDeclarationEnter += addedFunc;
		}

		public void AddOnPreGroupNameEnter(Action<char> addedFunc)
		{
			onPreGroupNameEnter += addedFunc;
		}

		public void AddOnGroupNameEnter(Action<char> addedFunc)
		{
			onGroupNameEnter += addedFunc;
		}

		public void AddOnPostGroupNameEnter(Action<char> addedFunc)
		{
			onPostGroupNameEnter += addedFunc;
		}

		public void AddOnPreGroupEnter(Action<char> addedFunc)
		{
			onPreGroupEnter += addedFunc;
		}

		public void AddOnGroupBracesEnter(Action<char> addedFunc)
		{
			onGroupBracesEnter += addedFunc;
		}

		public void AddOnGroupItemEnter(Action<char> addedFunc)
		{
			onGroupItemEnter += addedFunc;
		}

		public void AddOnItemSingleQuotesEnter(Action<char> addedFunc)
		{
			onItemSingleQuotesEnter += addedFunc;
		}

		public void AddOnItemDoubleQuotesEnter(Action<char> addedFunc)
		{
			onItemDoubleQuotesEnter += addedFunc;
		}

		public void AddOnPostGroupItemEnter(Action<char> addedFunc)
		{
			onPostGroupItemEnter += addedFunc;
		}

		public void AddOnItemSeparatorEnter(Action<char> addedFunc)
		{
			onItemSeparatorEnter += addedFunc;
		}

		public void AddOnPostGroupEnter(Action<char> addedFunc)
		{
			onPostGroupEnter += addedFunc;
		}

		public void AddOnIllegalGroupNameCharEnter(Action<char> addedFunc)
		{
			onIllegalGroupNameCharEnter += addedFunc;
		}

		public void AddOnIllegalGroupTokenEqualsEnter(Action<char> addedFunc)
		{
			onIllegalGroupTokenEqualsEnter += addedFunc;
		}

		public void AddOnIllegalGroupStartEnter(Action<char> addedFunc)
		{
			onIllegalGroupStartEnter += addedFunc;
		}

		public void AddOnIllegalGroupItemCharEnter(Action<char> addedFunc)
		{
			onIllegalGroupItemCharEnter += addedFunc;
		}

		public void AddOnMissingGroupEqualsEnter(Action<char> addedFunc)
		{
			onMissingGroupEqualsEnter += addedFunc;
		}

		public void AddOnMissingGroupItemDelimeterEnter(Action<char> addedFunc)
		{
			onMissingGroupItemDelimeterEnter += addedFunc;
		}

		public void AddOnParseGroupDeclarationExit(Action<char> addedFunc)
		{
			onParseGroupDeclarationExit += addedFunc;
		}

		public void AddOnPreGroupNameExit(Action<char> addedFunc)
		{
			onPreGroupNameExit += addedFunc;
		}

		public void AddOnGroupNameExit(Action<char> addedFunc)
		{
			onGroupNameExit += addedFunc;
		}

		public void AddOnPostGroupNameExit(Action<char> addedFunc)
		{
			onPostGroupNameExit += addedFunc;
		}

		public void AddOnPreGroupExit(Action<char> addedFunc)
		{
			onPreGroupExit += addedFunc;
		}

		public void AddOnGroupBracesExit(Action<char> addedFunc)
		{
			onGroupBracesExit += addedFunc;
		}

		public void AddOnGroupItemExit(Action<char> addedFunc)
		{
			onGroupItemExit += addedFunc;
		}

		public void AddOnItemSingleQuotesExit(Action<char> addedFunc)
		{
			onItemSingleQuotesExit += addedFunc;
		}

		public void AddOnItemDoubleQuotesExit(Action<char> addedFunc)
		{
			onItemDoubleQuotesExit += addedFunc;
		}

		public void AddOnPostGroupItemExit(Action<char> addedFunc)
		{
			onPostGroupItemExit += addedFunc;
		}

		public void AddOnItemSeparatorExit(Action<char> addedFunc)
		{
			onItemSeparatorExit += addedFunc;
		}

		public void AddOnPostGroupExit(Action<char> addedFunc)
		{
			onPostGroupExit += addedFunc;
		}

		public void AddOnIllegalGroupNameCharExit(Action<char> addedFunc)
		{
			onIllegalGroupNameCharExit += addedFunc;
		}

		public void AddOnIllegalGroupTokenEqualsExit(Action<char> addedFunc)
		{
			onIllegalGroupTokenEqualsExit += addedFunc;
		}

		public void AddOnIllegalGroupStartExit(Action<char> addedFunc)
		{
			onIllegalGroupStartExit += addedFunc;
		}

		public void AddOnIllegalGroupItemCharExit(Action<char> addedFunc)
		{
			onIllegalGroupItemCharExit += addedFunc;
		}

		public void AddOnMissingGroupEqualsExit(Action<char> addedFunc)
		{
			onMissingGroupEqualsExit += addedFunc;
		}

		public void AddOnMissingGroupItemDelimeterExit(Action<char> addedFunc)
		{
			onMissingGroupItemDelimeterExit += addedFunc;
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
			AddOnParseGroupDeclaration(addedFunc);
			onPreGroupNameState += addedFunc;
			onGroupNameState += addedFunc;
			onPostGroupNameState += addedFunc;
			onPreGroupState += addedFunc;
			onGroupBracesState += addedFunc;
			onGroupItemState += addedFunc;
			AddOnItemSingleQuotes(addedFunc);
			AddOnItemDoubleQuotes(addedFunc);
			onPostGroupItemState += addedFunc;
			onItemSeparatorState += addedFunc;
			onPostGroupState += addedFunc;
			onIllegalGroupNameCharState += addedFunc;
			onIllegalGroupTokenEqualsState += addedFunc;
			onIllegalGroupStartState += addedFunc;
			onIllegalGroupItemCharState += addedFunc;
			onMissingGroupEqualsState += addedFunc;
			onMissingGroupItemDelimeterState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
			ParseGroupDeclarationMachine.ResetStateOnEnd();
			ItemSingleQuotesMachine.ResetStateOnEnd();
			ItemDoubleQuotesMachine.ResetStateOnEnd();
		}
	}
}
