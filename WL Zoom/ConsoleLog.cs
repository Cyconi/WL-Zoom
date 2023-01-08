using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoom
{
    internal class Con
    {
        internal static void Log(string Message)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("[");
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.Write("Zoom");
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write("] ");
            System.Console.ForegroundColor = ConsoleColor.White;            

            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine(Message);
            System.Console.ResetColor();
        }        
    }    
}

