using System.IO;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Reads or creates a CSV settings file with the desired name.
        /// </summary>
        /// <param name="name">The desired name for these settings.</param>
        /// <returns>Returns a Moosh.SettingsClass instance.</returns>
        public static SettingsClass Settings(string name = "settings")
        {
            var fn = $"{name}.csv";
            var final = new SettingsClass(fn);
            if (File.Exists(fn))
            {
                foreach (var pair in Csv(fn))
                {
                    final.Add(pair.Key, pair.Value);
                }
            }
            return final;
        }

        /// <summary>
        /// A class that makes it easy to store and update settings in CSV files.
        /// </summary>
        public class SettingsClass : CsvClass
        {
            /// <summary>
            /// The file that will store these settings.
            /// </summary>
            public string Filename { get; set; }

            /// <summary>
            /// Initializes a Moosh.Settings object from the specified filename.
            /// </summary>
            /// <param name="fileName">The filename to read and write.</param>
            public SettingsClass(string fileName)
            {
                Filename = fileName;
            }

            public new void Add(string key, string value)
            {
                base.Add(key, value);
                File.WriteAllText(Filename, Serialize());
            }
        }
    }
}
