﻿using System;

namespace MeControla.Core.Builders
{
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
    public abstract class BaseBuilder<TBuilder, TObject> : IBuilder<TObject>
        where TBuilder : class, new()
        where TObject : class
    {
        private static TBuilder instance;

        protected TObject obj;

        protected virtual void Initialize()
        { }

        public BaseBuilder()
            => Initialize();

        protected TBuilder Set(Action<TObject> action)
        {
            action?.Invoke(obj);
            return instance;
        }

        public TObject ToBuild()
            => obj;

        public static TBuilder GetInstance()
            => instance = new();
    }
}