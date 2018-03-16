namespace CashReg.objects
{
    /// <summary>
    /// The abstract base class for what an Item should look like
    /// </summary>
    public abstract class ItemBase
    {
        /// <summary>
        /// The name of this ItemBase
        /// </summary>
        public string name;
        /// <summary>
        /// What the value of this ItemBase is
        /// </summary>
        public float value;
        /// <summary>
        /// Get the total value of this ItemBase
        /// </summary>
        /// <returns>The value of this ItemBase</returns>
        public abstract float TotalValue();
    }
}