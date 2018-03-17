using CashReg.objects;
using Xunit;

namespace tests
{
    /// <summary>
    /// Tests for the QuantityItem implementation
    /// </summary>
    public class QuantityItemTests
    {
        private static QuantityItem Foo()
        {
            return new QuantityItem() {
                name = "foo",
                quantity = 1,
                value = 1
            };
        }
        [Fact]
        public void QuantityItem_TotalValue()
        {
            var item = Foo();
            Assert.Equal(1.0, item.TotalValue());
        }
        [Fact]
        public void QuantityItem_Update()
        {
            var item = Foo();
            item.Update(Foo());
            Assert.Equal(2, item.quantity);
        }
    }
}