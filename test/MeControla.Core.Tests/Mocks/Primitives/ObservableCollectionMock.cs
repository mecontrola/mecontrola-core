using System.Collections.ObjectModel;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class ObservableCollectionMock
    {
        public static ObservableCollection<string> CreateEmpty()
            => [];

        public static ObservableCollection<string> CreateFill()
            => FillObservableCollection(DataMock.List123.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToArray());

        public static ObservableCollection<string> CreateFill2()
            => FillObservableCollection(DataMock.List456.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToArray());

        private static ObservableCollection<T> FillObservableCollection<T>(T[] values)
        {
            var obj = new ObservableCollection<T>();

            foreach (var value in values)
                obj.Add(value);

            return obj;
        }
    }
}