using CashReg.objects;
using Xunit;

namespace tests
{
    /// <summary>
    /// Tests for the QuantityItem implementation
    /// </summary>
    public class QuantityItemTests
    {
        [Fact]
        public void QuantityItem_TotalValue()
        {
            var item = new QuantityItem(){
                name = "foo",
                value = 10.0F,
                quantity = 1
            };
            Assert.Equal(10.0, item.TotalValue());
        }
    }
}