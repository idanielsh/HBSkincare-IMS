using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSkincare.Data.Source;
using HBSkincare.Managers;
using HBSkincare.Model;
using HBSkincare.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HBSkincare.Pages.Inventory.RawMaterial
{
    [Authorize]
    public class RawMaterialItemCrudModel : RestrictedPageModel
    {
        [BindProperty]
        public bool Editing { get; set; }
        [BindProperty]
        public RawMaterialItem Material { get; set; }
        public List<RawMaterialPurchase> Purchases { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public double TotalValue { get; set; } = 0;
        public double TotalInventory { get; set; } = 0;
        public double ScrapValue { get; set; } = 0;
        private readonly RawMaterialItemManager rawMaterialItemManager;
        public RawMaterialItemCrudModel(IDBContext db, RawMaterialItemManager rawMaterialItemManager) : base(db)
        {
            Purchases = new List<RawMaterialPurchase>();
            this.rawMaterialItemManager = rawMaterialItemManager;
        }

        public IActionResult OnGet(int? Id = null)
        {
            if (Id.HasValue)
            {
                Editing = true;
                Material = _db.SearchRawMaterialItems(Id.Value);
                if (Material == default)
                {
                    Editing = false;
                    ErrorMessage = "Purchase not found. Please return to the previous page and try again.";
                    Material = new RawMaterialItem();
                    return Page();
                }

                foreach(var item in Material.Purchases)
                {
                    if (item.CurrentInventory > 0)
                        Purchases.Add(item);
                    TotalValue += item.CurrentInventory * item.LandedCostPerUnit;
                    TotalInventory += item.CurrentInventory;
                    ScrapValue += item.ScrapValue.GetValueOrDefault(0);
                }
            }
            else
            {
                Editing = false;
                Material = new RawMaterialItem();
            }

            return Page();
        }

        public IActionResult OnPostUpdateQty()
        {
            int id = Int32.Parse(Request.Form["id"]);
            double remaining;
            try
            {
                remaining = double.Parse(Request.Form["RemainingInventory"]);
            }
            catch (Exception e)
            {
                ErrorMessage = "Amount remaining invalid. Please try again.";
                return OnGet(id);
            }

            RawMaterialPurchase purchase = _db.SearchRawMaterialPurchase(id);

            purchase.CurrentInventory = remaining;

            if (_db.AddPurchase(purchase))
            {
                SuccessMessage = "Inventory updated succesfully.";
            }
            else
            {
                ErrorMessage = "Purchase updated unsuccesfully. Please try again or contact sysadmin.";
            }

            return OnGet(Material.RawMaterialItemId);
        }

        public IActionResult OnPost()
        {
            if (_db.AddRawMaterial(Material))
            {
                SuccessMessage = Editing ? "Material updated succesfully." : "Material created succesfully.";
            }
            else
            {
                ErrorMessage = Editing ? "Material updated unsuccesfully." : "Material created unsuccesfully. " + "Please try again or contact sysadmin.";
            }
            return OnGet(Material.RawMaterialItemId);
        }
    }
}