using System;

namespace LearnCSharp.Application
{
    using Logger;
    using DataStructureAndAlgorith;
    public class Application
    {
        static void Main(string[] argumenst)
        {
            DataStructureAndAlgorith.Execute();

            Input.GetButtonDown(ConsoleKey.Enter);
        }
    }
}