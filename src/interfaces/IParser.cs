namespace CashReg.interfaces
{
    public interface IParser<T, Q>
    {
        T parse(Q q);
    }
}