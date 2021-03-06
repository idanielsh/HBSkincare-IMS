﻿using HBSkincare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Data.Source
{
    public interface IDBContext 
    {
        public IEnumerable<RawMaterialItem> GetRawMaterialItems(string search = null);
        public RawMaterialItem SearchRawMaterialItems(int id);
        public RawMaterialPurchase SearchRawMaterialPurchase(int id);
        public IEnumerable<RawMaterialPurchase> GetRawMaterialPurchases(int PageNumber, int ResultsPerPage = Int32.MaxValue, string search = null);
        public int CountRawMaterialPurchases(string search = null);
        public bool AddPurchase(RawMaterialPurchase rawMaterialPurchase);
        public bool AddRawMaterial(RawMaterialItem rawMaterialItem);
        public IEnumerable<Currency> GetCurrencies();
    }
}
