using BenchmarkDotNet.Running;

namespace Tk.Extensions.Benchmarks 
{
    public class Program
    {
        public int Main(string[] args)
        {
            try
            {
                BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

                return 0;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
                return 1;
            }
        }
    }
}