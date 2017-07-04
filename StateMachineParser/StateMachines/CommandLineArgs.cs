// ************************ CommandLineArgs : char ************************
// 
// 	PreArg					: '-' = BeginDirective, default = Arg;
// 	Arg						: default = Arg;
// 	BeginDirective			: '-' = BeginExtendedDirective, default = Directive;
// 	Directive				: default = Directive;
// 	BeginExtendedDirective	: default = ExtendedDirective;
// 	ExtendedDirective		: default = ExtendedDirective;
// 
//
// This file was automatically generated from a tool that converted the
// above state machine definition into this state machine class.
// Any changes to this code will be replaced the next time the code is generated.

using System;
using System.Collections.Generic;
namespace StateMachineParser
{
	public class CommandLineArgs
	{
		public enum States
		{
			PreArg = 0, 	Arg = 1, 
			BeginDirective = 2, 	Directive = 3, 
			BeginExtendedDirective = 4, 	ExtendedDirective = 5, 
		}

		private States? state = null;
		public States? CurrentState { get { return state; } }
		private char currentCommand;
		public char CurrentCommand { get { return currentCommand; } }
		private bool reset = false;

		private Action<char> onPreArgState = null;
		private Action<char> onPreArgEnter = null;
		private Action<char> onPreArgExit = null;
		private Action<char> onArgState = null;
		private Action<char> onArgEnter = null;
		private Action<char> onArgExit = null;
		private Action<char> onBeginDirectiveState = null;
		private Action<char> onBeginDirectiveEnter = null;
		private Action<char> onBeginDirectiveExit = null;
		private Action<char> onDirectiveState = null;
		private Action<char> onDirectiveEnter = null;
		private Action<char> onDirectiveExit = null;
		private Action<char> onBeginExtendedDirectiveState = null;
		private Action<char> onBeginExtendedDirectiveEnter = null;
		private Action<char> onBeginExtendedDirectiveExit = null;
		private Action<char> onExtendedDirectiveState = null;
		private Action<char> onExtendedDirectiveEnter = null;
		private Action<char> onExtendedDirectiveExit = null;
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
						state = States.PreArg;
						goto ResumePreArg;
					}
					else
						goto End;
				case States.PreArg:
					goto ResumePreArg;
				case States.Arg:
					goto ResumeArg;
				case States.BeginDirective:
					goto ResumeBeginDirective;
				case States.Directive:
					goto ResumeDirective;
				case States.BeginExtendedDirective:
					goto ResumeBeginExtendedDirective;
				case States.ExtendedDirective:
					goto ResumeExtendedDirective;
			}


EnterPreArg:
			state = States.PreArg;
			if (onPreArgEnter != null)
				onPreArgEnter(currentCommand);

			if (onPreArgState != null)
				onPreArgState(currentCommand);
ResumePreArg:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '-':
					if (onPreArgExit != null)
						onPreArgExit(currentCommand);
					goto EnterBeginDirective;
				default:
					if (onPreArgExit != null)
						onPreArgExit(currentCommand);
					goto EnterArg;
			}

EnterArg:
			state = States.Arg;
			if (onArgEnter != null)
				onArgEnter(currentCommand);

Arg:
			if (onArgState != null)
				onArgState(currentCommand);
ResumeArg:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					goto Arg;
			}

EnterBeginDirective:
			state = States.BeginDirective;
			if (onBeginDirectiveEnter != null)
				onBeginDirectiveEnter(currentCommand);

			if (onBeginDirectiveState != null)
				onBeginDirectiveState(currentCommand);
ResumeBeginDirective:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				case '-':
					if (onBeginDirectiveExit != null)
						onBeginDirectiveExit(currentCommand);
					goto EnterBeginExtendedDirective;
				default:
					if (onBeginDirectiveExit != null)
						onBeginDirectiveExit(currentCommand);
					goto EnterDirective;
			}

EnterDirective:
			state = States.Directive;
			if (onDirectiveEnter != null)
				onDirectiveEnter(currentCommand);

Directive:
			if (onDirectiveState != null)
				onDirectiveState(currentCommand);
ResumeDirective:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					goto Directive;
			}

EnterBeginExtendedDirective:
			state = States.BeginExtendedDirective;
			if (onBeginExtendedDirectiveEnter != null)
				onBeginExtendedDirectiveEnter(currentCommand);

			if (onBeginExtendedDirectiveState != null)
				onBeginExtendedDirectiveState(currentCommand);
ResumeBeginExtendedDirective:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					if (onBeginExtendedDirectiveExit != null)
						onBeginExtendedDirectiveExit(currentCommand);
					goto EnterExtendedDirective;
			}

EnterExtendedDirective:
			state = States.ExtendedDirective;
			if (onExtendedDirectiveEnter != null)
				onExtendedDirectiveEnter(currentCommand);

ExtendedDirective:
			if (onExtendedDirectiveState != null)
				onExtendedDirectiveState(currentCommand);
ResumeExtendedDirective:
			if (data.Count > 0)
				currentCommand = data.Dequeue();
			else
				goto End;
			switch (currentCommand)
			{
				default:
					goto ExtendedDirective;
			}

End:
			if (onEnd != null)
				onEnd(currentCommand);
			if (reset)
			{
				goto Reset;
			}
			return result;
		}

		public void AddOnPreArg(Action<char> addedFunc)
		{
			onPreArgState += addedFunc;
		}

		public void AddOnArg(Action<char> addedFunc)
		{
			onArgState += addedFunc;
		}

		public void AddOnBeginDirective(Action<char> addedFunc)
		{
			onBeginDirectiveState += addedFunc;
		}

		public void AddOnDirective(Action<char> addedFunc)
		{
			onDirectiveState += addedFunc;
		}

		public void AddOnBeginExtendedDirective(Action<char> addedFunc)
		{
			onBeginExtendedDirectiveState += addedFunc;
		}

		public void AddOnExtendedDirective(Action<char> addedFunc)
		{
			onExtendedDirectiveState += addedFunc;
		}

		public void AddOnPreArgEnter(Action<char> addedFunc)
		{
			onPreArgEnter += addedFunc;
		}

		public void AddOnArgEnter(Action<char> addedFunc)
		{
			onArgEnter += addedFunc;
		}

		public void AddOnBeginDirectiveEnter(Action<char> addedFunc)
		{
			onBeginDirectiveEnter += addedFunc;
		}

		public void AddOnDirectiveEnter(Action<char> addedFunc)
		{
			onDirectiveEnter += addedFunc;
		}

		public void AddOnBeginExtendedDirectiveEnter(Action<char> addedFunc)
		{
			onBeginExtendedDirectiveEnter += addedFunc;
		}

		public void AddOnExtendedDirectiveEnter(Action<char> addedFunc)
		{
			onExtendedDirectiveEnter += addedFunc;
		}

		public void AddOnPreArgExit(Action<char> addedFunc)
		{
			onPreArgExit += addedFunc;
		}

		public void AddOnArgExit(Action<char> addedFunc)
		{
			onArgExit += addedFunc;
		}

		public void AddOnBeginDirectiveExit(Action<char> addedFunc)
		{
			onBeginDirectiveExit += addedFunc;
		}

		public void AddOnDirectiveExit(Action<char> addedFunc)
		{
			onDirectiveExit += addedFunc;
		}

		public void AddOnBeginExtendedDirectiveExit(Action<char> addedFunc)
		{
			onBeginExtendedDirectiveExit += addedFunc;
		}

		public void AddOnExtendedDirectiveExit(Action<char> addedFunc)
		{
			onExtendedDirectiveExit += addedFunc;
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
			onPreArgState += addedFunc;
			onArgState += addedFunc;
			onBeginDirectiveState += addedFunc;
			onDirectiveState += addedFunc;
			onBeginExtendedDirectiveState += addedFunc;
			onExtendedDirectiveState += addedFunc;
		}


		public void ResetStateOnEnd()
		{
			state = null;
			reset = true;
		}
	}
}
