using System;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A Converter class that takes strings and converts them to CouponBase items
    /// </summary>
    public class StringCouponBaseConverter : IConverter<string, CouponBase>
    {
        /// <summary>
        /// Takes in a string and converts it to a CouponBase<ItemBase>.
        /// String for is <type> <options>...
        /// Supported types:
        ///     BXGY (Buy X get Y for free)
        ///         opions item_name X Y
        ///         e.g. Buy One Get One Free on apple
        ///             coupon > BXGY apple 1 1
        ///     % (Percentage of total)
        ///         options percent
        ///         e.g. (10% off apples)
        ///             coupon > % 10
        /// </summary>
        /// <param name="input">A string representation of a CouponBase<ItemBase></param>
        /// <returns>A CouponBase<ItemBase> instance represented by the string</returns>
        public CouponBase Convert(string input)
        {
            var inputParts = input.Split(' ');
            switch (inputParts[0]) {
                case "BXGY":
                    return new BxGyCoupon() {
                        itemName = inputParts[1],
                        X = Int32.Parse(inputParts[2]),
                        Y = Int32.Parse(inputParts[3])
                    };
                case "%":
                    return new PercentOffCoupon() {
                        percent = float.Parse(inputParts[1])
                    };
                default:
                    return null;
            }
        }
    }
}