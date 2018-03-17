using Xunit;
using CashReg.objects;

namespace tests
{
    /// <summary>
    /// Tests for the ItemRegister concrete implementation
    /// </summary>
    public class ItemRegisterTest
    {
        [Fact]
        public void ItemRegister_UniqueItemCount_NoItems()
        {
            var register = new ItemRegister();
            Assert.Equal(0, register.UniqueItemCount());
        }
        [Fact]
        public void ItemRegister_UniqueItemCount_SingleItem()
        {
            var register = new ItemRegister();
            register.Add(new FooItem());
            Assert.Equal(1, register.UniqueItemCount());
        }
        [Fact]
        public void ItemRegister_UniqueItemCount_MultipleItems()
        {
            var register = new ItemRegister();
            register.Add(new FooItem());
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
        public void ItemRegister_Total_TenItems()
        {
            var itemRegister = new ItemRegister();
            for (int i = 0; i < 10; i++)
                itemRegister.Add(new FooItem());
            Assert.Equal(10.0, itemRegister.Total());
        }
        [Fact]
        public void ItemRegister_Add_WeightedItem()
        {
            var register = new ItemRegister();
            register.Add(new WeightedItem(){
                weight = 1,
                value = 1
            });
            Assert.Equal(1, register.Total());
        }
        [Fact]
        public void ItemRegister_Add_QuantityItem()
        {
            var register = new ItemRegister();
            register.Add(new QuantityItem(){
                quantity = 1,
                value = 1
            });
            Assert.Equal(1, register.Total());
        }
        [Fact]
        public void ItemRegister_Add_DifferentItems()
        {
            var register = new ItemRegister();
            register.Add(new QuantityItem(){
                name = "quantity",
                quantity = 1,
                value = 1
            });
            register.Add(new WeightedItem(){
                name = "weighted",
                weight = 1,
                value = 1
            });
            register.Add(new FooItem());
            Assert.Equal(3, register.Total());
        }
    }
}