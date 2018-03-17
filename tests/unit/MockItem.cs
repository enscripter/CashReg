using CashReg.objects;

namespace tests.unit
{
    public class MockItem : ItemBase
    {
        private decimal val = 1.0m;
        public override decimal TotalValue()
        {
            return val;
        }
        public override void Update(ItemBase item)
        {
            val += 1.0m;
            return;
        }
        public MockItem()
        {
            name = "foo";
            value = 1;
        }
    }
}