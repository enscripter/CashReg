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
    }
}