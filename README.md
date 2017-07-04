# smGen
State Machine Code Generator

smGen is a command line code generator to generate state machines from source files using a custom compact syntax.

```
@"State Machine Parser command listing
Commands     (usage => --command)
--help      => Displays this message.
--?         => Displays this message.
--verbose   => Enables detailed messages to be displayed in console.
--silent    => Disables all messages from being displayed in console.
--waitkey   => Waits for user to press a key to return to console.
Variables    (usage => -variable=value)
-in         => Specifies the input path to search for files to parse.
                (default = program_directory\StateMachines)
-out        => Specifies the output path to save generated code to.
                (default = program_directory\GenStateMachines)
-lang       => Specifies the target output language to the code generator.
                valid choices include cs and java
                (default = cs)
-srcext     => Specifies the extension to search for state machine files.
                (default = .smgen)
-orgunit    => Specifies the organizational unit of generated files
                such as namespace for .cs files or package for .java files.
                (default = StateMachines)
-extres     => Adds external resources needed by the generated files
                such as a using or import for an Enum definition.
                Each subsequent use specifies an additional resource.
                (default = none)";
```

Example Syntax:

```
StateMachine ParseSMGroups : char
{
	group whitespace		= { ' ', '\t', '\r', '\n' }
	group alphaNumeric		= { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
			'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B',
			'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
			'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
			'8', '9', '_', '.' }
      
	ParseGroupDeclaration	: ParseSMGroupDeclaration ? PreGroupName : ParseGroupDeclaration;
	PreGroupName		: whitespace = PreGroupName, alphaNumeric = GroupName,
			default = IllegalGroupNameChar;
	GroupName			: whitespace = PostGroupName, alphaNumeric = GroupName,
			'=' = PreGroup, '{' = MissingGroupEquals, default = IllegalGroupTokenEquals;
	PostGroupName		: whitespace = PostGroupName, '=' = PreGroup, '{' = MissingGroupEquals,
			alphaNumeric = MissingGroupEquals, default = IllegalGroupTokenEquals;
	PreGroup			: whitespace = PreGroup, '{' = GroupBraces,
			default = IllegalGroupStart;
	GroupBraces			: whitespace = GroupBraces, '\'' = ItemSingleQuotes,
			'"' = ItemDoubleQuotes, '}' = PostGroup, alphaNumeric = GroupItem,
			default = IllegalGroupItemChar;
	GroupItem			: whitespace = PostGroupItem, '}' = PostGroup, ',' = ItemSeparator,
			alphaNumeric = GroupItem, default = IllegalGroupItemChar;
		// Quotes error handling taken care of in prior pass
	ItemSingleQuotes	: ParseSingleQuotes ? PostGroupItem : decline;
	ItemDoubleQuotes	: ParseDoubleQuotes ? PostGroupItem	: decline;
	PostGroupItem		: whitespace = PostGroupItem, '}' = PostGroup, ',' = ItemSeparator,
			alphaNumeric = MissingGroupItemDelimeter, default = IllegalGroupItemChar;
	ItemSeparator		: whitespace = ItemSeparator, alphaNumeric = GroupItem,
			'\'' = ItemSingleQuotes, '"' = ItemDoubleQuotes, default = IllegalGroupItemChar;
	PostGroup			: default = ParseGroupDeclaration;
		// Error Handling States
	IllegalGroupNameChar		: default = decline;
	IllegalGroupTokenEquals		: default = decline;
	IllegalGroupStart			: default = decline;
	IllegalGroupItemChar		: default = decline;
	MissingGroupEquals			: default = decline;
	MissingGroupItemDelimeter	: default = decline;
}
```
