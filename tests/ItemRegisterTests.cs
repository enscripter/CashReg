using Xunit;
using CashReg.objects;

namespace tests
{
    /// <summary>
    /// Tests for the ItemRegister concrete implementation
    /// </summary>
    public class ItemRegisterTest
    {
        private class FooItem : ItemBase
        {
            public override float TotalValue()
            {
                return 1.0F;
            }
        }
        [Fact]
        public void ItemRegister_UniqueItemCount_NoItems()
        {
            var register = new ItemRegister();
            Assert.Equal(0, register.UniqueItemCount());
        }
        [Fact]
        public void ItemRegister_Add_SingleItem()
        {
            var register = new ItemRegister();
            register.Add(new FooItem());
            Assert.Equal(1, register.UniqueItemCount());
        }
        [Fact]
        public void ItemRegister_Total_SingleItem()
        {
            var itemRegister = new ItemRegister();
            itemRegister.Add(new FooItem());
            Assert.Equal(1.0, itemRegister.Total());
        }
        [Fact]
        public void ItemRegister_Total_TenItem()
        {
            var itemRegister = new ItemRegister();
            for (int i = 0; i < 10; i++)
                itemRegister.Add(new FooItem());
            Assert.Equal(10.0, itemRegister.Total());
        }
    }
}