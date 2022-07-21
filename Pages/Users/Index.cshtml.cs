using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using  STW_Spark.Data;
using  STW_Spark.Data.Models;
using  STW_Spark.Data.ViewModel;
using  STW_Spark.Utility;

namespace  STW_Spark.Pages.Users
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class IndexModel : PageModel
    {
       
        private readonly ApplicationDbContext db;
        [BindProperty]
        public  UserListViewModel usersVM { get; set; }
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> OnGetAsync(string searchEmail=null, string searchName = null, string searchPhoneNumber = null)
        {
            usersVM = new UserListViewModel()
            {
                applicationUsers = await db.ApplicationUser.ToListAsync()
            };

            if (searchEmail != null)
            {
                usersVM.applicationUsers = await db.ApplicationUser.Where(p => p.Email.ToLower().Contains(searchEmail)).ToListAsync();
            }
            else 
            {
                if (searchName != null)
                {
                    usersVM.applicationUsers = await db.ApplicationUser.Where(p => p.Name.ToLower().Contains(searchName)).ToListAsync();
                }
                else 
                {
                    if (searchPhoneNumber != null)
                    {
                        usersVM.applicationUsers = await db.ApplicationUser.Where(p => p.PhoneNumber.ToLower().Contains(searchPhoneNumber)).ToListAsync();
                    }
                }
                
            }
            //StringBuilder param = new StringBuilder();
            //param.Append("/Users?productPage=:");

            //var count = usersVM.applicationUsers.Count();

            //usersVM.pagingInfo = new PagingInfo()
            //{
            //    CurrentPage = productPage,
            //    ItemsPerPage = 2,
            //    TotalItems = count,
            //    UrlParam = param.ToString()
            //};

            //usersVM.applicationUsers = usersVM.applicationUsers.OrderBy(p => p.Email)
            //    .Skip((productPage - 1) * 2).Take(2).ToList();
            return Page();
        }
    }
}
