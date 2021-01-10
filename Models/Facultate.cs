using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Studenti.Models
{
    public class Facultate
    {
        public int ID { get; set; }
        [Display(Name = "Facultate")]
        public string NumeFacultate { get; set; }
        public ICollection<Student> Stud { get; set; }
    }
}
