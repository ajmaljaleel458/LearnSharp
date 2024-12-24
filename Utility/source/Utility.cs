namespace Utility
{
    public class Time
    {
        public int[] GetCurrentTime()
        {
            return new int[] { DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second };
        }
    }
}