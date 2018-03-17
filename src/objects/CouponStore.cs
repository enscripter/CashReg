using System.Collections.Generic;
using System.Linq;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A Store for coupons
    /// </summary>
    public class CouponStore : IStore<IDiscounter<ItemBase>>
    {
        private List<BxGyCoupon> itemDiscounts;
        private PercentOffCoupon percentOff;
        /// <summary>
        /// Get the total discounts for all coupons in this store
        /// </summary>
        /// <param name="items">The items to be discounted</param>
        /// <returns>The total discount against all items</returns>
        public decimal TotalDiscount(IEnumerable<ItemBase> items)
        {
            var total = 0m;
            foreach (var discount in itemDiscounts)
                total += discount.Discount(items);
            var quantifiedItems = items.Where(i => i.GetType() == typeof(QuantityItem));
            var weightedItems = items.Where(i => i.GetType() == typeof(WeightedItem));
            var totalValue = quantifiedItems.Sum(i => ((QuantityItem)i).quantity * ((QuantityItem)i).value);
            totalValue += weightedItems.Sum(i => (decimal)((WeightedItem)i).weight * ((WeightedItem)i).value);
            if (percentOff != null)
                total += ((decimal) percentOff.percent / 100) * (totalValue - total);
            return total;
        }
        /// <summary>
        /// Add a new Coupon to this store, coupons applicable to items can only have one
        /// </summary>
        /// <param name="item">The Coupon to be added</param>
        public void Add(IDiscounter<ItemBase> item)
        {
            if (item.GetType() == typeof(PercentOffCoupon)) {
                percentOff = (PercentOffCoupon)item;
                return;
            }
            if (item.GetType() == typeof(BxGyCoupon)) {
                var coupon = (BxGyCoupon) item;
                var existingCoupon = itemDiscounts.FirstOrDefault(i => i.itemName == coupon.itemName);
                if (existingCoupon != null)
                    itemDiscounts.Remove(existingCoupon);
                itemDiscounts.Add(coupon);
            }
        }
        /// <summary>
        /// Public constructor need to initialize the discounts
        /// </summary>
        public CouponStore()
        {
            itemDiscounts = new List<BxGyCoupon>();
        }
    }
}