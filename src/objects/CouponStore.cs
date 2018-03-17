using System.Collections.Generic;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A Store for coupons
    /// </summary>
    public class CouponStore : IStore<IDiscounter<ItemBase>>
    {
        private List<IDiscounter<ItemBase>> discounts;
        /// <summary>
        /// Get the total discounts for all coupons in this store
        /// </summary>
        /// <param name="items">The items to be discounted</param>
        /// <returns>The total discount against all items</returns>
        public decimal TotalDiscount(IEnumerable<ItemBase> items)
        {
            var total = 0m;
            foreach (var discount in discounts)
                total += discount.Discount(items);
            return total;
        }
        /// <summary>
        /// Add a new Coupon to this store, coupons applicable to items can only have one
        /// </summary>
        /// <param name="item">The Coupon to be added</param>
        public void Add(IDiscounter<ItemBase> item)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Public constructor need to initialize the discounts
        /// </summary>
        public CouponStore()
        {
            discounts = new List<IDiscounter<ItemBase>>();
        }
    }
}