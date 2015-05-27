using System;

namespace Myxo
{
    internal static class Writers
    {
	    public static void Passed(It it)
        {
            using (new ConsoleColorer(ConsoleColor.Green))
            {
                Console.WriteLine($"{it}: OK");
            }
        }

        public static void Failed(It it, string message)
        {
            using (new ConsoleColorer(ConsoleColor.Red))
            {
                Console.Error.WriteLine($"{it}: FAIL");
                Console.Error.WriteLine($"    {message}.");
            }
        }

        private class ConsoleColorer : IDisposable
        {
            public ConsoleColorer(ConsoleColor color)
            {
                Console.ForegroundColor = color;
            }
            public void Dispose()
            {
                Console.ResetColor();
            }
        }
    }
}