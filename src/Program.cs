using System;
using System.Collections.Generic;
using System.Linq;
using CashReg.objects;

namespace CashReg
{
    class Program
    {
        private static string[] KNOWN_ACTIONS = {"help", "scan", "total", "coupon", "exit"};
        private static string FRIENDLY_ACTIONS => "\t" + KNOWN_ACTIONS.Aggregate((i,j) => i + "\n\t" + j);
        private static string COMPACT_ACTIONS => KNOWN_ACTIONS.Aggregate((i, j) => i + ", " + j);
        private static string UNSUPPORTED_ACTION = $"Unrecognized input please use one of the following:\n{FRIENDLY_ACTIONS}";
        private static string SCAN_INPUT_FORMAT = @"<quantity name value> where 'quantity' is a whole number if the item is priced per unit or a decimal value if it priced per weight unit";
        private static string COUPON_INPUT_FORMAT = $@"<coupon_type options> where coupon_type is either BXGY or %
            BXGY requires 3 options the item_name an X value and a Y where it's Buy X get Y free
                e.g. BXGY apple 1 1 # Buy 1 Get 1 free on apple
            % require a single options and thats the percent value
                e.g. % 10 # A 10% off total coupon";
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to CashReg type \"help\" to see more info");
            var register = new ItemRegister();
            var itemConverter = new StringItemBaseConverter();
            var couponConverter = new StringCouponBaseConverter();
            while (true)
            {
                Console.Write($"{COMPACT_ACTIONS} ? ");
                var action = Console.ReadLine();
                switch (action.ToLower().Trim())
                {
                    case "scan":
                        Console.Write("item > ");
                        var itemToAdd = itemConverter.Convert(Console.ReadLine());
                        if (itemToAdd == null) {
                            Console.WriteLine($"Invalid input\n\t{SCAN_INPUT_FORMAT}");
                            break;
                        }
                        register.Add(itemToAdd);
                        Console.Write($@"Added {"" + ((itemToAdd.GetType() == typeof(QuantityItem)) ? ((QuantityItem)itemToAdd).quantity : ((WeightedItem)itemToAdd).weight)} {itemToAdd.name}@{itemToAdd.value}");
                        break;
                    case "coupon":
                        Console.Write("coupon > ");
                        var couponLine = Console.ReadLine();
                        var couponToAdd = couponConverter.Convert(couponLine);
                        if (couponToAdd == null) {
                            Console.WriteLine($"Invalid input\n\t{COUPON_INPUT_FORMAT}");
                            break;
                        }
                        register.ApplyDiscount(couponToAdd);
                        break;
                    case "help":
                        Console.WriteLine($"Please use any of [{COMPACT_ACTIONS}]\nYou'll be prompted for additional details if necessary");
                        break;
                    case "total":
                        Console.WriteLine("CashReg Currrent Total");
                        Console.WriteLine($"\t{register.UniqueItemCount()} Unique Items");
                        register.ListItems();
                        Console.WriteLine($"\nSubTotal: {register.SubTotal()}\t Discount: {register.TotalDiscount()}");
                        Console.WriteLine($"Total: {register.Total() - register.TotalDiscount()}");
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(UNSUPPORTED_ACTION);
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
