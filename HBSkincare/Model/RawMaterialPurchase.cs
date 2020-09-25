using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Model
{
    public class RawMaterialPurchase
    {
        public int RawMaterialPurchaseId { get; set; }
        [Display(Name = "Purchase Size")]
        public double PurchaseSize { get; set; }
        [Display(Name = "Remaining Inventory")]
        public double CurrentInventory { get; set; }
        [Display(Name = "Cost Per Unit")]
        public double CostPerUnit { get; set; }
        [Display(Name = "Landed Cost Per Unit")]
        public double LandedCostPerUnit { get; set; }
        [Display(Name = "GST")]
        public double Gst { get; set; } = 0;
        [Display(Name = "PST")]
        public double Pst { get; set; } = 0;
        [Display(Name = "Date Purchased")]
        public DateTime? DateRecieved { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        [Display(Name = "Supplier SKU")]
        public string SupplierSku { get; set; } = null;
        [Display(Name = "Lot No / Batch Code")]
        public string LotNumber { get; set; } = null;
        [Display(Name = "Expiry Date")]
        public DateTime? ExpiryDate { get; set; }
        [Display(Name = "Order #")]
        public string OrderNum { get; set; } = null;
        public double Shipping { get; set; } = 0;
        [Display(Name = "Extended Cost")]
        public double ExtendedCost { get; set; }
        [Display(Name = "Landed Cost")]
        public double LandedCost { get; set; } = 0;
        [Display(Name = "Brokerage Fees")]
        public double BrokerageFees { get; set; } = 0;
        [Display(Name = "Forex Rate")]
        public double ForexRate { get; set; } = 1;
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = null;
        [Display(Name = "Cash Out Date")]
        public DateTime? CashOutDate { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } = null;
        [Display(Name = "Scrap Value")]
        public double? ScrapValue { get; set; }
        [Display(Name = "Scrap Date")]
        public DateTime? ScrapDate { get; set; }
        public string Notes { get; set; }

        [ForeignKey("RawMaterialItemId")]
        public virtual RawMaterialItem RawMaterial { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RawMaterialPurchase purchase &&
                   RawMaterialPurchaseId == purchase.RawMaterialPurchaseId &&
                   PurchaseSize == purchase.PurchaseSize &&
                   CurrentInventory == purchase.CurrentInventory &&
                   CostPerUnit == purchase.CostPerUnit &&
                   LandedCostPerUnit == purchase.LandedCostPerUnit &&
                   Gst == purchase.Gst &&
                   Pst == purchase.Pst &&
                   DateRecieved == purchase.DateRecieved &&
                   SupplierName == purchase.SupplierName &&
                   SupplierSku == purchase.SupplierSku &&
                   LotNumber == purchase.LotNumber &&
                   ExpiryDate == purchase.ExpiryDate &&
                   OrderNum == purchase.OrderNum &&
                   Shipping == purchase.Shipping &&
                   ExtendedCost == purchase.ExtendedCost &&
                   LandedCost == purchase.LandedCost &&
                   BrokerageFees == purchase.BrokerageFees &&
                   ForexRate == purchase.ForexRate &&
                   PaymentMethod == purchase.PaymentMethod &&
                   CashOutDate == purchase.CashOutDate &&
                   EqualityComparer<Currency>.Default.Equals(Currency, purchase.Currency) &&
                   ScrapValue == purchase.ScrapValue &&
                   ScrapDate == purchase.ScrapDate &&
                   EqualityComparer<RawMaterialItem>.Default.Equals(RawMaterial, purchase.RawMaterial);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RawMaterialPurchaseId);
            hash.Add(PurchaseSize);
            hash.Add(CurrentInventory);
            hash.Add(CostPerUnit);
            hash.Add(LandedCostPerUnit);
            hash.Add(Gst);
            hash.Add(Pst);
            hash.Add(DateRecieved);
            hash.Add(SupplierName);
            hash.Add(SupplierSku);
            hash.Add(LotNumber);
            hash.Add(ExpiryDate);
            hash.Add(OrderNum);
            hash.Add(Shipping);
            hash.Add(ExtendedCost);
            hash.Add(LandedCost);
            hash.Add(BrokerageFees);
            hash.Add(ForexRate);
            hash.Add(PaymentMethod);
            hash.Add(CashOutDate);
            hash.Add(Currency);
            hash.Add(ScrapValue);
            hash.Add(ScrapDate);
            hash.Add(RawMaterial);
            return hash.ToHashCode();
        }
    }
}
