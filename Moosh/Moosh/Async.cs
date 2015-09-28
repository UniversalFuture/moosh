using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Asynchronously runs a function.
        /// </summary>
        /// <param name="func">The function to be run on a different thread.</param>
        public static void Async(Action func)
        {
            var thread = new Thread(new ThreadStart(func));
            thread.SetApartmentState(ApartmentState);
            thread.Start();
        }

        /// <summary>
        /// Asynchronously runs a function with a single argument.
        /// </summary>
        /// <param name="func">The function to be run on a different thread.</param>
        /// <param name="arg">The argument to run the action on.</param>
        public static void Async<T>(Action<T> func, T arg)
        {
            var thread = new Thread(() =>
            {
                func(arg);
            });
            thread.SetApartmentState(ApartmentState);
            thread.Start();
        }

        /// <summary>
        /// Asynchronously runs a function with unlimited arguments.
        /// </summary>
        /// <param name="func">The function to be run on a different thread.</param>
        /// <param name="args">The arguments to run the action on.</param>
        public static void Async(Delegate func, params object[] args)
        {
            var thread = new Thread(x =>
            {
                func.DynamicInvoke(x);
            });
            thread.SetApartmentState(ApartmentState);
            thread.Start(args);
        }
    }
}
