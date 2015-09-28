using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Parses a CSV string from an input stream.
        /// </summary>
        /// <param name="stream">A stream containing the CSV string to parse.</param>
        /// <returns>Returns a Moosh.CsvClass.</returns>
        public static CsvClass Csv(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                return Csv(sr.ReadToEnd());
            }
        }

        /// <summary>
        /// Parses a CSV string.
        /// </summary>
        /// <param name="csv">The CSV string to parse.</param>
        /// <returns>Returns a Moosh.CsvClass.</returns>
        public static CsvClass Csv(string csv)
        {
            var final = new CsvClass();
            foreach (Match match in Regex.Matches(csv, "([^,=]+)=([^,]+)"))
            {
                final.Add(match.Groups[1].Value, match.Groups[2].Value);
            }
            return final;
        }

        /// <summary>
        /// A representation of a CSV dictionary.
        /// </summary>
        public class CsvClass : Dictionary<string, string>
        {
            /// <summary>
            /// Serializes this instance into a CSV string.
            /// </summary>
            /// <returns>Returns a CSV string.</returns>
            public string Serialize()
            {
                string final = "";
                for (int i = 0; i < Count; i++)
                {
                    if (i > 0)
                        final += ',';
                    var key = Keys.ElementAt(i);
                    final += $"{key}={this[key]}";
                }
                return final;
            }
        }
    }
}
