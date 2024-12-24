namespace LearnSharp.ObjectOrientedPrograming
{
    using Logger;
    public class Vector2
    {
        private int _x = 0xfffffff;

        protected int y = 324234;

        internal int z = 458;

        protected internal int a = 420873;
        public Vector2()
        {
            Logger.Info($"Value of x : {z}");
        }
    }

    public class Math : Vector2
    {
        public Math()
        {
            Logger.Info($"Value of x : {a}");
        }
    }

    public class AccessSpecifiers
    {
        public AccessSpecifiers()
        {
            Vector2 vector2 = new Vector2();

            Logger.Info($"Value of x : {vector2.a}");
        }
    }
}
