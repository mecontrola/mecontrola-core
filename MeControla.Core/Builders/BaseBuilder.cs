using System;

namespace MeControla.Core.Builders
{
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class BaseBuilder<TBuilder, TObject> : IBuilder<TObject>
        where TBuilder : BaseBuilder<TBuilder, TObject>, new()
        where TObject : class, new()
    {
        private static TBuilder instance;

        protected TObject obj;

        protected virtual void Initialize()
            => obj = new TObject();

        protected TBuilder Set(Action<TObject> action)
        {
            action?.Invoke(obj);
            return instance;
        }

        public TObject ToBuild()
            => obj;

        public static TBuilder GetInstance()
        {
            instance = new();
            instance.Initialize();

            return instance;
        }
    }
}