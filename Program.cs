using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace stm_cs
{
    class Program
    {
        private static string HelpMessage =
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
        static void Main(string[] args)
        {
            bool? verbose = null;
            bool waitForKey = false;
            string language = "cs";
            string sourceExtension = "*.smgen";
            string sourcePath = Path.Combine(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location), "StateMachines");
            string destinationPath = Path.Combine(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location), "GenStateMachines");
            if (!Directory.Exists(destinationPath))
            {
                try
                {
                    Directory.CreateDirectory(destinationPath);
                }
                catch (Exception e)
                {
                    if (verbose != false)
                        Console.WriteLine(
                            "Cannot create output directory '"
                            + destinationPath + "'.");
                    Environment.Exit(161);
                }
            }
            string organizationalUnit = "StateMachines";
            List<string> externalResources = new List<string>();
            
            if (args == null || args.Length == 0) { }
            else
            {
                StateMachineParser.CommandLineArgs argParser
                    = new StateMachineParser.CommandLineArgs();
                StringBuilder currentArg = new StringBuilder();
                StringBuilder currentDirective = new StringBuilder();
                StringBuilder currentExtendedDirective = new StringBuilder();

                argParser.AddOnArg((c) => currentArg.Append(c));
                argParser.AddOnDirective((c) => currentDirective.Append(c));
                argParser.AddOnExtendedDirective((c) => currentExtendedDirective.Append(c));
                argParser.AddOnEnd((c) =>
                    {
                            // Process Command Directives
                        if (currentExtendedDirective.Length > 0)
                        {
                            string extDir = String.Intern(currentExtendedDirective.ToString()
                                .ToLowerInvariant());
                            switch (extDir)
                            {
                                case "verbose":
                                    verbose = true;
                                    break;
                                case "silent":
                                    verbose = false;
                                    break;
                                case "help":
                                    Console.WriteLine(HelpMessage);
                                    break;
                                case "waitkey":
                                    waitForKey = true;
                                    break;
                                case "?":
                                    break;
                                default:
                                    PrintInvalidArgError(extDir, verbose);
                                    break;
                            }
                        }
                            // Process Variable Directives
                        else if (currentDirective.Length > 0)
                        {
                            string dir = currentDirective.ToString();
                            if (!dir.Contains('='))
                            {
                                PrintInvalidArgError(dir, verbose);
                            }
                            string[] varArgs = dir.Split('=');
                            if (varArgs.Length > 2)
                            {
                                PrintInvalidArgError(dir, verbose);
                            }
                            string variable = string.Intern(varArgs[0].ToLowerInvariant());
                            switch (variable)
                            {
                                case "in":
                                    if (!Directory.Exists(varArgs[1]))
                                    {
                                        if (verbose != false)
                                            Console.WriteLine("Cannot access input directory '"
                                                + varArgs[1] + "'.");
                                        Environment.Exit(161);
                                    }
                                    sourcePath = varArgs[1];
                                    break;
                                case "out":
                                    if (!Directory.Exists(varArgs[1]))
                                    {
                                        try
                                        {
                                            Directory.CreateDirectory(varArgs[1]);
                                        }
                                        catch (Exception e)
                                        {
                                            if (verbose != false)
                                                Console.WriteLine(
                                                    "Cannot create output directory '"
                                                    + varArgs[1] + "'.");
                                            Environment.Exit(161);
                                        }
                                    }
                                    destinationPath = varArgs[1];
                                    break;
                                case "lang":
                                    language = string.Intern(varArgs[1]);
                                    switch (language)
                                    {
                                        case "cs":
                                            break;
                                        case "java":
                                            break;
                                        default:
                                            if (verbose != false)
                                                Console.WriteLine(
                                                    "Unsupported output language '"
                                                    + varArgs[1] + "'.");
                                            Environment.Exit(160);
                                            break;
                                    }
                                    break;
                                case "srcext":
                                    sourceExtension = varArgs[1];
                                    break;
                                case "orgunit":
                                    organizationalUnit = varArgs[1];
                                    break;
                                case "extres":
                                    externalResources.Add(varArgs[1]);
                                    break;
                                default:
                                    PrintInvalidArgError(dir, verbose);
                                    break;
                            }
                        }
                        else if (currentArg.Length > 0)
                        {
                            PrintInvalidArgError(currentArg.ToString(), verbose);
                        }
                        currentArg.Clear();
                        currentDirective.Clear();
                        currentExtendedDirective.Clear();
                    });
                foreach (string arg in args)
                {
                    argParser.Input(new Queue<char>(arg.ToCharArray()));
                    argParser.ResetStateOnEnd();
                }
            }

            if (verbose == true)
            {
                Console.WriteLine("*********** State Machine parser and code generator *************");
                Console.WriteLine();
                Console.WriteLine(      "Verbose             = true");
                if (waitForKey)
                {
                    Console.WriteLine(  "WaitKey             = true");
                }
                else
                {
                    Console.WriteLine(  "WaitKey             = false");
                }
                Console.WriteLine(      "Input Path          = " + sourcePath);
                Console.WriteLine(      "Output Path         = " + destinationPath);
                Console.WriteLine(      "Language            = " + language);
                Console.WriteLine(      "Source Extension    = " + sourceExtension);
                Console.WriteLine(      "Organizational Unit = " + organizationalUnit);
                foreach (string resource in externalResources)
                {
                    Console.WriteLine(  "External Resource   = " + resource);
                }
                Console.WriteLine();
            }

            string[] fileNames = null;
            try
            {
                fileNames = Directory.GetFileSystemEntries(sourcePath, sourceExtension);
            }
            catch (Exception e)
            {
                if (verbose != false)
                    Console.WriteLine("Error accessing Path '" + sourcePath
                        + "', aborting operation.");
                Environment.Exit(161);
            }
            int count = 0;
            foreach (string fileName in fileNames)
            {
                try
                {
                    string contents = File.ReadAllText(Path.Combine(sourcePath, fileName));
                    List<KeyValuePair<string, string>> code
                        = new List<KeyValuePair<string,string>>();
                    switch (language)
                    {
                        case "cs":
                             code = StateMachineParser.Parser.ParseAndGenerateCSFiles(
                                contents, organizationalUnit, externalResources);
                            break;
                        case "java":
                            code = StateMachineParser.Parser.ParseAndGenerateJavaFiles(
                                contents, organizationalUnit, externalResources);
                            break;
                        default:
                            break;
                    }
                    
                    foreach (KeyValuePair<string, string> source in code)
                    {
                        File.WriteAllText(destinationPath
                            + Path.DirectorySeparatorChar.ToString() + source.Key
                            + "." + language, source.Value);
                        if (verbose != false)
                            Console.WriteLine(source.Key + " written successfully.");
                        count++;
                    }
                }
                catch (StateMachineParser.ParseErrorException e)
                {
                    switch (verbose)
                    {
                        case null:
                            Console.WriteLine("Error:  " + e.Message);
                            Console.WriteLine("Aborting current file - " + fileName);
                            break;
                        case true:
                            Console.WriteLine("Error:  " + e.ToString());
                            Console.WriteLine("Aborting current file - " + fileName);
                            break;
                        case false:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    switch (verbose)
                    {
                        case null:
                            Console.WriteLine("Error:  " + e.Message);
                            Console.WriteLine("Aborting current file - " + fileName);
                            break;
                        case true:
                            Console.WriteLine("Error:  " + e.ToString());
                            Console.WriteLine("Aborting current file - " + fileName);
                            break;
                        case false:
                            break;
                        default:
                            break;
                    }
                }
            }
                // generate common files
            switch (language)
            {
                case "cs":
                    break;
                case "java":
                    List<KeyValuePair<string, string>> common
                        = StateMachineParser.CodeGenerator.GenerateJavaCommon(
                        organizationalUnit, externalResources);
                    foreach (KeyValuePair<string, string> file in common)
                    {
                        File.WriteAllText(destinationPath
                                + Path.DirectorySeparatorChar.ToString() + file.Key
                                + "." + language, file.Value);
                        if (verbose != false)
                            Console.WriteLine(file.Key + ".java written successfully.");
                        count++;
                    }
                    break;
                default:
                    break;
            }
            if (verbose != false)
            {
                Console.WriteLine();
                Console.WriteLine("Finished writing " + count + " files.");
            }

            if (waitForKey)
                Console.ReadKey();
        }

        private static void PrintInvalidArgError(string input, bool? verbose)
        {
            if (verbose != false)
            {
                Console.WriteLine("Invalid command line argument:  '"
                                        + input + "'.");
                Console.WriteLine("Please try --help or --? for complete command listing.");
            }
            Environment.Exit(160);
        }
    }
}
