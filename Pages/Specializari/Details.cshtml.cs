using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Specializari
{
    public class DetailsModel : PageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public DetailsModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        public Specializare Specializare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specializare = await _context.Specializare.FirstOrDefaultAsync(m => m.ID == id);

            if (Specializare == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
