using System;

namespace LearnSharp.ObjectOrientedPrograming
{
    using Logger;
    using System.Runtime.InteropServices;
    public class FileManager : IDisposable
    {
        private IntPtr _vector;

        private Vector3 _vec;
        public float Sum
        {
            get
            {
                float num1, num2, num3;

                num1 = GetVector3Field(_vector, 0);
                num2 = GetVector3Field(_vector, 1);
                num3 = GetVector3Field(_vector, 2);

                return (num1 + num2 + num3);
            }
        }

        private bool _isDisposed = false;

        public FileManager()
        {
            _vector = NewVector3(1f, 1f, 1f);

            _vec = new Vector3(1f, 1f, 1f);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _vec = null;
                }
                DeleteVector3(_vector);
                _isDisposed = true;
            }
        }

        ~FileManager()
        {
            Dispose(true);
            Logger.Info("Finalizer Invoked...");
        }

        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NewVector3(float x, float y, float z);

        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteVector3(IntPtr instance);

        [DllImport("Math.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GetVector3Field(IntPtr instance, int index);
    }
    public class FinalizeVsDispose
    {
        public static void Execute()
        {
            FileManager resources = new FileManager();
            resources.Dispose();
            resources.Dispose();
            Logger.Info($"Vector3 sum is : {resources.Sum}");
        }
    }
}
