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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public DetailsModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public ServiceHeader serviceHeader { get; set; }
        public List<ServiceDetails> serviceDetails { get; set; }
        public void OnGet(int serviceId)
        {
            serviceHeader = db.serviceHeader.Include(c => c.Car).Include(m => m.Car.user).Where(h=>h.Id==serviceId).FirstOrDefault();
            serviceDetails = db.serviceDetails.Where(s => s.ServiceheaderId == serviceId).ToList();
        }
    }
}
