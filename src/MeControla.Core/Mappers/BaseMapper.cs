/***********************************************************************************
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

namespace MeControla.Core.Mappers;

/// <summary>
/// Provides a base implementation for mapping class of type <typeparamref name="TParam"/> 
/// to class of type <typeparamref name="TResult"/>.
/// </summary>
/// <typeparam name="TParam">The source type to be mapped from. Must be a reference type.</typeparam>
/// <typeparam name="TResult">The destination type to be mapped to. Must be a reference type.</typeparam>
#if !DEBUG
[System.Diagnostics.DebuggerStepThrough]
#endif
public abstract class BaseMapper<TParam, TResult>
    : InternalBaseMapper<TParam, TResult>, IMapper<TParam, TResult>
     where TParam : class
     where TResult : class
{ }