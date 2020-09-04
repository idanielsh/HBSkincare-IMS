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

    }
}
