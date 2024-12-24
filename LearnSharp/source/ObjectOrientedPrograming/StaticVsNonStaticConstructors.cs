namespace LearnSharp.source.ObjectOrientedPrograming
{
    using Logger;
    public class StaticVsNonStaticConstructors
    {
        static StaticVsNonStaticConstructors()
        {
            Logger.Info("This time worked...");
        }
        public class Vector3
        {
            public static string className;

            public string instanceName;

            static Vector3()
            {
                Logger.Info("Static Constructor Executed...");

                className = "Vector3";
            }
            public Vector3()
            {
                Logger.Info("Instance  Constructor Executed...");

                instanceName = "zero";
            }
        }

        public static void Execute()
        {
            //Vector3 vector = new Vector3();

            Logger.Info(Vector3.className);
            //Logger.Info(vector.instanceName);
        }
    }
}
