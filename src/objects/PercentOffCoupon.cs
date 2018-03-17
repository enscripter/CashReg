using System.Collections.Generic;

namespace CashReg.objects
{
    /// <summary>
    /// A Coupon whose applies to a percentage off of that item
    /// </summary>
    public class PercentOffCoupon : CouponBase<ItemBase>
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
        public override float Discount(IEnumerable<ItemBase> items)
        {
            throw new System.NotImplementedException();
        }
    }
}