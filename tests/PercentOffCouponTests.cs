using System;
using System.Collections.Generic;
using CashReg.objects;
using Xunit;

namespace tests
{
    public class PercentOffCouponTests
    {
        [Fact]
        public void PercentOffCoupon_Discount_NoItems()
        {
            var coupon = new PercentOffCoupon() {
                percent = 10
            };
            Assert.Equal(0, coupon.Discount(new List<ItemBase>()));
        }
        [Fact]
        public void PercentOffCoupon_Discount_OneItem()
        {
            var coupon = new PercentOffCoupon() {
                percent = 10
            };
            var items = new List<ItemBase>();
            items.Add(new QuantityItem() { value = 1, quantity = 1});
            Assert.Equal(new Decimal(0.10), Math.Round((Decimal)coupon.Discount(items), 2));
        }
        [Fact]
        public void PercentOffCoupon_Discount_DifferentItemTypes()
        {
            var coupon = new PercentOffCoupon() {
                percent = 10
            };
            var items = new List<ItemBase>();
            items.Add(new QuantityItem() { value = 1, quantity = 1});
            items.Add(new WeightedItem() { value = 1, weight = 1});
            Assert.Equal(new Decimal(0.20), Math.Round((Decimal)coupon.Discount(items), 2));
        }
    }
}