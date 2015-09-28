using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Prints a string, and awaits the user's response.
        /// </summary>
        /// <param name="prompt">The string to print. ": " will be appended afterwards.</param>
        /// <returns>Console.ReadLine();</returns>
        public static string Prompt(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints a string and a newline, and awaits the user's response.
        /// </summary>
        /// <param name="prompt">The string to print. ":\n" will be appended afterwards.</param>
        /// <returns>Console.ReadLine();</returns>
        public static string PromptN(string prompt)
        {
            Console.WriteLine($"{prompt}:");
            return Console.ReadLine();
        }
    }
}
