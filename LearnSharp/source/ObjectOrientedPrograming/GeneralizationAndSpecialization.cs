using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSharp.ObjectOrientedPrograming
{
    using Logger;
    class GeneralizationAndSpecialization
    {
        private class Employee
        {
            public string Name { get; set; }

            public int EmpID { get; set; }

            public virtual void Work()
            {
                Logger.Info($"{Name} is working on an general task...");
            }
        }

        private class Manager : Employee
        {
            public int TeamSize { get; set; }
            
            public override void Work()
            {
                Logger.Info($"{Name} is managing a team of size {TeamSize}");
            }

            public void ConductMeeting()
            {
                Console.WriteLine($"{Name} is conducting a meeting.");
            }
        }

        private class Developer : Employee
        {
            public string ProgrammingLanguage { get; set; }

            public override void Work()
            {
                Console.WriteLine($"{Name} is writing code in {ProgrammingLanguage}.");
            }

            public void DebugCode()
            {
                Console.WriteLine($"{Name} is debugging code.");
            }
        }


        public static void SandBox()
        {

        }
    }
}
