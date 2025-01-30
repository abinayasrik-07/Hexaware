using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    //John a software developer in Zed Axis Technology needs to check how many times a function is called.
    //For the same, he has been asked to create the function called “CountFunction”. Help John to create this function.

        internal class CountFunc
        {
            private static int callCount = 0;

            public static void CountFunction()
            {
                callCount++;
                Console.WriteLine($"CountFunction has been called {callCount} time(s).");
            }
        }
}
