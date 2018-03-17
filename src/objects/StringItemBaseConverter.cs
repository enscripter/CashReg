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
            var inputParts = input.Split(' ');
            if (inputParts.Length != 3)
                return null;
            try {
                var quantity = Int32.Parse(inputParts[0]);
                var name = inputParts[1];
                var value = float.Parse(inputParts[2]);
                return new QuantityItem() {
                    quantity = quantity,
                    name = name,
                    value = value
                };
            } catch (Exception) {
                return null;
            }
        }
    }
}