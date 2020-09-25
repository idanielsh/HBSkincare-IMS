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
        [Display(Name = "Ingridient Name")]
        public string MaterialName { get; set; }
        [Display(Name = "Unit of Measurement")]
        public string UnitOfMeasure { get; set; } = null;
        public virtual ICollection<RawMaterialPurchase> Purchases { get; set; }

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
            hash.Add(UnitOfMeasure);
            hash.Add(Purchases);
            return hash.ToHashCode();
        }
    }
}
