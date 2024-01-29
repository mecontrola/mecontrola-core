using MeControla.Core.Extensions.JsonSerializers;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MeControla.Core.Tests.Extensions.JsonSerializers
{
    public class JsonSerializerAnonymousExtensionTests
    {
        private const string DATE_FORMAT = "yyyyMMddHHmmss";

        [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve converter um objeto anônimo para um tipado.")]
        public void DeveConverterObjetoAnonimoParaConcreto()
        {
            var expectd = new ClsTest { Name = "Test" };
            var actual = $@"{{""Name"":""Test""}}".ToAnonymousType(new ClsTest());

            Assert.Equal(expectd, actual, new ClsTestComparer());
        }

        [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve converter um objeto anônimo para um tipado utilizando JsonSerializer.")]
        public void DeveConverterObjetoComDataOutroFormatoAnonimoParaConcreto()
        {
            var date = new DateTime(2020, 1, 1);
            var expectd = new ClsTest { Name = "Test", Date = date };
            var actual = $@"{{""Name"":""Test"",""Date"":""{date.ToString(DATE_FORMAT)}""}}".ToAnonymousType(new ClsTest(), GetTradingDaySerializer());

            Assert.Equal(expectd, actual, new ClsTestComparer());
        }

        private static JsonSerializerOptions GetTradingDaySerializer()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverter(DATE_FORMAT));

            return options;
        }

        class ClsTestComparer : IEqualityComparer<ClsTest>
        {
            public bool Equals(ClsTest item1, ClsTest item2)
            {
                if (ReferenceEquals(item1, item2))
                    return true;

                return item1 is not null
                    && item2 is not null
                    && item1.Date == item2.Date
                    && item1.Name == item2.Name;
            }

            public int GetHashCode(ClsTest item)
            {
                return item is null
                     ? 0
                     : item.Name.GetHashCode() ^ item.Date.GetHashCode();
            }
        }

        class ClsTest
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    }
}