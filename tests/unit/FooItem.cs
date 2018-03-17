using CashReg.objects;

namespace tests
{
    public class FooItem : ItemBase
    {
        private float val = 1.0F;
        public override float TotalValue()
        {
            return val;
        }
        public override void Update(ItemBase item)
        {
            val += 1.0F;
            return;
        }
        public FooItem()
        {
            name = "foo";
            value = 1;
        }
    }
}