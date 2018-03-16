namespace CashReg.objects
{
    public class LineParser : StringParser<Token>
    {
        public override Token parse(string input)
        {
            if (input == "")
                return null;
            return new Token();
        }
    }
}