using System.Collections.Generic;
using System.Linq;

namespace CashReg.objects
{
    /// <summary>
    /// A Coupon whose applies to a percentage off of that item
    /// </summary>
    public class PercentOffCoupon : CouponBase
    {
        /// <summary>
        /// The percentage off of the Item
        /// </summary>
        public float percent;
        /// <summary>
        /// The method that return the total discount from an IEnumerable of items
        /// </summary>
        /// <param name="items">The items to generate the discount from</param>
        /// <returns>The calculated discoun from the item</returns>
        public override decimal Discount(IEnumerable<ItemBase> items)
            => items.Sum(i => i.value) * (decimal)percent / 100;
    }
}