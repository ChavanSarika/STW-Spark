using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using  STW_Spark.Data;
using  STW_Spark.Data.Models;
namespace  STW_Spark.Pages.Cars
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext db;
        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Car cars { get; set; }
        [TempData]
        public string  StatusMessage { get; set; }
        public IActionResult OnGet(string UserId= null)
        {
            if (UserId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                UserId = claim.Value;

            }
            cars = new Car();
             cars.UserId = UserId;
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
                db.car.Add(cars);
                await db.SaveChangesAsync();
                StatusMessage = "Cas has  been added succefully";

            }
            return RedirectToPage("Index" ,new { UserId=cars.UserId});

        }
    }
}
