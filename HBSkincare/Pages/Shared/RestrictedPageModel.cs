using HBSkincare.Data.Source;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSkincare.Pages.Shared
{
    public class RestrictedPageModel : PageModel
    {
        protected readonly IDBContext _db;
        public RestrictedPageModel(IDBContext db)
        {
            _db = db;
        }
    }
}
