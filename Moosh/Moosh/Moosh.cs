using System.Collections.Generic;
using System.Threading;

namespace Moosh
{
    /// <summary>
    /// A magical code class that will change your life forever.
    /// </summary>
    public static partial class Moosh
    {
        /// <summary>
        /// The default apartment state for asynchronous operations.
        /// </summary>
        public static ApartmentState ApartmentState = ApartmentState.MTA;

        /// <summary>
        /// Mostly redundant, but initializes a list from any IEnumerable.
        /// </summary>
        /// <param name="list">The list to initialize with.</param>
        /// <returns>Returns a new list.</returns>
        public static List<object> List(IEnumerable<object> list)
        {
            return new List<object>(list);
        }
    }
}
