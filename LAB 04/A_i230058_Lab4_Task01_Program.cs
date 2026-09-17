// Name: Shah Faisal
// Roll No: 23I-0058
using System;
class Program
{
    static void Main()
    {
        Prescription prescription = new Prescription();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n===== Pharmacy Management System =====");
            Console.WriteLine("1. Add Medicine");
            Console.WriteLine("2. Remove Medicine");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. View Prescription");
            Console.WriteLine("5. Check Expiry Warnings");
            Console.WriteLine("6. Set Customer Type");
            Console.WriteLine("7. Generate Final Bill");
            Console.WriteLine("8. Exit");
            Console.Write("Choose option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            switch (choice)
            {
                case 1:
                    Medicine med = new Medicine();
                    Console.Write("ID: ");
                    if (!int.TryParse(Console.ReadLine(), out med.MedicineId) || med.MedicineId <= 0)
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }
                    Console.Write("Name: ");
                    med.MedicineName = Console.ReadLine();
                    Console.Write("Category: ");
                    med.Category = Console.ReadLine();
                    Console.Write("Price: ");
                    if (!decimal.TryParse(Console.ReadLine(), out med.PricePerUnit) || med.PricePerUnit <= 0)
                    {
                        Console.WriteLine("Invalid price.");
                        break;
                    }
                    Console.Write("Stock Quantity: ");
                    if (!int.TryParse(Console.ReadLine(), out med.StockQuantity) || med.StockQuantity < 0)
                    {
                        Console.WriteLine("Invalid stock.");
                        break;
                    }
                    Console.Write("Quantity to purchase: ");
                    if (!int.TryParse(Console.ReadLine(), out med.Quantity) || med.Quantity <= 0)
                    {
                        Console.WriteLine("Invalid quantity.");
                        break;
                    }
                    Console.Write("Requires Prescription (true/false): ");
                    if (!bool.TryParse(Console.ReadLine(), out med.RequiresPrescription))
                    {
                        Console.WriteLine("Invalid input.");
                        break;
                    }
                    Console.Write("Expiry Date (DD/MM/YYYY): ");
                    med.ExpiryDate = Console.ReadLine();
                    if (!DateTime.TryParseExact(med.ExpiryDate, "dd/MM/yyyy",
                        null, System.Globalization.DateTimeStyles.None, out _))
                    {
                        Console.WriteLine("Invalid date format.");
                        break;
                    }
                    prescription.AddMedicine(med);
                    break;
                case 2:
                    Console.Write("Enter ID to remove: ");
                    if (int.TryParse(Console.ReadLine(), out int removeId))
                        prescription.RemoveMedicine(removeId);
                    break;
                case 3:
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("New Quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    prescription.UpdateQuantity(id, qty);
                    break;
                case 4:
                    prescription.ViewPrescription();
                    break;
                case 5:
                    prescription.CheckExpiryWarnings();
                    break;
                case 6:
                    Console.WriteLine("1. Senior (15%)");
                    Console.WriteLine("2. Regular (5%)");
                    Console.WriteLine("3. New (2%)");
                    if (int.TryParse(Console.ReadLine(), out int type))
                        prescription.SetCustomerType(type);
                    break;
                case 7:
                    Console.WriteLine("Grand Total: " + prescription.CalculateGrandTotal());
                    break;
                case 8:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}