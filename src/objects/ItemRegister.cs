using System;
using System.Collections.Generic;
using System.Linq;
using CashReg.interfaces;

namespace CashReg.objects
{
    /// <summary>
    /// A concrete Register implementation for ItemBase items
    /// </summary>
    public class ItemRegister : IRegister<ItemBase>
    {
        private CouponStore couponStore;
        private List<ItemBase> items;
        /// <summary>
        /// Add an ItemBase to this Register
        /// </summary>
        /// <param name="item">The ItemBase to be added</param>
        public void Add(ItemBase item)
        {
            var existingItem = items.FirstOrDefault(i => i.name == item.name);
            if (existingItem != null)
                existingItem.Update(item);
            else
                items.Add(item);
        }
        /// <summary>
        /// Get the total of all ItemBase item in this register
        /// </summary>
        /// <returns>The total value of all ItemBase items minus any Discounts</returns>
        public decimal Total()
        {
            return SubTotal() - TotalDiscount();
        }
        /// <summary>
        /// Apply a discount to this register
        /// </summary>
        /// <param name="discount">The discount to be applied</param>
        public void ApplyDiscount(IDiscounter<ItemBase> discount)
        {
            couponStore.Add(discount);
        }
        /// <summary>
        /// Wrapper method around Total Discount of the coupon store
        /// </summary>
        /// <returns>A value of units saved</returns>
        public decimal TotalDiscount()
        {
            return couponStore.TotalDiscount(items);
        }
        /// <summary>
        /// The number of unique items in this register
        /// </summary>
        /// <returns></returns>
        public int UniqueItemCount()
        {
            return items.Count;
        }
        /// <summary>
        /// Print all the items to the console with values and quantites
        /// </summary>
        public void ListItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"\t{item}");
            }
        }
        /// <summary>
        /// Public constructor for this register
        /// </summary>
        public ItemRegister()
        {
            items = new List<ItemBase>();
            couponStore = new CouponStore();
        }

        internal decimal SubTotal()
        {
            decimal total = 0;
            foreach (ItemBase item in items)
                total += item.TotalValue();
            return total;
        }
    }
}