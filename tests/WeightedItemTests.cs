using CashReg.objects;
using Xunit;

namespace tests
{
    /// <summary>
    /// Tests for the WeightedItem implementation
    /// </summary>
    public class WeightedItemTests
    {
        [Fact]
        public void WeightedItem_GetValue()
        {
            var item = new WeightedItem(){
                name = "watermelon",
                value = 1.5F,
                weight = 1.0F
            };
            Assert.Equal(1.5, item.TotalValue());
        }
    }
}