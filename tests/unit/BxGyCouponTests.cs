using System.Collections.Generic;
using CashReg.objects;
using Xunit;

namespace tests.unit
{
    public class BxGyCouponTests
    {
        private static string FOO = "foo";
        private static List<QuantityItem> FooList(int quantity, float value){
            var items = new List<QuantityItem>();
            var testItemName = FOO;
            items.Add(new QuantityItem(){
                name = testItemName,
                quantity = quantity,
                value = value
            });
            return items;
        }
        private static BxGyCoupon FooCoup(int x, int y)
        {
            return new BxGyCoupon() {
                itemName = FOO,
                X = x,
                Y = y
            };
        }
        [Fact]
        public void BxGyCoupon_Discount_B1G1()
        {
            var coupon = FooCoup(1, 1);
            Assert.Equal(1, coupon.Discount(FooList(2, 1)));
        }
        [Fact]
        public void BxGyCoupon_Discount_B2G1()
        {
            var coupon = FooCoup(2, 1);
            Assert.Equal(1, coupon.Discount(FooList(3, 1)));
        }
        [Fact]
        public void BxGyCoupon_Discount_B2G2()
        {
            var coupon = FooCoup(2, 2);
            Assert.Equal(4, coupon.Discount(FooList(4, 2)));
        }
        [Fact]
        public void BxGyCoupon_Discount_NotEnoughForDiscount()
        {
            var coupon = FooCoup(2, 1);
            Assert.Equal(0, coupon.Discount(FooList(1, 1)));
        }
        [Fact]
        public void BxGyCoupon_Discount_NotEnoughForFullDiscount()
        {
            var coupon = FooCoup(1, 2);
            Assert.Equal(1, coupon.Discount(FooList(2, 1)));
        }
        [Fact]
        public void BxGyCoupon_Discount_NotEnoughForMulitpleFullDiscounts()
        {
            var coupon = FooCoup(1, 2);
            Assert.Equal(2, coupon.Discount(FooList(4, 1)));
        }
        [Fact]
        public void BxGyCoupon_Discount_NotEnoughForMultipleDiscounts()
        {
            var coupon = FooCoup(1, 1);
            Assert.Equal(2, coupon.Discount(FooList(5, 1)));
        }
    }
}