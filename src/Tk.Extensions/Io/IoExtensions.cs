using System.Diagnostics.CodeAnalysis;
using Tk.Extensions.Guards;

namespace Tk.Extensions.Io
{
    [ExcludeFromCodeCoverage]
    public static class IoExtensions
    {
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

        public static string AssertFileExists(this string path) =>
            path.ArgNotNull(nameof(path))
                .InvalidOpArg(p => !File.Exists(p), $"The file '{path}' does not exist.");
    }
}
