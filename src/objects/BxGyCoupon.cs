using System.Collections.Generic;
using CashReg.objects;

namespace CashReg.objects
{
    /// <summary>
    /// A Buy 'X' get 'Y' coupon where if you have 'X' items you get 'Y' for free,
    /// this type of Coupon only applies to QuantityItems
    /// </summary>
    public class BxGyCoupon : CouponBase<QuantityItem>
    {
        /// <summary>
        /// The quantity to have to get Y for free
        /// </summary>
        public int X;
        /// <summary>
        /// The quantity to get for free
        /// </summary>
        public int Y;
        /// <summary>
        /// Calculates the total discount of am IEnumerable of Items
        /// </summary>
        /// <param name="items">The items to generate the discount from</param>
        /// <returns>The calculated discoun from the item</returns>
        public override float Discount(IEnumerable<QuantityItem> items)
        {
            throw new System.NotImplementedException();
        }
    }
}