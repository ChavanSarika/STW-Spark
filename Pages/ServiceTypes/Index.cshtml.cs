using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using  STW_Spark.Data;
using  STW_Spark.Data.Models;
using  STW_Spark.Utility;

namespace  STW_Spark.Pages.ServiceTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public List<ServiceType> ServiceTypes { get; set; }   
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;  
        }

        public async Task<IActionResult> OnGet()
        {
            ServiceTypes = await db.ServiceType.ToListAsync();
            return Page();
        }
    }
}
