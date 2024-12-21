namespace DataStructureAndAlgorith.Algorithms
{
    using Logger;
    public class Algorithms
    {
        public static void FindCelebrity()
        {
            int[,] party =
            {
                { 0, 0, 1, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 1, 0 }
            };

            Logger.Info(party[0,0]);
        }
    }
}
