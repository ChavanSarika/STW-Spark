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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public CreateModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public SerivceCarVM serivceCarVM { get; set; }
        public async Task<IActionResult> OnGet(int carId)
        {
            serivceCarVM = new SerivceCarVM()
            {
                car = db.car.Include(e => e.user).FirstOrDefault(c => c.Id == carId),
                serviceHeader = new ServiceHeader(),

            };
            List<String> lstservicetypeinshoppingcart = db.serviceShopingCart
                                                    .Include(c => c.serviceType)
                                                    .Where(c => c.CarId == carId)
                                                    .Select(c => c.serviceType.Name)
                                                    .ToList();
            IQueryable<ServiceType> serviceTypes = from s in db.ServiceType
                                                   where !(lstservicetypeinshoppingcart.Contains(s.Name))
                                                   select s;

            serivceCarVM.serviceTypes = serviceTypes.ToList();
            serivceCarVM.serviceShopingCarts = db.serviceShopingCart.Include(c => c.serviceType).Where(c => c.CarId == carId).ToList();
            serivceCarVM.serviceHeader.TotalPrice = 0;
            serivceCarVM.serviceHeader.TotalPrice = gettotalprice(serivceCarVM.serviceShopingCarts);
            
            return Page();
        }

        public  double gettotalprice(List<ServiceShopingCart> serviceShopingCarts)
        {
            foreach (var i in serivceCarVM.serviceShopingCarts)
            {
                serivceCarVM.serviceHeader.TotalPrice += i.serviceType.Price;
            }
            return serivceCarVM.serviceHeader.TotalPrice;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) 
            {
                serivceCarVM.serviceHeader.DateAdded = DateTime.Now;
                serivceCarVM.serviceShopingCarts = db.serviceShopingCart.Include(c => c.serviceType).ToList();
                serivceCarVM.serviceHeader.TotalPrice = gettotalprice(serivceCarVM.serviceShopingCarts);
                serivceCarVM.serviceHeader.CarId = serivceCarVM.car.Id;
                db.serviceHeader.Add(serivceCarVM.serviceHeader);
                await db.SaveChangesAsync();
                foreach (var details in serivceCarVM.serviceShopingCarts)
                {

                    ServiceDetails serviceDetails = new ServiceDetails()
                    {
                        ServiceheaderId = serivceCarVM.serviceHeader.Id,
                        ServiceName = details.serviceType.Name,
                        ServicePrice = details.serviceType.Price,
                        ServiceTypeId = details.serviceType.Id

                    };
                    db.serviceDetails.Add(serviceDetails);

                }
                db.serviceShopingCart.RemoveRange(serivceCarVM.serviceShopingCarts);
                await db.SaveChangesAsync();

                return RedirectToPage("../Cars/Index", new { UserId = serivceCarVM.car.UserId });

            }
            return Page();
        }
        public async Task<IActionResult> OnPostAddToCart()
        {
            ServiceShopingCart serviceShopingCart = new ServiceShopingCart()
            {
                CarId = serivceCarVM.car.Id,
                ServiceTypeId = serivceCarVM.serviceDetails.ServiceTypeId,
            };
            db.serviceShopingCart.Add(serviceShopingCart);
            await db.SaveChangesAsync();
            return RedirectToPage("Create",new { CarId= serivceCarVM.car.Id});

         
        }
        public async Task<IActionResult> OnPostRemoveFromCart(int serviceId)
        {
            ServiceShopingCart serviceShopingCart = db.serviceShopingCart.FirstOrDefault(u => u.ServiceTypeId == serviceId && u.CarId == serivceCarVM.car.Id);

            db.serviceShopingCart.Remove(serviceShopingCart);
            await db.SaveChangesAsync();
            return RedirectToPage("Create", new { CarId = serivceCarVM.car.Id });
        }
    }
}
