using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using  STW_Spark.Data.Models;
using  STW_Spark.Data;
using Microsoft.AspNetCore.Authorization;
using  STW_Spark.Utility;

namespace  STW_Spark.Pages.ServiceTypes
{
    [Authorize(Roles =SD.AdminEndUser)]
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext db;
        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public ServiceType  servicetype { get; set; }//its bind to get data from user 
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            else 
            {
                db.ServiceType.Add(servicetype);
               await  db.SaveChangesAsync();
                
            }
            return RedirectToPage("Index");
            
        }
    }
}
