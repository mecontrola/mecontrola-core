﻿/***********************************************************************************
 * Copyright 2024 Me Controla
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***********************************************************************************/

using System;

namespace MeControla.Core.Builders;

/// <summary>
/// Abstract base class for building objects of type <typeparamref name="TObject"/>.
/// Implements a Builder design pattern that allows the creation of object instances with default values.
/// </summary>
/// <typeparam name="TBuilder">Type of the builder that inherits from <see cref="BaseBuilder{TBuilder, TObject}"/>.</typeparam>
/// <typeparam name="TObject">Type of the object to be built, which must be a class and have a public parameterless constructor.</typeparam>
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
public abstract class BaseBuilder<TBuilder, TObject> : IBuilder<TObject>
    where TBuilder : BaseBuilder<TBuilder, TObject>, new()
    where TObject : class, new()
{
    private readonly TObject obj;

    static BaseBuilder()
    { }

    /// <summary>
    /// Creates an instance of the object to be constructed.
    /// </summary>
    protected BaseBuilder()
    {
        obj = new TObject();

        FillDefaultValues(obj);
    }

    /// <summary>
    /// Fills the default values of the <paramref name="source"/>.
    /// This method must be implemented by subclasses to define the filling logic.
    /// </summary>
    /// <param name="source">Instance of the object that should be filled with default values.</param>
    protected abstract void FillDefaultValues(TObject source);

    /// <summary>
    /// Sets a information in the properties objects of type <typeparamref name="TObject"/>.
    /// </summary>
    /// <param name="action">Action to fill property object.</param>
    /// <returns>Instance of the builder of type <typeparamref name="TBuilder"/>.</returns>
    protected TBuilder Set(Action<TObject> action)
    {
        action?.Invoke(obj);
        return (TBuilder)this;
    }

    /// <summary>
    /// Finalizes the construction process and returns the built object instance.
    /// </summary>
    /// <returns>Instance of the object of type <typeparamref name="TObject"/>.</returns>
    public TObject ToBuild()
        => obj;
}