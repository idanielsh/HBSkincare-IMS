using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Model
{
    public class RawMaterialItem
    {
        public int RawMaterialItemId { get; set; }
        [Required]
        [Display(Name = "Ingridient")]
        public string MaterialName { get; set; }
        public string Inci { get; set; } = null;
        [Display(Name = "Total Inventory")]
        public int CurrentInventory { get; set; } = 0;
        public string UnitOfMeasure { get; set; } = null;
        public double CostPerUnit { get; set; } = 0;
        public double LandedCostPerUnit { get; set; } = 0;
        public double YearEndInventoryWithScrap { get; set; } = 0;
        public double YearEndInventoryNoScrap { get; set; } = 0;
        public double LandedCost { get; set; } = 0;
        public double ScrapValue { get; set; } = 0;
        public ICollection<RawMaterialPurchase> Purchases { get; set; }

        public override bool Equals(object obj)
        {
            return obj is RawMaterialItem item &&
                   RawMaterialItemId == item.RawMaterialItemId;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(RawMaterialItemId);
            hash.Add(MaterialName);
            hash.Add(Inci);
            hash.Add(CurrentInventory);
            hash.Add(UnitOfMeasure);
            hash.Add(CostPerUnit);
            hash.Add(LandedCostPerUnit);
            hash.Add(YearEndInventoryWithScrap);
            hash.Add(YearEndInventoryNoScrap);
            hash.Add(LandedCost);
            hash.Add(ScrapValue);
            hash.Add(Purchases);
            return hash.ToHashCode();
        }
    }
}
