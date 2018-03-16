using CashReg.objects;
using Xunit;

namespace tests
{
    public class LinerParserTests
    {
        [Fact]
        public void LineParser_Parse_EmptyStringReturnsNull()
        {
            LineParser parser = new LineParser();
            Assert.Null(parser.parse(""));
        }
    }
}