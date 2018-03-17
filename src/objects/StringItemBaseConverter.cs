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
                var name = inputParts[1];
                var value = decimal.Parse(inputParts[2]);
                int quantity = 0;
                var weight = 0.0F;
                if (Int32.TryParse(inputParts[0], out quantity)) {
                    if (quantity == 0)
                        throw new FormatException();
                    return new QuantityItem() {
                        quantity = quantity,
                        name = name,
                        value = value
                    };
                }
                else if (float.TryParse(inputParts[0], out weight)) {
                    if (weight == 0)
                        throw new FormatException();
                    return new WeightedItem() {
                        weight = weight,
                        name = name,
                        value = value
                    };
                }
            } catch (Exception) {
                return null;
            }
            return null;
        }
    }
}