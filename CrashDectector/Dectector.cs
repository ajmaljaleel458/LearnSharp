namespace CrashDectector
{
    using Logger;
    using System.IO;
    using System.IO.Pipes;

    public class Dectector
    {
        private NamedPipeServerStream _serverStream;

        private StreamWriter _serverStreamWriter;
        public Dectector()
        {
            Logger.Info("Crash Dectector Initilized...");

            SetUpNamePipeStream();

            _serverStreamWriter.Write("Hello There");
        }

        ~Dectector()
        {
            _serverStream.Disconnect();
            _serverStream.Close();
        }

        private static Dectector _detector;

        private void SetUpNamePipeStream()
        {
            _serverStream = new NamedPipeServerStream("CrashHandlerPipe");

            _serverStream.WaitForConnection();

            _serverStreamWriter = new StreamWriter(_serverStream)
                { AutoFlush = true };
        }

        public static void Init()
        {
            if (_detector == null)
                _detector = new Dectector();
        }
    }
}
