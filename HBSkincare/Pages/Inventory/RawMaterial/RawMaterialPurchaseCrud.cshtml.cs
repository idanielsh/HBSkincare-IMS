using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HBSkincare.Data.Source;
using HBSkincare.Managers;
using HBSkincare.Model;
using HBSkincare.Pages.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HBSkincare.Pages.Inventory.RawMaterial
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class RawMaterialPurchaseCrudModel : RestrictedPageModel
    {
        [BindProperty]
        public bool Editing { get; set; } = false;
        [BindProperty]
        public RawMaterialPurchase Purchase { get; set; }
        public IEnumerable<RawMaterialItem> RawMaterials { get; set; }
        public IEnumerable<SelectListItem> CurrenciesListItems { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        [BindProperty]
        public string ChosenRawMaterialId { get; set; }
        [BindProperty]
        public string ChosenCurrency { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        private readonly RawMaterialItemManager rawMaterialItemManager;
        public RawMaterialPurchaseCrudModel(IDBContext db, RawMaterialItemManager rawMaterialItemManager) : base(db)
        {
            this.rawMaterialItemManager = rawMaterialItemManager;
            Currencies = _db.GetCurrencies();
            RawMaterials = _db.GetRawMaterialItems();
            CurrenciesListItems = Currencies.Select(e => new SelectListItem() { Value = e.CurrencyName, Text = e.CurrencyName });

        }

        public IActionResult OnGet(int? Id = null)
        {
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
            return Page();
        }

        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Request.Form["scrap"].Count() == 1)
                {
                    Purchase.ScrapDate = DateTime.Today;
                    Purchase.ScrapValue = Purchase.CurrentInventory * Purchase.LandedCostPerUnit;
                    Purchase.CurrentInventory = 0;
                }

                Purchase.RawMaterial = RawMaterials.First(e => e.RawMaterialItemId == Int32.Parse(ChosenRawMaterialId));
                Purchase.Currency = Currencies.First(e => e.CurrencyName == ChosenCurrency);

                if (_db.AddPurchase(Purchase))
                {
                    SuccessMessage = Editing ? "Purchase updated succesfully." : "Purchase created succesfully.";
                }
                else
                {
                    ErrorMessage = Editing ? "Purchase updated unsuccesfully." : "Purchase created unsuccesfully. " + "Please try again or contact sysadmin.";
                }
                return Page();
            }
            ErrorMessage = "Purchase info not valid. Please try again.";
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
            catch(Exception e)
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

            return OnGet(id);
        }        
    }
}