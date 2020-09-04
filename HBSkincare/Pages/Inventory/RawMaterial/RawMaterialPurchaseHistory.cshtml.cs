using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSkincare.Data.Source;
using HBSkincare.Model;
using HBSkincare.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HBSkincare.Pages.Inventory
{
    [Authorize]
    public class RawMaterialPurchaseHistoryModel : RestrictedPageModel
    {
        public IEnumerable<RawMaterialItem> RawMaterials { get; set; }
        public IEnumerable<RawMaterialPurchase> Purchases { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ChosenMaterial { get; set; } = null;
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int NumberPages { get; private set; }
        public readonly int ResultsPerPage = 50;

        public RawMaterialPurchaseHistoryModel(IDBContext db) : base(db)
        {
        }

        public void OnGet()
        {
            RawMaterials = _db.GetRawMaterialItems();
            Purchases = _db.GetRawMaterialPurchases(PageNumber, ResultsPerPage, ChosenMaterial);

            NumberPages = (int)Math.Ceiling((Decimal)_db.CountRawMaterialPurchases(ChosenMaterial) / (Decimal)ResultsPerPage);

        }
    }
}