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
    public class DeleteModel : PageModel
    {
        private readonly STW_Spark.Data.ApplicationDbContext _context;

        public DeleteModel(STW_Spark.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceType ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _context.ServiceType.FirstOrDefaultAsync(m => m.Id == id);

            if (ServiceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ServiceType = await _context.ServiceType.FindAsync(id);

            if (ServiceType != null)
            {
                _context.ServiceType.Remove(ServiceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
