using HBSkincare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Data.Source
{
    public class SQLDBContext : HBSkincareDBContext, IDBContext
    {
        public SQLDBContext()
        {
        }

        public IEnumerable<RawMaterialItem> GetRawMaterialItems(string search = null)
        {
            return RawMaterialItem.Where(e => search == null || e.MaterialName.Contains(search));
        }

        public IEnumerable<RawMaterialPurchase> GetRawMaterialPurchases(int PageNumber, int ResultsPerPage = Int32.MaxValue, string search = null)
        {
            return RawMaterialPurchase
                .Where(e => search == null || e.RawMaterial.MaterialName == search)
                .Include(e => e.RawMaterial)
                .OrderBy(e => e.RawMaterial.MaterialName)
                .ThenByDescending(e => e.DateRecieved)
                .Skip(ResultsPerPage *(PageNumber - 1))
                .Take(ResultsPerPage);
        }

        public int CountRawMaterialPurchases(string search = null)
        {
            return RawMaterialPurchase
                .Where(e => search == null || e.RawMaterial.MaterialName == search)
                .Count();
        }

        public RawMaterialPurchase SearchRawMaterialPurchase(int id)
        {
            return RawMaterialPurchase
                .Include(e => e.RawMaterial)
                .Where(e => e.RawMaterialPurchaseId == id)
                .FirstOrDefault();
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return Currency;
        }

        public bool AddPurchase(RawMaterialPurchase rawMaterialPurchase)
        {

            try
            {
                RawMaterialPurchase.Update(rawMaterialPurchase);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool AddRawMaterial(RawMaterialItem rawMaterialItem)
        {
            try
            {
                RawMaterialItem.Update(rawMaterialItem);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public RawMaterialItem SearchRawMaterialItems(int id)
        {
            return RawMaterialItem
                .Include(e => e.Purchases)
                .FirstOrDefault(e => e.RawMaterialItemId == id);
        }
    }
}
