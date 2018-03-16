using CashReg.interfaces;
namespace CashReg.objects
{
    public abstract class StringParser<Q> : IParser<Q, string>
    {
        public abstract Q parse(string q);
    }
}