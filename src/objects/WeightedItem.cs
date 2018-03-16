namespace CashReg.objects
{
    /// <summary>
    /// An item that has a corresponding weight to calculate cost
    /// </summary>
    public class WeightedItem : ItemBase
    {
        /// <summary>
        /// The weight of the Item
        /// </summary>
        public float weight;
        /// <summary>
        /// Calcluate the total value of this Item
        /// </summary>
        /// <returns>The total value of this Item</returns>
        public override float TotalValue()
        {
            throw new System.NotImplementedException();
        }
    }
}