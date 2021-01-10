using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Stud
{
    public class IndexModel : PageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public IndexModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }
        public IList<Student> Student { get; set; }
        public StudData StudD { get; set; }
        public int StudID { get; set; }
        public int IDSpecizlizare { get; set; }
        public async Task OnGetAsync(int? id, int? IDSpecilizare)
        {


            StudD = new StudData();

            StudD.Studenti = await _context.Student
            .Include(b => b.Facultate)
            .Include(b => b.SpecializareStudenti)
            .ThenInclude(b => b.Specializare)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                StudID = id.Value;
                Student student = StudD.Studenti
                .Where(i => i.ID == id.Value).Single();
                StudD.Specializari = student.SpecializareStudenti.Select(s => s.Specializare);
            }
            Student = await _context.Student
           .Include(b => b.Facultate)
           .ToListAsync();
        }
    }
}
