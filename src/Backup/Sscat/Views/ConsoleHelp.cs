// <copyright file="ConsoleHelp.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core.Util;
    using Sscat.Core.Commands.Gui;

    /// <summary>
    /// Initializes a new instance of the ConsoleHelp class
    /// </summary>
    public class ConsoleHelp : IHelp
    {
        /// <summary>
        /// Shows SSCAT command console help options
        /// </summary>
        public void Show()
        {
            Console.WriteLine(
                @"{0}

  Basic Commands:

    scripts.generate  Generate scripts.
                      Example: sscat scripts.generate ""test"" ""test description""
                        - Will generate the script from logs with the 
                          name ""test"" and ""test description"" as
                          description in the XML script.
    scripts.list      List all scripts in the current directory.
    scripts.show      List all the events in the script.
                      Example: sscat scripts.show 1
                        - Will show the script events for script index 1.
                          See scripts.list to know script index.
    scripts.convert   Converts all old and valid finger scripts to new sscat scripts
    scripts.play      Play scripts.
                      Parameters: [script repetition] [script index]
                      Example: sscat scripts.play 2 1
                        - Play 2 times for script at index 1.
                      Parameters: [script repetition] [script name]
                      Example: sscat scripts.play 2 scriptName_0.xml
                        - Play 2 times for script file scriptName_0.
                      Parameters: [script repetition] 
                                  [script wildcard for all scripts]
                      Example: sscat scripts.play 3 *
                        - Play 3 times for all scripts.
                      Parameters: [script repetition] 
                                  [script array of script index or names]
                      Example: sscat scripts.play 5 1 2 3
                        - Play 5 times for the scripts at index 1, 2, and 3.
                      Parameters: [script repetition] [script report file name] 
                                  [script array of script index or names]
                      Example: sscat scripts.play 4 reportFile.csv scriptA_0.xml 
                               scriptA_1.xml scriptB_0.xml
                        - Play 4 times for these scripts: 
                        scriptA_0.xml, scriptA_1.xml, and scriptB_0.xml
                        and renames the report playback file to reportFile.csv.
                      Note: Please see scripts.list command to know
                            the script index.
    logs.hook         Hook to file(s). 
                      Example: sscat logs.hook 0:Psx
                        - Hooks for index 0 with PSX parser.
                          See logs.list to know log index.
    logs.list         Lists log files (*.log) and shows index.
    lane.version      Shows SSCO version
    lane.start        Starts SSCO
    lane.kill         Stops SSCO
    logs.delete       Delete SCOT log files
    Ctrl + C          To stop or abort playing.

  The configuration settings used for console is found at LaneConfiguration.xml under c:\sscat\config.
  
  use 'sscat help' for the full commands or 'sscat version' for details",
                ApplicationUtility.ProductNameAndVersion);
        }
    }
}
