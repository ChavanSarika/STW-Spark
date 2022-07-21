using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using  STW_Spark.Data;
using  STW_Spark.Data.Models;

namespace  STW_Spark.Pages.Services
{
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public HistoryModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public List<ServiceHeader> serviceHeaders { get; set; }

        public string UserId { get; set; }
        public async Task OnGet(int carId)
        {
            serviceHeaders = await db.serviceHeader.Include(s => s.Car).Include(c => c.Car.user).Where(m => m.CarId == carId).ToListAsync();
            UserId = db.car.Where(u => u.Id == carId).ToList().FirstOrDefault().UserId;
        }
    }
}
