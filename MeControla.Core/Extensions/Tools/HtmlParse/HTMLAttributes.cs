using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tools.HtmlParse
{
    public class HTMLAttributes : Dictionary<string, string>
    {
        public new bool ContainsValue(string value)
            => !string.IsNullOrWhiteSpace(GetKeyByValue(value));

        public string GetKeyByValue(string value)
            => this.Where(x => x.Value.Split(" ").Any(val => val.Contains(value)))
                   .Select(x => x.Key)
                   .FirstOrDefault();

        public bool ExistsAllKeys(HTMLAttributes parameters)
            => parameters == null
             ? false
             : Keys.Intersect(parameters.Keys).Count() == parameters.Keys.Count;

        public bool ExistsAllValues(HTMLAttributes parameters)
        {
            if (parameters == null)
                return false;

            if (!ExistsAllKeys(parameters))
                return false;

            var finded = true;
            foreach (var keyValuePair in parameters)
            {
                var valueExpected = parameters[keyValuePair.Key].Split(" ");
                finded &= this[keyValuePair.Key].Split(" ").Intersect(valueExpected).Count()
                       == valueExpected.Length;

                if (!finded)
                    break;
            }

            return finded;
        }
    }
}