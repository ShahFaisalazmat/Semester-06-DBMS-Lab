// Name: Shah Faisal
// Roll No: 23I-0058
using System;
public class Prescription
{
    private Medicine[] medicines;
    private int count;
    private int customerType;
    // 1 = Senior
    // 2 = Regular
    // 3 = New
    public Prescription()
    {
        medicines = new Medicine[5];
        count = 0;
    }
    private void ResizeArray()
    {
        Medicine[] newArray = new Medicine[medicines.Length * 2];
        for (int i = 0; i < medicines.Length; i++)
        {
            newArray[i] = medicines[i];
        }
        medicines = newArray;
    }
    public void SetCustomerType(int type)
    {
        if (type >= 1 && type <= 3)
            customerType = type;
        else
            Console.WriteLine("Invalid customer type.");
    }
    public void AddMedicine(Medicine med)
    {
        if (med.IsExpired())
        {
            Console.WriteLine("Error: Medicine is expired.");
            return;
        }
        if (med.Quantity > med.StockQuantity)
        {
            Console.WriteLine("Error: Insufficient stock.");
            return;
        }
        if (med.RequiresPrescription)
        {
            Console.WriteLine("Warning: Prescription required.");
        }
        for (int i = 0; i < count; i++)
        {
            if (medicines[i].MedicineId == med.MedicineId)
            {
                medicines[i].Quantity += med.Quantity;
                return;
            }
        }
        if (count == medicines.Length)
            ResizeArray();
        medicines[count++] = med;
        Console.WriteLine("Medicine added successfully.");
    }
    public void RemoveMedicine(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (medicines[i].MedicineId == id)
            {
                for (int j = i; j < count - 1; j++)
                    medicines[j] = medicines[j + 1];
                count--;
                Console.WriteLine("Medicine removed.");
                return;
            }
        }
        Console.WriteLine("Medicine not found.");
    }
    public void UpdateQuantity(int id, int newQty)
    {
        for (int i = 0; i < count; i++)
        {
            if (medicines[i].MedicineId == id)
            {
                if (newQty <= 0)
                {
                    RemoveMedicine(id);
                    return;
                }
                if (newQty > medicines[i].StockQuantity)
                {
                    Console.WriteLine("Insufficient stock.");
                    return;
                }
                medicines[i].Quantity = newQty;
                Console.WriteLine("Quantity updated.");
                return;
            }
        }

        Console.WriteLine("Medicine not found.");
    }
    public void ViewPrescription()
    {
        if (count == 0)
        {
            Console.WriteLine("No medicines added.");
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Medicine m = medicines[i];
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Name: " + m.MedicineName);
            Console.WriteLine("Category: " + m.Category);
            Console.WriteLine("Price: " + m.PricePerUnit);
            Console.WriteLine("Quantity: " + m.Quantity);
            Console.WriteLine("Stock Available: " + m.StockQuantity);
            Console.WriteLine("Requires Prescription: " + m.RequiresPrescription);
            Console.WriteLine("Expiry Date: " + m.ExpiryDate);
            Console.WriteLine("Item Total: " + m.CalculateMedicineTotal());
        }
    }
    public void CheckExpiryWarnings()
    {
        DateTime fixedDate = new DateTime(2026, 2, 4);
        for (int i = 0; i < count; i++)
        {
            DateTime expiry;

            if (DateTime.TryParseExact(medicines[i].ExpiryDate, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out expiry))
            {
                double daysLeft = (expiry - fixedDate).TotalDays;

                if (daysLeft <= 7 && daysLeft >= 0)
                {
                    Console.WriteLine("Warning: " +
                        medicines[i].MedicineName +
                        " is expiring within 7 days.");
                }
            }
        }
    }
    public decimal CalculateSubtotal()
    {
        decimal total = 0;

        for (int i = 0; i < count; i++)
            total += medicines[i].CalculateMedicineTotal();

        return total;
    }
    public decimal ApplyDiscount(decimal subtotal)
    {
        if (customerType == 1) return subtotal * 0.15m;
        if (customerType == 2) return subtotal * 0.05m;
        if (customerType == 3) return subtotal * 0.02m;
        return 0;
    }
    public decimal CalculateTax(decimal amount)
    {
        return amount * 0.03m;
    }
    public decimal CalculateGrandTotal()
    {
        decimal subtotal = CalculateSubtotal();
        decimal discount = ApplyDiscount(subtotal);
        decimal afterDiscount = subtotal - discount;
        decimal tax = CalculateTax(afterDiscount);
        return afterDiscount + tax;
    }
}