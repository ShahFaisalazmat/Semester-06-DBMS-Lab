/*
 * Name: Shah Faisal
 * Roll Number: 23I-0058
 * Lab 3 - Task 3: Online Grocery Ordering System
 */
using System;
namespace A_i230058_Lab03_Task3
{   
    public class GroceryItem

    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string ExpiryDate { get; set; }

        public GroceryItem(int itemId, string itemName, string category,
                          decimal pricePerUnit, string unit, decimal quantity, string expiryDate)
        {
            ItemId = itemId;
            ItemName = itemName;
            Category = category;
            PricePerUnit = pricePerUnit;
            Unit = unit;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public decimal CalculateItemCost()
        {
            return PricePerUnit * Quantity;
        }
        public bool IsExpiringSoon()
        {
            try
            {
                DateTime expiryDate = DateTime.ParseExact(ExpiryDate, "dd/MM/yyyy", null);
                DateTime currentDate = DateTime.Now;
                TimeSpan daysUntilExpiry = expiryDate - currentDate;
                return daysUntilExpiry.TotalDays <= 3 && daysUntilExpiry.TotalDays >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
    public class GroceryCart
    {
        private GroceryItem[] items;
        private int count;
        private string appliedCoupon;
        private string deliverySlot;
        private decimal deliveryCharge;
        public GroceryCart()
        {
            items = new GroceryItem[5];
            count = 0;
            appliedCoupon = "";
            deliverySlot = "Not Selected";
            deliveryCharge = 0;
        }
        public void AddItem(GroceryItem newItem)
        {
            for (int i=0; i < count; i++)
            {
                if (items[i].ItemId == newItem.ItemId)
                {
                    items[i].Quantity += newItem.Quantity;
                    Console.WriteLine($"Updated quantity for {items[i].ItemName}. New quantity: {items[i].Quantity} {items[i].Unit}");
                    return;
                }
            }
            if (count >= items.Length)
            {
                ResizeArray();
            }

            items[count] = newItem;
            count++;
            Console.WriteLine($"{newItem.ItemName} added to cart!");
        }
        public void RemoveItem(int itemId)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].ItemId == itemId)
                {
                    string itemName = items[i].ItemName;
                    for (int j = i; j < count - 1; j++)
                    {
                        items[j] = items[j + 1];
                    }
                    items[count - 1] = null;
                    count--;
                    Console.WriteLine($"{itemName} removed from cart!");
                    return;
                }
            }
            Console.WriteLine($"Item with ID {itemId} not found in cart.");
        }
        public void UpdateQuantity(int itemId, decimal newQuantity)
        {
            if (newQuantity <= 0)
            {
                RemoveItem(itemId);
                return;
            }
            for (int i = 0; i < count; i++)
            {
                if (items[i].ItemId == itemId)
                {
                    items[i].Quantity = newQuantity;
                    Console.WriteLine($"Quantity updated for {items[i].ItemName}. New quantity: {items[i].Quantity} {items[i].Unit}");
                    return;
                }
            }
            Console.WriteLine($"Item with ID {itemId} not found in cart.");
        }
        public void ViewCart()
        {
            if (count == 0)
            {
                Console.WriteLine("\nYour cart is empty!");
                return;
            }
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("                                    YOUR CART");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"{"ID",-5} {"Item Name",-15} {"Category",-12} {"Price",-8} {"Unit",-8} {"Qty",-8} {"Expiry",-12} {"Total",-10}");
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i < count; i++)
            {
                GroceryItem item = items[i];
                Console.WriteLine($"{item.ItemId,-5} {item.ItemName,-15} {item.Category,-12} " +
                                  $"{item.PricePerUnit,7:F2} {item.Unit,-8} {item.Quantity,7:F2} " +
                                  $"{item.ExpiryDate,-12} {item.CalculateItemCost(),10:F2}");
            }
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"Subtotal: {CalculateSubtotal(),62:F2}");
            Console.WriteLine(new string('=', 80));
        }
        public void CheckExpiry()
        {
            if (count == 0)
            {
                Console.WriteLine("\nCart is empty. No items to check expiry.");
                return;
            }
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("                           EXPIRY WARNINGS");
            Console.WriteLine(new string('=', 80));

            bool hasExpiringItems = false;
            DateTime today = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
                if (items[i].IsExpiringSoon())
                {
                    DateTime expiryDate = DateTime.ParseExact(items[i].ExpiryDate, "dd/MM/yyyy", null);
                    TimeSpan daysLeft = expiryDate - today;

                    Console.WriteLine($"⚠️  WARNING: {items[i].ItemName} expires in {daysLeft.Days} day(s)!");
                    Console.WriteLine($"   Expiry Date: {items[i].ExpiryDate}, Quantity: {items[i].Quantity} {items[i].Unit}");
                    Console.WriteLine();
                    hasExpiringItems = true;
                }
            }
            if (!hasExpiringItems)
            {
                Console.WriteLine("No items expiring within 3 days.");
            }
            Console.WriteLine(new string('=', 80));
        }
        public decimal CalculateSubtotal()
        {
            decimal subtotal = 0;
            for (int i = 0; i < count; i++)
            {
                subtotal += items[i].CalculateItemCost();
            }
            return subtotal;
        }
        public void ApplyCoupon(string couponCode)
        {
            couponCode = couponCode.ToUpper().Trim();
            if (couponCode == "SAVE10" || couponCode == "SAVE100")
            {
                appliedCoupon = couponCode;
                Console.WriteLine($"Coupon '{couponCode}' applied successfully!");
            }
            else
            {
                Console.WriteLine($"Invalid coupon code. Available coupons: SAVE10, SAVE100");
            }
        }
        public decimal CalculateDiscount()
        {
            decimal subtotal = CalculateSubtotal();
            decimal discount = 0;

            if (appliedCoupon == "SAVE10")
            {
                discount = subtotal * 0.10m;
            }
            else if (appliedCoupon == "SAVE100")
            {
                discount = Math.Min(100, subtotal);
            }
            return discount;
        }
        public decimal CalculateTax()
        {
            decimal subtotal = CalculateSubtotal();
            decimal discount = CalculateDiscount();
            decimal amountAfterDiscount = subtotal - discount;
            return amountAfterDiscount * 0.02m;
        }
        public void SelectDeliverySlot(string slot)
        {
            slot = slot.ToUpper().Trim();

            switch (slot)
            {
                case "MORNING":
                    deliverySlot = "Morning";
                    deliveryCharge = 50;
                    Console.WriteLine("Morning delivery slot selected. Delivery charge: Rs. 50");
                    break;
                case "AFTERNOON":
                    deliverySlot = "Afternoon";
                    deliveryCharge = 30;
                    Console.WriteLine("Afternoon delivery slot selected. Delivery charge: Rs. 30");
                    break;
                case "EVENING":
                    deliverySlot = "Evening";
                    deliveryCharge = 40;
                    Console.WriteLine("Evening delivery slot selected. Delivery charge: Rs. 40");
                    break;
                default:
                    Console.WriteLine("Invalid slot. Please select: Morning, Afternoon, or Evening");
                    break;
            }
        }
        public decimal CalculateTotal()
        {
            decimal subtotal = CalculateSubtotal();
            decimal discount = CalculateDiscount();
            decimal afterDiscount = subtotal - discount;
            decimal tax = CalculateTax();
            return afterDiscount + tax + deliveryCharge;
        }
        public void DisplayFinalBill()
        {
            if (count == 0)
            {
                Console.WriteLine("\nCannot generate bill. Your cart is empty!");
                return;
            }
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("                                FINAL BILL");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"{"ID",-5} {"Item Name",-15} {"Qty",-8} {"Unit",-8} {"Price/Unit",-12} {"Total",-10}");
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i < count; i++)
            {
                GroceryItem item = items[i];
                Console.WriteLine($"{item.ItemId,-5} {item.ItemName,-15} {item.Quantity,7:F2} {item.Unit,-8} " +
                                  $"{item.PricePerUnit,10:F2}    {item.CalculateItemCost(),10:F2}");
            }
            decimal subtotal = CalculateSubtotal();
            decimal discount = CalculateDiscount();
            decimal afterDiscount = subtotal - discount;
            decimal tax = CalculateTax();
            decimal total = CalculateTotal();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"Subtotal: {subtotal,65:F2}");
            if (!string.IsNullOrEmpty(appliedCoupon))
            {
                Console.WriteLine($"Coupon Applied ({appliedCoupon}): -{discount,58:F2}");
                Console.WriteLine($"After Discount: {afterDiscount,59:F2}");
            }
            Console.WriteLine($"GST (2%): {tax,64:F2}");
            Console.WriteLine($"Delivery Slot: {deliverySlot,-15} Charge: {deliveryCharge,51:F2}");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"GRAND TOTAL: {total,62:F2}");
            Console.WriteLine(new string('=', 80));
        }
        private void ResizeArray()
        {
            int newSize = items.Length * 2;
            GroceryItem[] newArray = new GroceryItem[newSize];

            for (int i = 0; i < count; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
            Console.WriteLine($"Cart capacity increased to {newSize} items.");
        }
        public int GetItemCount()
        {
            return count;
        }
    }
    class Program
    {
        static GroceryCart cart = new GroceryCart();
        static int nextItemId = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("     ONLINE GROCERY ORDERING SYSTEM");
            Console.WriteLine("================================================");
            Console.WriteLine("Name: Shah Faisal");
            Console.WriteLine("Roll Number: 23I-0058");
            Console.WriteLine("================================================\n");
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        AddGroceryItem();
                        break;
                    case "2":
                        RemoveGroceryItem();
                        break;
                    case "3":
                        UpdateGroceryQuantity();
                        break;
                    case "4":
                        cart.ViewCart();
                        break;
                    case "5":
                        cart.CheckExpiry();
                        break;
                    case "6":
                        ApplyCoupon();
                        break;
                    case "7":
                        SelectDeliverySlot();
                        break;
                    case "8":
                        cart.DisplayFinalBill();
                        break;
                    case "9":
                        exit = true;
                        Console.WriteLine("Thank you for shopping with us! Have a great day!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1-9.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("            GROCERY ORDER MENU");
            Console.WriteLine("================================================");
            Console.WriteLine("1.  Add Grocery Item");
            Console.WriteLine("2.  Remove Item");
            Console.WriteLine("3.  Update Quantity");
            Console.WriteLine("4.  View Cart");
            Console.WriteLine("5.  Check Expiry Warnings");
            Console.WriteLine("6.  Apply Coupon");
            Console.WriteLine("7.  Select Delivery Slot");
            Console.WriteLine("8.  Display Final Bill");
            Console.WriteLine("9.  Exit");
            Console.WriteLine("================================================");
            if (cart.GetItemCount() > 0)
            {
                Console.WriteLine($"Items in cart: {cart.GetItemCount()}");
            }
            Console.WriteLine("================================================");
        }
        static void AddGroceryItem()
        {
            Console.WriteLine("--- ADD GROCERY ITEM ---");
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("❌ Item name cannot be empty!");
                return;
            }
            Console.WriteLine("\nCategories: Dairy, Fruits, Vegetables, Grains, Meat, Beverages, Snacks, Other");
            Console.Write("Enter Category: ");
            string category = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(category))
            {
                category = "Other";
            }
            Console.Write("Enter Price Per Unit (Rs.): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
            {
                Console.WriteLine("Invalid price! Must be greater than 0.");
                return;
            }
            Console.WriteLine("\nUnits: kg, liter, piece, dozen, packet, box");
            Console.Write("Enter Unit: ");
            string unit = Console.ReadLine().Trim().ToLower();
            if (string.IsNullOrEmpty(unit))
            {
                unit = "piece";
            }
            Console.Write($"Enter Quantity (in {unit}): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity! Must be greater than 0.");
                return;
            }
            Console.Write("Enter Expiry Date (DD/MM/YYYY): ");
            string expiryDate = Console.ReadLine().Trim();
            if (!IsValidDate(expiryDate))
            {
                Console.WriteLine("Invalid date format! Please use DD/MM/YYYY.");
                return;
            }
            GroceryItem newItem = new GroceryItem(
                nextItemId++,
                name,
                category,
                price,
                unit,
                quantity,
                expiryDate
            );
            cart.AddItem(newItem);
        }
        static void RemoveGroceryItem()
        {
            Console.WriteLine("--- REMOVE ITEM ---");
            if (cart.GetItemCount() == 0)
            {
                Console.WriteLine("Cart is empty! No items to remove.");
                return;
            }
            cart.ViewCart();
            Console.Write("\nEnter Item ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId <= 0)
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            cart.RemoveItem(itemId);
        }
        static void UpdateGroceryQuantity()
        {
            Console.WriteLine("--- UPDATE QUANTITY ---");

            if (cart.GetItemCount() == 0)
            {
                Console.WriteLine("Cart is empty! No items to update.");
                return;
            }

            cart.ViewCart();
            Console.Write("\nEnter Item ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int itemId) || itemId <= 0)
            {
                Console.WriteLine("Invalid ID!");
                return;
            }

            Console.Write("Enter new quantity: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal quantity))
            {
                Console.WriteLine("Invalid quantity!");
                return;
            }

            cart.UpdateQuantity(itemId, quantity);
        }
        static void ApplyCoupon()
        {
            Console.WriteLine("--- APPLY COUPON ---");
            Console.WriteLine("Available Coupons:");
            Console.WriteLine("  SAVE10 - 10% discount on all items");
            Console.WriteLine("  SAVE100 - Rs. 100 discount on all items");
            Console.Write("\nEnter coupon code: ");
            string coupon = Console.ReadLine().Trim();
            cart.ApplyCoupon(coupon);
        }
        static void SelectDeliverySlot()
        {
            Console.WriteLine("--- SELECT DELIVERY SLOT ---");
            Console.WriteLine("Available Slots:");
            Console.WriteLine("  Morning   - Rs. 50");
            Console.WriteLine("  Afternoon - Rs. 30");
            Console.WriteLine("  Evening   - Rs. 40");

            Console.Write("\nSelect delivery slot (Morning/Afternoon/Evening): ");
            string slot = Console.ReadLine().Trim();
            cart.SelectDeliverySlot(slot);
        }
        static bool IsValidDate(string date)
        {
            try
            {
                DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                if (parsedDate < DateTime.Now.AddDays(-1))
                {
                    Console.WriteLine("Item is already expired!");
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}