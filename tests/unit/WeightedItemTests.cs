using CashReg.objects;
using Xunit;

namespace tests.unit
{
    /// <summary>
    /// Tests for the WeightedItem implementation
    /// </summary>
    public class WeightedItemTests
    {
        private static WeightedItem Foo()
        {
            return new WeightedItem() {
                name = "foo",
                weight = 1,
                value = 1
            };
        }
        [Fact]
        public void WeightedItem_TotalValue()
        {
            var item = Foo();
            Assert.Equal(1, item.TotalValue());
        }
        [Fact]
        public void WeightedItem_Update()
        {
            var item = Foo();
            item.Update(Foo());
            Assert.Equal(2, item.weight);
        }
    }
}