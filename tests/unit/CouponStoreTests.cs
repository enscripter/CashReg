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
        private static List<QuantityItem> SingleQuantityList(int quantity, decimal value)
        {
            return new List<QuantityItem>()
            {
                new QuantityItem() {
                    name = "foo",
                    value = value,
                    quantity = quantity
                }
            };
        }
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
            Assert.Equal(1, couponStore.TotalDiscount(SingleQuantityList(2, 1)));
        }
        [Fact]
        public void CouponStore_Add_MultipleCoupons()
        {
            var couponStore = new CouponStore();
            couponStore.Add(new BxGyCoupon() {
                itemName = "foo",
                X = 1,
                Y = 1
            });
            couponStore.Add(new PercentOffCoupon() {
                percent = 10,
            });
            Assert.Equal(1.1m, couponStore.TotalDiscount(SingleQuantityList(2, 1)));
        }
        [Fact]
        public void CouponStore_Add_MultipleCouponsDifferentOrder()
        {
            var couponStore = new CouponStore();
            couponStore.Add(new PercentOffCoupon() {
                percent = 10,
            });
            couponStore.Add(new BxGyCoupon() {
                itemName = "foo",
                X = 1,
                Y = 1
            });
            Assert.Equal(1.1m, couponStore.TotalDiscount(SingleQuantityList(2, 1)));
        }
        [Fact]
        public void CouponStore_Add_CouponDoesNotApply() {
            var couponStore = new CouponStore();
            couponStore.Add(new BxGyCoupon() {
                itemName = "does_not_exist",
                X = 1,
                Y = 1
            });
            Assert.Equal(0, couponStore.TotalDiscount(SingleQuantityList(2, 1)));
        }
        [Fact]
        public void CouponStore_Add_SameCouponItemOverwritesLast()
        {
            var couponStore = new CouponStore();
            couponStore.Add(new BxGyCoupon() {
                itemName = "foo",
                X = 1,
                Y = 1
            });
            couponStore.Add(new BxGyCoupon() {
                itemName = "foo",
                X = 2,
                Y = 1
            });
            Assert.Equal(1, couponStore.TotalDiscount(SingleQuantityList(3, 1)));
        }
    }
}