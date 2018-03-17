using System;
using CashReg.objects;
using Xunit;

namespace tests.unit
{
    /// <summary>
    /// Tests for the StringItemConverter class
    /// </summary>
    public class StringItemBaseConverterTests
    {
        [Fact]
        public void StringItemConverter_Convert_EmptyStringIsNull()
        {
            Assert.Null(new StringItemBaseConverter().Convert(""));
        }
        [Fact]
        public void StringItemBaseConverter_Convert_QuantityItem()
        {
            var converter = new StringItemBaseConverter();
            var item = Assert.IsType<QuantityItem>(converter.Convert("1 apple 1.99"));
            Assert.Equal(1, item.quantity);
            Assert.Equal("apple", item.name);
            Assert.Equal(1.99, Math.Round(item.value, 2));
        }
    }
}