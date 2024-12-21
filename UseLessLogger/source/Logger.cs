using System;

namespace Logger
{
    public static class Input
    {
        public static bool GetButtonDown(ConsoleKey key)
        {
            if (Console.ReadKey().Key == key)
                return true;
            return false;
        }
    }

    public static class Logger
    {
        public static void Info(object message, bool endLine = true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;

            if (endLine) Console.WriteLine($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");
            else Console.Write($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");

            Console.ResetColor();
        }

        public static void Error(string message, bool endLine = true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            if (endLine) Console.WriteLine($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");
            else Console.Write($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");

            Console.ResetColor();
        }

        public static void Warn(string message, bool endLine = true)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (endLine) Console.WriteLine($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");
            else Console.Write($"[{DateTime.Now.ToString("h:mm:ss")}] : {message}");

            Console.ResetColor();
        }
    }
}


