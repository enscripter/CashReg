using System.Collections.Generic;
using CashReg.objects;
using Xunit;

namespace tests.unit
{
    /// <summary>
    /// Tests for the CouponStore
    /// </summary>
    public class CouponStoreTests
    {
        [Fact]
        public void CouponStore_EmptyHasZeroDiscount()
        {
            var couponStore = new CouponStore();
            Assert.Equal(0, couponStore.TotalDiscount(new List<ItemBase>(){}));
        }
        [Fact]
        public void CouponStore_Add_SingleCoupon()
        {
            var couponStore = new CouponStore();
            couponStore.Add(new BxGyCoupon() {
                itemName = "foo",
                X = 1,
                Y = 1
            });
            Assert.Equal(1, couponStore.TotalDiscount(new List<MockItem>(){new MockItem()}));
        }
    }
}