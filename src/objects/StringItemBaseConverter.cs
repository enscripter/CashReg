using System;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// An implementation of a Converter from string to ItemBase
    /// </summary>
    public class StringItemBaseConverter : IConverter<string, ItemBase>
    {
        /// <summary>
        /// Convert a string to a ItemBase
        /// </summary>
        /// <param name="input">The string to convert to an ItemBase</param>
        /// <returns>An ItemBase instance based off the input string</returns>
        public ItemBase Convert(string input)
        {
            if (input == "")
                return null;
            throw new NotImplementedException();
        }
    }
}