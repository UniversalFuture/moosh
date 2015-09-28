using System;
using System.Collections.Generic;
using System.Text;
using M = Moosh.Moosh;

namespace MooshHttpGet
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a URL to GET: ");
            var url = Console.ReadLine();
            M.Get(url, (exc, sr) =>
            {
                Console.WriteLine(exc?.ToString() ?? sr.ReadToEnd());
            });
            Console.WriteLine("Press ENTER to quit.");
            Console.ReadLine();
        }
    }
}
