using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LarionovClassesMessages
{
    internal class MyPrint
    {
        public void PrintString(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public void PrintError(string text)
        {
            PrintString(text, ConsoleColor.Red);
        }
        public void PrintWarning(string text)
        {
            PrintString(text, ConsoleColor.Yellow);
        }
        public void PrintSuccess(string text)
        {
            PrintString(text, ConsoleColor.Green);
        }
    }
}
