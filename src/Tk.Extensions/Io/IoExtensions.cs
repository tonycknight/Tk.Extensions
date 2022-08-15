using System.Diagnostics.CodeAnalysis;
using Tk.Extensions.Guards;

namespace Tk.Extensions.Io
{
    [ExcludeFromCodeCoverage]
    public static class IoExtensions
    {
        /// <summary>
        /// Resolves the given path to the current directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ResolveWorkingPath(this string path)
        {
            path.ArgNotNull(nameof(path));

            if (Path.IsPathRooted(path))
            {
                return path;
            }

            var workingPath = Directory.GetCurrentDirectory();

            return Path.Combine(workingPath, path);
        }

        /// <summary>
        /// Asserts that a file exists. If not, an exception is thrown.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>The given <paramref name="path"/> path.</returns>
        public static string AssertFileExists(this string path) =>
            path.ArgNotNull(nameof(path))
                .InvalidOpArg(p => !File.Exists(p), $"The file '{path}' does not exist.");
    }
}
