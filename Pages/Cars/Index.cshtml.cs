using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using  STW_Spark.Data;
using  STW_Spark.Data.Models;

namespace  STW_Spark.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        
        [BindProperty]
        public CarsCustomerVM carsCustomerVM { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> OnGet(string UserId = null)
        {
            if (UserId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                UserId = claim.Value;

            }
                carsCustomerVM = new CarsCustomerVM()
                {
                    cars = await db.car.Where(m => m.UserId == UserId).ToListAsync(),
                    user = await db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == UserId)
                };
            return Page();
        }
    }
}
