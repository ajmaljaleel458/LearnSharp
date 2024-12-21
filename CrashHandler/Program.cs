namespace CrashHandler
{
    using System;
    using System.IO.Pipes;
    using System.IO;
    using Logger;

    internal class Handler
    {
        private NamedPipeClientStream _clientStream;

        private StreamReader _clientStreamrReader;

        public string Message
        {
            get { return _clientStreamrReader.ReadLine(); }
        }
        public Handler()
        {
            SetUpNamePipeStream();
        }

        ~Handler()
        {
            _clientStream.Close();
        }

        private void SetUpNamePipeStream()
        {
            _clientStream = new NamedPipeClientStream("CrashHandlerPipe");

            _clientStream.Connect();

            _clientStreamrReader = new StreamReader(_clientStream);
        }

        static void Main(string[] args)
        {
            Logger.Info("Crash Handler Initilized...");

            Handler handler = new Handler();

            Input.GetButtonDown(ConsoleKey.Enter);
        }
    }
}
