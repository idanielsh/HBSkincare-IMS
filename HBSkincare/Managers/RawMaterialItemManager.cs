using HBSkincare.Data.Source;
using HBSkincare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Managers
{
    public class RawMaterialItemManager
    {
        private readonly IDBContext _db;
        public RawMaterialItemManager(IDBContext dB)
        {
            _db = dB;
        }

        public void UpdateItem(int material)
        {
            RawMaterialItem temp = _db.SearchRawMaterialItems(material);
            UpdateCurrentInventory(temp);
            UpdateCostPerUnit(temp);
            UpdateLandedCost(temp);
            _db.AddRawMaterial(temp);

        }

        private void UpdateCurrentInventory(RawMaterialItem temp)
        {
            //temp.CurrentInventory = temp.Purchases.Sum(e => e.CurrentInventory);
        }

        private void UpdateLandedCost(RawMaterialItem temp)
        {
            //temp.LandedCost = temp.Purchases.Sum(e => e.LandedCost);
        }

        private void UpdateCostPerUnit(RawMaterialItem item)
        {
            /*try
            {
                item.LandedCostPerUnit = item.Purchases.WeightedAverage(e => e.LandedCostPerUnit, e => e.CurrentInventory);
                item.CostPerUnit = item.Purchases.WeightedAverage(e => e.CostPerUnit, e => e.CurrentInventory);
            }
            catch (DivideByZeroException)
            {
                item.LandedCostPerUnit = 0;
                item.CostPerUnit = 0;
            }*/
            
        }

        

    }
}
