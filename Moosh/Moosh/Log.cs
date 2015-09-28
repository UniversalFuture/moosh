using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moosh
{
    public static partial class Moosh
    {
        /// <summary>
        /// Creates a logger, with a designated output stream.
        /// </summary>
        /// <param name="stream">A stream to log output to.</param>
        /// <returns>Returns a new Moosh.Logger instance.</returns>
        public static Logger Logs(Stream stream)
        {
            return new Logger(stream);
        }

        /// <summary>
        /// Creates a logger, with a designated output filename.
        /// </summary>
        /// <param name="filename">An output filename to write to.</param>
        /// <param name="append">A boolean value indicating whether to append to an existing file or overwrite it.</param>
        /// <returns>Returns a new Moosh.Logger instance.</returns>
        public static Logger Logs(string filename, bool append = true)
        {
            return new Logger(filename, append);
        }

        /// <summary>
        /// A class that makes it easy to write a log to a file or stream.
        /// </summary>
        public class Logger : IDisposable
        {
            private StreamWriter sw;

            /// <summary>
            /// Initializes the logger, with a designated output stream.
            /// </summary>
            /// <param name="stream">A stream to log output to.</param>
            public Logger(Stream stream)
            {
                sw = new StreamWriter(stream);
            }

            /// <summary>
            /// Initializes the logger, with a designated output filename.
            /// </summary>
            /// <param name="filename">An output filename to write to.</param>
            /// <param name="append">A boolean value indicating whether to append to an existing file or overwrite it.</param>
            public Logger(string filename, bool append = true)
            {
                if (!File.Exists(filename) || !append)
                {
                    sw = new StreamWriter(filename);
                }
                else
                {
                    sw = new StreamWriter(File.Open(filename, FileMode.Append, FileAccess.Write));
                }
            }

            /// <summary>
            /// Logs an error to the output stream.
            /// </summary>
            /// <param name="error">The error to be reported.</param>
            public void Error(Exception error)
            {
                Error(error.Message);
                Log(error.ToString());
            }

            /// <summary>
            /// Logs an error to the output stream.
            /// </summary>
            /// <param name="error">Details surrounding the error.</param>
            public void Error(string error)
            {
                Log($"Error: {error}");
            }

            /// <summary>
            /// Logs a message to the output stream.
            /// </summary>
            /// <param name="message">A message to be recorded.</param>
            public void Log(string message)
            {
                sw.WriteLine(message);
                sw.Flush();
            }

            /// <summary>
            /// Warns of alarming circumstances. Logs to output stream.
            /// </summary>
            /// <param name="warning">A warning to be printed to the log.</param>
            public void Warning(string warning)
            {
                Log($"Warning: {warning}");
            }

            /// <summary>
            /// Logs a message to the output stream. Alias for Log.
            /// </summary>
            /// <param name="message">A message to be recorded.</param>
            public void Write(string message)
            {
                Log(message);
            }

            public void Dispose()
            {
                sw.Dispose();
            }
        }
    }
}
