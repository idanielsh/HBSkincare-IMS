using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Model
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public double? ValueInCad { get; set; }
    }
}
