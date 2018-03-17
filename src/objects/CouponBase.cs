using System.Collections.Generic;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// Base class for a Coupon
    /// </summary>
    public abstract class CouponBase : IDiscounter<ItemBase>
    {
        /// <summary>
        /// A Coupon is a IDiscounter declare method as abstract
        /// </summary>
        /// <param name="items">The list of Items to get the discount of</param>
        /// <returns>The value of the discount that should be subtracted from a total</returns>
        public abstract decimal Discount(IEnumerable<ItemBase> items);
    }
}