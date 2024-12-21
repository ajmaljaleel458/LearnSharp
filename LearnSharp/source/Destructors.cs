namespace LearnSharp
{
    using Logger;
    using System;

    public class Destructors
    {
        public class Entity : IDisposable
        {
            private bool isDisposed;

            public Entity()
            {
                Logger.Info("Entity Instance Created...");
            }

            ~Entity()
            {
                Logger.Info("Entity Instance Destroyed...");
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!isDisposed)
                {
                    if (disposing)
                    {
                        Logger.Info("Managed Resources Destroyed by Dispose Method");
                    }

                    Logger.Info("Unmanaged Resources Destroyed by Dispose Method");

                    isDisposed = true;
                }
                else
                {
                    Logger.Info("Resources are Already Destroyed by Dispose Method");
                }
            }

            public void Dispose()
            {
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }
        public static void Execute()
        {
            Entity entity = null;

            try
            {
                entity = new Entity();
            }
            finally
            {
                entity.Dispose();
            }

            entity.Dispose();
        }
    }
}
