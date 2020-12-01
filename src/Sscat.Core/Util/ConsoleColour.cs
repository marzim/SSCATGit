//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Runtime.InteropServices;

namespace Sscat.Core.Util
{
	public class ConsoleColour
    {
        // constants for console streams
        const int STDINPUTHANDLE = -10;
        const int STDOUTPUTHANDLE = -11;
        const int STDERRORHANDLE = -12;
        
        // class can not be created, so we can set colours 
        // without a variable
        private ConsoleColour()
        {
        }
        
        // colours that can be set
        [Flags]
        public enum ForeGroundColour
        {
            Black = 0x0000,
            Blue = 0x0001,
            Green = 0x0002, 
            Cyan = 0x0003,
            Red = 0x0004,
            Magenta = 0x0005,
            Yellow = 0x0006,
            Grey = 0x0007,
            White = 0x0008
        }

        public static bool SetForeGroundColour()
        {
            // default to a white-grey
            return SetForeGroundColour(ForeGroundColour.Grey);
        }

        public static bool SetForeGroundColour(ForeGroundColour foreGroundColour)
        {
            // default to a bright white-grey
            return SetForeGroundColour(foreGroundColour, true);
        }

        public static bool SetForeGroundColour(ForeGroundColour foreGroundColour, bool brightColours)
        {
            // get the current console handle
            IntPtr console = GetStdHandle(STDOUTPUTHANDLE);
            int colourMap;
            
            // if we want bright colours OR it with white
            if (brightColours) {
                colourMap = (int)foreGroundColour |
                    (int)ForeGroundColour.White;
            } else {
                colourMap = (int)foreGroundColour;
            }
            
            // call the api and return the result
            return SetConsoleTextAttribute(console, colourMap);
        }

        [DllImportAttribute("Kernel32.dll")]
        private static extern IntPtr GetStdHandle(int stdHandle);

        [DllImportAttribute("Kernel32.dll")]
        private static extern bool SetConsoleTextAttribute(IntPtr consoleOutput, int attributes);
    }
}
