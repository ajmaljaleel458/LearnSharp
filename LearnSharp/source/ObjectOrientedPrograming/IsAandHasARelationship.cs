using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSharp.ObjectOrientedPrograming
{
    using Logger;
    public class IsAandHasARelationship
    {
        private class Engine
        {
            public void StartEngine()
            {
                Logger.Info("Engine Started!");
            }
        }

        // Non-Derived class : Vechile (Has-A Engine)
        private class Vehicle
        {
            public Engine engine = new Engine();
            public string Brand { get; set; }

            public int Weels { get; set; }

            public void Drive()
            {
                Logger.Info("Driving Vehicle!");
            }
        }

        // Derived class : Car (Is-A Vechile)
        private class Car : Vehicle
        {
            public int Seats { get; set; }

            public void Drift()
            {
                Logger.Info("Drifting!");
            }
        }

        // Derived class : Bike (Is-A Vechile)
        private class Bike : Vehicle
        {
            public int Seats { get; set; }

            public void Weelie()
            {
                Logger.Info("Weelieing!");
            }
        }
        public static void SandBox()
        {
            Bike bike = new Bike();

            bike.engine.StartEngine();
            bike.Drive();
            bike.Weelie();

            Car car = new Car();
            car.engine.StartEngine();
            car.Drive();
            car.Drift();
        }
    }
}
