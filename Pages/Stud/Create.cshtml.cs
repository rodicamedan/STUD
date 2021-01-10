using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Pages.Stud
{
    public class CreateModel : SpecializareStudentPageModel
    {
        private readonly Studenti.Data.StudentiContext _context;

        public CreateModel(Studenti.Data.StudentiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IDFacultate"] = new SelectList(_context.Set<Facultate>(), "ID", "NumeFacultate");
            var student = new Student();
            student.SpecializareStudenti = new List<SpecializareStudent>();
            PopulateAssignedCategoryData(_context, student);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newStud = new Student();
            if (selectedCategories != null)
            {
                newStud.SpecializareStudenti = new List<SpecializareStudent>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new SpecializareStudent
                    {
                        IDSpecializare = int.Parse(cat)
                    };
                    newStud.SpecializareStudenti.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Student>(
            newStud,
            "Student",
            i => i.Nume, i => i.Prenume,
            i => i.CNP, i => i.DataInscriere, i => i.IDFacultate))
            {
                _context.Student.Add(newStud);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newStud);
            return Page();
        }

    }
}
