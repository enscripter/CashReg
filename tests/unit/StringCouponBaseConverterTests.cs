using CashReg.objects;
using Xunit;

namespace tests.unit
{
    /// <summary>
    /// Tests for the StringCouponBaseConverter
    /// </summary>
    public class StringCouponBaseConverterTests
    {
        [Fact]
        public void StringCouponBaseConverter_Convert_EmptyStringIsNull()
        {
            var converter = new StringCouponBaseConverter();
            Assert.Null(converter.Convert(""));
        }
        [Fact]
        public void StringCouponBaseConverter_Convert_BXGY()
        {
            var converter = new StringCouponBaseConverter();
            var coupon = Assert.IsType<BxGyCoupon>(converter.Convert("BXGY apple 1 1"));
            Assert.Equal("apple", coupon.itemName);
            Assert.Equal(1, coupon.X);
            Assert.Equal(1, coupon.Y);
        }
        [Fact]
        public void StringCouponBaseConverter_Convert_NotEnoughInfo()
        {
            var converter = new StringCouponBaseConverter();
            Assert.Null(converter.Convert("BXGY"));
        }
        [Fact]
        public void StringCouponBaseConverter_Convert_TooMuchEnoughInfo()
        {
            var converter = new StringCouponBaseConverter();
            Assert.Null(converter.Convert("BXGY apple 1 1 1"));
        }
        [Fact]
        public void StringCouponBaseConverter_Convert_Percent()
        {
            var converter = new StringCouponBaseConverter();
            var coupon = Assert.IsType<PercentOffCoupon>(converter.Convert("% 10"));
            Assert.Equal(10, coupon.percent);
        }
    }
}