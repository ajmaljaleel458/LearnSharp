namespace LearnSharp.source
{
    using Logger;
    public class PrivateConstructors
    {
        private PrivateConstructors()
        {
            Logger.Info("Private Constructor Executed...");
        }

        public PrivateConstructors(string message)
        {
            Logger.Info($"Message : {message}");
        
        }

        public class Extented : PrivateConstructors
        {

        }

        public static void Execute()
        {
            PrivateConstructors privateConstructors = new PrivateConstructors();
        }
    }
}
