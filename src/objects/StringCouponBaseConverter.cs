using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A Converter class that takes strings and converts them to CouponBase items
    /// </summary>
    public class StringCouponBaseConverter : IConverter<string, CouponBase<ItemBase>>
    {
        /// <summary>
        /// Takes in a string and converts it to a CouponBase<ItemBase>.
        /// String for is <type> <item_name> <options>
        /// Supported types:
        ///     BXGY (Buy X get Y for free)
        ///         opions X Y
        ///         e.g. Buy One Get One Free on apple
        ///             coupon > BXGY apple 1 1
        ///     % (Percentage of an iten)
        ///         options percent
        ///         e.g. (10% off apples)
        ///             coupon > % apple 10
        /// </summary>
        /// <param name="input">A string representation of a CouponBase<ItemBase></param>
        /// <returns>A CouponBase<ItemBase> instance represented by the string</returns>
        CouponBase<ItemBase> IConverter<string, CouponBase<ItemBase>>.Convert(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}