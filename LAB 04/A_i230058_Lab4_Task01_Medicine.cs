// Name : Shah Faisal
// Roll Number : 23I-0058
using System;
public class Medicine
{
    public int MedicineId;
    public string MedicineName;
    public string Category;
    public decimal PricePerUnit;
    public int StockQuantity;
    public int Quantity;
    public bool RequiresPrescription;
    public string ExpiryDate;
    public decimal CalculateMedicineTotal()
    {
        return PricePerUnit * Quantity;
    }
    public bool IsExpired()
    {
        DateTime fixedDate = new DateTime(2026, 2, 20);
        DateTime expiry;
        if (DateTime.TryParseExact(ExpiryDate, "dd/MM/yyyy",
    null, System.Globalization.DateTimeStyles.None, out expiry))
        {
            return expiry < fixedDate;
        }
        return true;
    }
    }