using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StateMachineParser
{
    public static partial class CodeGenerator
    {
        private static string JavaGenericTypeConverter(string parameter)
        {
            string result = parameter;
            switch (parameter)
            {
                case "bool":
                    result = "Boolean";
                    break;
                case "byte":
                    result = "Byte";
                    break;
                case "char":
                    result = "Character";
                    break;
                case "float":
                    result = "Float";
                    break;
                case "int":
                    result = "Integer";
                    break;
                case "long":
                    result = "Long";
                    break;
                case "short":
                    result = "Short";
                    break;
                case "double":
                    result = "Double";
                    break;
                case "string":
                    result = "String";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static List<KeyValuePair<string, string>> GenerateJavaCommon(string packageName,
            List<string> externalImports)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            string kvpKey = "StateEvent";
            StringBuilder kvpValue = new StringBuilder();
            kvpValue.AppendLine("package " + packageName + ";");
            kvpValue.AppendLine();
            foreach (string imp in externalImports)
            {
                kvpValue.AppendLine("import " + imp + ";");
            }
            kvpValue.AppendLine( @"
public abstract class StateEvent<T> {
	public abstract void handleEvent(T command) throws StateEventException ;
}
");
            result.Add(new KeyValuePair<string, string>(kvpKey, kvpValue.ToString()));

            kvpValue.Clear();
            kvpKey = "StateMachineEnum";
            kvpValue.AppendLine("package " + packageName + ";");
            kvpValue.AppendLine();
            kvpValue.AppendLine("import java.util.Queue;");
            foreach (string imp in externalImports)
            {
                kvpValue.AppendLine("import " + imp + ";");
            }
            kvpValue.AppendLine(@"
public interface StateMachineEnum<T> {
    public void addEnterEvent(StateMachine<T> parent, StateEvent<T> event);
    public void addStateEvent(StateMachine<T> parent, StateEvent<T> event);
    public void addExitEvent(StateMachine<T> parent, StateEvent<T> event);
    public void onEnter(StateMachine<T> parent, T event) throws StateEventException;
    public void onState(StateMachine<T> parent, T event) throws StateEventException;
    public void onExit(StateMachine<T> parent, T event) throws StateEventException;
    public T changeState(StateMachine<T> parent, Queue<T> data)
            throws StateEventException;
}
");
            result.Add(new KeyValuePair<string,string>(kvpKey, kvpValue.ToString()));

            kvpValue.Clear();
            kvpKey = "StateMachine";
            kvpValue.AppendLine("package " + packageName + ";");
            kvpValue.AppendLine();
            kvpValue.AppendLine("import java.util.Queue;");
            kvpValue.AppendLine(@"
public interface StateMachine<T> {
    public Boolean input(Queue<T> data) throws StateEventException;
    public void addAllStatesEvent(StateEvent<T> event);
    public void addAcceptEnterEvent(StateEvent<T> event);
    public void addDeclineEnterEvent(StateEvent<T> event);
    public void addEndEnterEvent(StateEvent<T> event);
    public StateMachineEnum<T> getState();
    public T getCurrentCommand();
    public T getLastCommand();
    public void resetState();
}
");
            result.Add(new KeyValuePair<string, string>(kvpKey, kvpValue.ToString()));

            kvpValue.Clear();
            kvpKey = "StateMachineUtil";
            kvpValue.AppendLine("package " + packageName + ";");
            kvpValue.AppendLine();
            kvpValue.AppendLine("import java.util.Queue;");
            kvpValue.AppendLine("import java.util.ArrayDeque;");
            kvpValue.AppendLine(@"
public class StateMachineUtil {
    public static <T> Queue<T> convertToQueue(T[] data) {
        Queue<T> result = new ArrayDeque<T>();
        for (T element : data) {
            result.add(element);
        }
        return result;
    }
    public static Queue<Character> convertToQueue(String data) {
        Queue<Character> result = new ArrayDeque<Character>();
        char[] temp = data.toCharArray();
        for (char element : temp) {
            result.add(element);
        }
        return result;
    }
}
");
            result.Add(new KeyValuePair<string, string>(kvpKey, kvpValue.ToString()));

            kvpValue.Clear();
            kvpKey = "StateEventException";
            kvpValue.AppendLine("package " + packageName + ";");
            kvpValue.AppendLine();
            kvpValue.AppendLine(@"public class StateEventException extends Exception {

	public StateEventException() {}

	public StateEventException(String message) {
		super(message);
	}
	public StateEventException(Throwable cause) {
		super(cause);
	}
	public StateEventException(String message, Throwable cause) {
		super(message, cause);
	}
	public StateEventException(String message, Throwable cause,
			boolean enableSuppression, boolean writableStackTrace) {
		super(message, cause, enableSuppression, writableStackTrace);
	}
}
");
            result.Add(new KeyValuePair<string, string>(kvpKey, kvpValue.ToString()));
            return result;
        }

        private static string generateJavaEventAddMethods(string stateName,
            string convertedType)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("\t// " + stateName + " add events");
            result.AppendLine("\tpublic void add" + stateName
                + "EnterEvent(StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\ton" + stateName + "Enter.add(event);");
            result.AppendLine("\t}");
            result.AppendLine("\tpublic void add" + stateName
                + "StateEvent(StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\ton" + stateName + "State.add(event);");
            result.AppendLine("\t}");
            result.AppendLine("\tpublic void add" + stateName
                + "ExitEvent(StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\ton" + stateName + "Exit.add(event);");
            result.AppendLine("\t}");
            result.AppendLine();
            return result.ToString();
        }

        private static string generateJavaEnumConcreteCode(string machineName, string stateName,
            string convertedType)
        {
            StringBuilder result = new StringBuilder();

            // Event Add Forwarding to Outer Class
            result.AppendLine("\t\t\tpublic void addEnterEvent(StateMachine<"
                + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateName
                + "Enter.add(event);");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t\tpublic void addStateEvent(StateMachine<"
                + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateName
                + "State.add(event);");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t\tpublic void addExitEvent(StateMachine<"
                + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
            result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateName
                + "Exit.add(event);");
            result.AppendLine("\t\t\t}");
            // Event Call Forwarding to Outer Class
            result.AppendLine("\t\t\tpublic void onEnter(StateMachine<" + convertedType
                + "> parent, " + convertedType + " command) throws StateEventException {");
            result.AppendLine("\t\t\t\t" + machineName + " target = ("
                + machineName + ")parent;");
            result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                + "> ev : target.on" + stateName + "Enter)");
            result.AppendLine("\t\t\t\t\tev.handleEvent(command);");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t\tpublic void onState(StateMachine<" + convertedType
                + "> parent, " + convertedType + " command) throws StateEventException {");
            result.AppendLine("\t\t\t\t" + machineName + " target = ("
                + machineName + ")parent;");
            result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                + "> ev : target.on" + stateName + "State)");
            result.AppendLine("\t\t\t\t\tev.handleEvent(command);");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t\tpublic void onExit(StateMachine<" + convertedType
                + "> parent, " + convertedType + " command) throws StateEventException {");
            result.AppendLine("\t\t\t\t" + machineName + " target = ("
                + machineName + ")parent;");
            result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                + "> ev : target.on" + stateName + "Exit)");
            result.AppendLine("\t\t\t\t\tev.handleEvent(command);");
            result.AppendLine("\t\t\t}");

            return result.ToString();
        }

        private static string generateJavaEventFields(string stateName, string convertedType)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("\tprivate List<StateEvent<" + convertedType + ">> on"
                    + stateName + "Enter");
            result.AppendLine("\t\t= new ArrayList<StateEvent<" + convertedType + ">>();");
            result.AppendLine("\tprivate List<StateEvent<" + convertedType + ">> on"
                + stateName + "State");
            result.AppendLine("\t\t= new ArrayList<StateEvent<" + convertedType + ">>();");
            result.AppendLine("\tprivate List<StateEvent<" + convertedType + ">> on"
                + stateName + "Exit");
            result.AppendLine("\t\t= new ArrayList<StateEvent<" + convertedType + ">>();");
            return result.ToString();
        }

        public static KeyValuePair<string, string> GenerateJava(string source,
            string packageName, List<string> externalImports, string machineName,
            string inputType, List<string> stateNames, List<bool> isNest,
            List<List<string>> commandOrNestValues, List<List<string>> nextStates,
            List<string> nestAccepts, List<string> nestDeclines)
        {
            StringBuilder result = new StringBuilder();
            string convertedType = JavaGenericTypeConverter(inputType);
            bool hasNests = false;
            for (int i = 0; i < isNest.Count; i++)
            {
                if (isNest[i])
                {
                    hasNests = true;
                    break;
                }
            }
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

            // Imports and Package
            result.AppendLine("package " + packageName + ";");
            result.AppendLine();

            result.AppendLine("import java.util.List;");
            result.AppendLine("import java.util.ArrayList;");
            result.AppendLine("import java.util.Queue;");
            if (externalImports != null)
            {
                foreach (string externalImport in externalImports)
                {
                    result.AppendLine("import " + externalImport + ";");
                }
            }
            result.AppendLine();

            // Class declaration
            result.AppendLine("public class " + machineName + " implements StateMachine<"
                + convertedType + "> {");


            // Begin Enum
            result.AppendLine("/******************** States Enum ********************/");
            result.AppendLine("\tpublic enum States implements StateMachineEnum<" 
                + convertedType + "> {");

            // States
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.AppendLine("\t\t/***** " + stateNames[i]
                    + " State *****/");
                if (isNest[i])
                    result.AppendLine("\t\t" + stateNames[i] + " {");
                else
                    result.AppendLine("\t\t" + stateNames[i] + " {");

                result.AppendLine("\t\t\tpublic " + convertedType + " changeState(StateMachine<"
                        + convertedType + "> parent, Queue<" + convertedType + "> data) throws StateEventException {");
                if (isNest[i])
                {
                    result.AppendLine("\t\t\t\tStates result = this;");
                    result.AppendLine("\t\t\t\tBoolean nestResult = ((" + machineName 
                        + ")parent)." + stateNames[i] + "Machine.input(data);");
                    result.AppendLine("\t\t\t\tif (nestResult == null)");
                    result.AppendLine("\t\t\t\t\tresult = End;");
                    result.AppendLine("\t\t\t\telse if (nestResult)");
                    result.AppendLine("\t\t\t\t{");
                    if (nestAccepts[i].CompareTo("accept") == 0)
                        result.AppendLine("\t\t\t\t\tresult = Accept;");
                    else if (nestAccepts[i].CompareTo("decline") == 0)
                        result.AppendLine("\t\t\t\t\tresult = Decline;");
                    else
                        result.AppendLine("\t\t\t\t\tresult = " + nestAccepts[i] + ";");
                    result.AppendLine("\t\t\t\t}");
                    result.AppendLine("\t\t\t\telse");
                    result.AppendLine("\t\t\t\t{");
                    if (nestDeclines[i].CompareTo("accept") == 0)
                        result.AppendLine("\t\t\t\t\tresult = Accept;");
                    else if (nestDeclines[i].CompareTo("decline") == 0)
                        result.AppendLine("\t\t\t\t\tresult = Decline;");
                    else
                        result.AppendLine("\t\t\t\t\tresult = " + nestDeclines[i] + ";");
                    result.AppendLine("\t\t\t\t}");
                    result.AppendLine("\t\t\t\t((" + machineName + ")parent).state = result;");
                    result.AppendLine("\t\t\t\treturn parent.getLastCommand();");
                    result.AppendLine("\t\t\t}");
                }
                else
                {
                    result.AppendLine("\t\t\t\tStates result = this;");
                    result.AppendLine("\t\t\t\t" + convertedType + " command = data.poll();");
                    result.AppendLine("\t\t\t\tswitch (command) {");
                    for (int j = 0; j < commandOrNestValues[i].Count; j++)
                    {
                        if (commandOrNestValues[i][j].CompareTo("default") != 0)
                            result.AppendLine("\t\t\t\t\tcase "
                                + commandOrNestValues[i][j] + ":");
                        else
                            result.AppendLine("\t\t\t\t\tdefault:");
                        if (nextStates[i][j].CompareTo("accept") == 0)
                        {
                            result.AppendLine("\t\t\t\t\t\tresult = Accept;");
                        }
                        else if (nextStates[i][j].CompareTo("decline") == 0)
                        {
                            result.AppendLine("\t\t\t\t\t\tresult = Decline;");
                        }
                        else
                        {
                            result.AppendLine("\t\t\t\t\t\tresult = " + nextStates[i][j] + ";");
                        }
                        result.AppendLine("\t\t\t\t\t\tbreak;");
                    }
                    result.AppendLine("\t\t\t\t}");
                    result.AppendLine("\t\t\t\t((" + machineName + ")parent).state = result;");
                    result.AppendLine("\t\t\t\treturn command;");
                    result.AppendLine("\t\t\t}");
                }
                if (isNest[i])
                {
                    // Event Add Forwarding to Outer Class
                    result.AppendLine("\t\t\tpublic void addEnterEvent(StateMachine<"
                        + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateNames[i]
                        + "Enter.add(event);");
                    result.AppendLine("\t\t\t}");
                    result.AppendLine("\t\t\tpublic void addStateEvent(StateMachine<"
                        + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateNames[i]
                        + "State.add(event);");
                    result.AppendLine("\t\t\t}");
                    result.AppendLine("\t\t\tpublic void addExitEvent(StateMachine<"
                        + convertedType + "> parent, StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\t\t\t((" + machineName + ")parent).on" + stateNames[i]
                        + "Exit.add(event);");
                    result.AppendLine("\t\t\t}");
                    // Event Call Forwarding to Outer Class
                    result.AppendLine("\t\t\tpublic void onEnter(StateMachine<" + convertedType
                        + "> parent, " + convertedType + " command) throws StateEventException {");
                    result.AppendLine("\t\t\t\t" + machineName + " target = ("
                        + machineName + ")parent;");
                    result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                        + "> ev : target.on" + stateNames[i] + "Enter)");
                    result.AppendLine("\t\t\t\t\tev.handleEvent(command);");
                    result.AppendLine("\t\t\t}");
                    result.AppendLine("\t\t\tpublic void onState(StateMachine<" + convertedType
                        + "> parent, " + convertedType + " command) throws StateEventException {");
                    /* result.AppendLine("\t\t\t\t" + machineName + " target = ("
                        + machineName + ")parent;");
                    result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                        + "> ev : target.on" + stateNames[i] + "State)");
                    result.AppendLine("\t\t\t\t\tev.handleEvent(command);"); */
                    result.AppendLine("\t\t\t}");
                    result.AppendLine("\t\t\tpublic void onExit(StateMachine<" + convertedType
                        + "> parent, " + convertedType + " command) throws StateEventException {");
                    result.AppendLine("\t\t\t\t" + machineName + " target = ("
                        + machineName + ")parent;");
                    result.AppendLine("\t\t\t\tfor (StateEvent<" + convertedType
                        + "> ev : target.on" + stateNames[i] + "Exit)");
                    result.AppendLine("\t\t\t\t\tev.handleEvent(command);");
                    result.AppendLine("\t\t\t}");
                }
                else
                {
                    result.AppendLine(generateJavaEnumConcreteCode(machineName, stateNames[i],
                        convertedType));
                }
                result.AppendLine("\t\t},");
            }
            result.AppendLine("\t\tAccept {");
            result.AppendLine("\t\t\tpublic " + convertedType + " changeState(StateMachine<"
                + convertedType + "> parent, Queue<" + convertedType + "> data) {");
            result.AppendLine("\t\t\t\treturn null;");
            result.AppendLine("\t\t\t}");
            result.AppendLine(generateJavaEnumConcreteCode(machineName, "Accept",
                    convertedType));
            result.AppendLine("\t\t},");

            result.AppendLine("\t\tDecline {");
            result.AppendLine("\t\t\tpublic " + convertedType + " changeState(StateMachine<"
                + convertedType + "> parent, Queue<" + convertedType + "> data) {");
            result.AppendLine("\t\t\t\treturn null;");
            result.AppendLine("\t\t\t}");
            result.AppendLine(generateJavaEnumConcreteCode(machineName, "Decline",
                    convertedType));
            result.AppendLine("\t\t},");

            result.AppendLine("\t\tEnd {");
            result.AppendLine("\t\t\tpublic " + convertedType + " changeState(StateMachine<"
                + convertedType + "> parent, Queue<" + convertedType + "> data) {");
            result.AppendLine("\t\t\t\treturn null;");
            result.AppendLine("\t\t\t}");
            result.AppendLine(generateJavaEnumConcreteCode(machineName, "End",
                    convertedType));
            result.AppendLine("\t\t};");
            result.AppendLine();

            // End Enum
            result.AppendLine("\t}");
            result.AppendLine();

            // Nested Machines
            if (hasNests)
            {
                result.AppendLine("/******************** Nested Machine ********************/");
                for (int i = 0; i < isNest.Count; i++)
                {
                    if (isNest[i])
                    {
                        result.AppendLine("\t\tpublic StateMachine<" + convertedType + "> "
                            + stateNames[i] + "Machine = new " + commandOrNestValues[i][0]
                            + "();");
                    }
                }
                
                result.AppendLine();
            }
            
            // Fields
            result.AppendLine("\tprivate States state = null;");
            result.AppendLine("\tprivate " + convertedType + " currentCommand = null;");
            result.AppendLine("\tprivate " + convertedType + " lastCommand = null;");
            result.AppendLine("\tprivate boolean reset = false;");
            result.AppendLine();

            // Get Accessors
            result.AppendLine("\tpublic States getState() { return state; }");
            result.AppendLine("\tpublic " + convertedType 
                + " getCurrentCommand() { return currentCommand; }");
            result.AppendLine("\tpublic " + convertedType 
                + " getLastCommand() { return lastCommand; }");
            result.AppendLine();

            // Event handlers
            for (int i = 0; i < stateNames.Count; i++)
            {
                result.AppendLine(generateJavaEventFields(stateNames[i], convertedType));
            }
            result.AppendLine(generateJavaEventFields("Accept", convertedType));
            result.AppendLine(generateJavaEventFields("Decline", convertedType));
            result.AppendLine(generateJavaEventFields("End", convertedType));

            result.AppendLine();

            // Constructor

            // Input
            result.AppendLine("\tpublic Boolean input(Queue<" + convertedType + "> data)");
            result.AppendLine("\t\t\tthrows StateEventException {");
            result.AppendLine("\t\tBoolean result = null;");
            result.AppendLine("\t\tdo {");
            result.AppendLine("\t\t\tif (state == null || reset)");
            result.AppendLine("\t\t\t\tstate = States." + stateNames[0] + ";");
            result.AppendLine();
            result.AppendLine("\t\t\treset = false;");
            result.AppendLine("\t\t\tStates previousState = state;");
            result.AppendLine();
            result.AppendLine("\t\t\twhile (state != null)");
            result.AppendLine("\t\t\t{");
            result.AppendLine("\t\t\t\tlastCommand = currentCommand;");
            result.AppendLine("\t\t\t\tcurrentCommand = data.peek();");
            result.AppendLine("\t\t\t\tif (currentCommand == null)");
            result.AppendLine("\t\t\t\t{");
            result.AppendLine("\t\t\t\t\tStates.End.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\treturn null;");
            result.AppendLine("\t\t\t\t}");
            result.AppendLine("\t\t\t\tpreviousState = state;");
            result.AppendLine("\t\t\t\tcurrentCommand = state.changeState(this, data);");
            result.AppendLine("\t\t\t\tswitch (state)");
            result.AppendLine("\t\t\t\t{");
            result.AppendLine("\t\t\t\t\tcase Accept:");
            result.AppendLine("\t\t\t\t\t\tpreviousState.onExit(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tStates.Accept.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tStates.End.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tstate = null;");
            result.AppendLine("\t\t\t\t\t\tresult = true;");
            result.AppendLine("\t\t\t\t\t\tbreak;");
            result.AppendLine("\t\t\t\t\tcase Decline:");
            result.AppendLine("\t\t\t\t\t\tstate.onExit(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tStates.Decline.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tStates.End.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tstate = null;");
            result.AppendLine("\t\t\t\t\t\tresult = false;");
            result.AppendLine("\t\t\t\t\t\tbreak;");
            result.AppendLine("\t\t\t\t\tcase End:");
            result.AppendLine("\t\t\t\t\t\tstate = previousState;");
            result.AppendLine("\t\t\t\t\t\tStates.End.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tresult = null;");
            result.AppendLine("\t\t\t\t\t\tbreak;");
            result.AppendLine("\t\t\t\t\tdefault:");
            result.AppendLine("\t\t\t\t\t\tif (previousState != state)");
            result.AppendLine("\t\t\t\t\t\t{");
            result.AppendLine("\t\t\t\t\t\t\tpreviousState.onExit(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\t\tstate.onEnter(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\t}");
            result.AppendLine("\t\t\t\t\t\tstate.onState(this, currentCommand);");
            result.AppendLine("\t\t\t\t\t\tbreak;");
            result.AppendLine("\t\t\t\t}");
            result.AppendLine("\t\t\t}");
            result.AppendLine("\t\t} while (reset == true);");
            result.AppendLine("\t\treturn result;");
            result.AppendLine("\t}");
            result.AppendLine();

            // Add Events
            for (int i = 0; i < stateNames.Count; i++)
            {
                if (isNest[i])
                {
                    result.AppendLine("\t// " + stateNames[i] + " add events");
                    result.AppendLine("\tpublic void add" + stateNames[i]
                        + "EnterEvent(StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\ton" + stateNames[i] + "Enter.add(event);");
                    result.AppendLine("\t}");
                    result.AppendLine("\tpublic void add" + stateNames[i]
                        + "StateEvent(StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\tadd" + stateNames[i] + "EnterEvent(event);");
                    result.AppendLine("\t\t" + stateNames[i]
                        + "Machine.addAllStatesEvent(event);");
                    result.AppendLine("\t}");
                    result.AppendLine("\tpublic void add" + stateNames[i]
                        + "ExitEvent(StateEvent<" + convertedType + "> event) {");
                    result.AppendLine("\t\ton" + stateNames[i] + "Exit.add(event);");
                    result.AppendLine("\t}");
                    result.AppendLine();
                }
                else
                {
                    result.Append(generateJavaEventAddMethods(stateNames[i], convertedType));
                }
            }
            result.Append(generateJavaEventAddMethods("Accept", convertedType));
            result.Append(generateJavaEventAddMethods("Decline", convertedType));
            result.Append(generateJavaEventAddMethods("End", convertedType));
            result.AppendLine("\tpublic void addAllStatesEvent(StateEvent<" + convertedType
                + "> event) {");
            for (int i = 0; i < isNest.Count; i++)
            {
                result.AppendLine("\t\tadd" + stateNames[i] + "StateEvent(event);");
            }
            result.AppendLine("\t}");

            // Reset State
            result.AppendLine("\tpublic void resetState() {");
            for (int i = 0; i < isNest.Count; i++)
            {
                if (isNest[i])
                {
                    result.AppendLine("\t\t" + stateNames[i] + "Machine.resetState();");
                }
            }
            result.AppendLine("\t\treset = true;");
            result.AppendLine("\t}");

            // End of Class
            result.AppendLine("}");

            // Output result
            return new KeyValuePair<string, string>(machineName, result.ToString());
        }
    }
}
