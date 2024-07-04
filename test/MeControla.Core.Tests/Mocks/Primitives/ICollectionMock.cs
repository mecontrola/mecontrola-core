﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class ICollectionMock
    {
        public static ICollection<string> CreateEmpty()
            => Array.Empty<string>().ToList();

        public static ICollection<string> CreateFill()
            => DataMock.List123.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToList();

        public static ICollection<string> CreateFill2()
            => DataMock.List456.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToList();
    }
}