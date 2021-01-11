using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Stud
{
    public class EditModel : SpecializareStudentPageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public EditModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
               .Include(b => b.Facultate)
               .Include(b => b.SpecializareStudenti).ThenInclude(b => b.Specializare)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);
            if (Student == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Student);
            ViewData["IDFacultate"] = new SelectList(_context.Set<Facultate>(), "ID", "NumeFacultate");
            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bookToUpdate = await _context.Student
            .Include(i => i.Facultate)
            .Include(i => i.SpecializareStudenti)
            .ThenInclude(i => i.Specializare)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (bookToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
            bookToUpdate,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.CNP, i => i.Email, i => i.NrTelefon,
            i => i.DataInscriere, i => i.Facultate, i => i.SpecializareStudenti))
            {
                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
            PopulateAssignedCategoryData(_context, bookToUpdate);
            return Page();
        }

    }
}

