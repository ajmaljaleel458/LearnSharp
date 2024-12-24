using System;

namespace LearnCSharp.Application
{
    using Logger;
    using DataStructureAndAlgorith;
    using LearnSharp.ObjectOrientedPrograming;
    using Utility;
    public class Application
    {
        public static void Main(String[] args)
        {
            DataStructureAndAlgorith.Execute();

            Input.GetButtonDown(ConsoleKey.Enter);
        }
    }
}