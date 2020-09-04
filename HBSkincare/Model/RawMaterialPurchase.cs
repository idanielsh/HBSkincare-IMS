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
        [Display(Name = "Remaining Purchase Inventory")]
        public double CurrentInventory { get; set; }
        public double CostPerUnit { get; set; }
        public double LandedCostPerUnit { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Gst { get; set; } = 0;
        public double Pst { get; set; } = 0;
        [Display(Name = "Date Recieved")]
        public DateTime? DateRecieved { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }
        public string SupplierSku { get; set; } = null;
        public string LotNumber { get; set; } = null;
        public DateTime? ExpiryDate { get; set; }
        public string OrderNum { get; set; } = null;
        public double Shipping { get; set; } = 0;
        public double LandedCost { get; set; } = 0;
        public double BrokerageFees { get; set; } = 0;
        public double ForexRate { get; set; } = 1;
        public string PaymentMethod { get; set; } = null;
        public DateTime? CashOutDate { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; } = null;

        [ForeignKey("RawMaterialItemId")]
        public RawMaterialItem RawMaterial { get; set; }
    }
}
