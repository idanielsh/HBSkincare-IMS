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

namespace HBSkincare.Pages.Inventory.RawMaterial
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class RawMaterialPurchaseCrudModel : RestrictedPageModel
    {
        [BindProperty(SupportsGet = true)]
        public bool Editing { get; set; } = false;
        [BindProperty(SupportsGet = true)]
        public RawMaterialPurchase Purchase { get; set; }
        public IEnumerable<RawMaterialItem> RawMaterials { get; set; }
        public string ChosenRawMaterialId { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public RawMaterialPurchaseCrudModel(IDBContext db) : base(db)
        {

        }

        public void OnGet(int? Id = null)
        {
            RawMaterials = _db.GetRawMaterialItems();
            if (Id.HasValue)
            {
                Editing = true;
                Purchase = _db.SearchRawMaterialPurchase(Id.Value);
                if(Purchase == default)
                {
                    Editing = false;
                    ErrorMessage = "Purchase not found. Please return to the previous page and try again.";
                    Purchase = new RawMaterialPurchase();
                }
            }
            else
            {
                Editing = false;
                Purchase = new RawMaterialPurchase();
            }
        }

        
        public void OnPost()
        {

        }

        public void OnPostUpdateQty()
        {

        }

        
    }
}