using Microsoft.AspNetCore.Mvc.RazorPages;
using Studenti.Data;
using System.Collections.Generic;
using System.Linq;

namespace Studenti.Models
{
    public class SpecializareStudentPageModel : PageModel
    {
        public List<AtribuireSpecializare> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(StudentiContext context,
        Student student)
        {
            var allCategories = context.Specializare;
            var bookCategories = new HashSet<int>(
            student.SpecializareStudenti.Select(c => c.StudentID));
            AssignedCategoryDataList = new List<AtribuireSpecializare>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AtribuireSpecializare
                {
                    IDSpecializare = cat.ID,
                    Specializare = cat.Denumire,
                    Atribuire = bookCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(StudentiContext context,
        string[] selectedCategories, Student bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.SpecializareStudenti = new List<SpecializareStudent>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.SpecializareStudenti.Select(c => c.Specializare.ID));
            foreach (var cat in context.Specializare)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.SpecializareStudenti.Add(
                        new SpecializareStudent
                        {
                            StudentID = bookToUpdate.ID,
                            IDSpecializare = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        SpecializareStudent courseToRemove
                        = bookToUpdate
                        .SpecializareStudenti
                        .SingleOrDefault(i => i.IDSpecializare == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
