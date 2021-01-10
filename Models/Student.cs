using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studenti.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        [Display(Name = " Andresa e-mail")]
        public string Email { get; set; }
        [Display(Name = "Numar de telefon")]
        public string NrTelefon { get; set; }
        [Display(Name = "Data inscriere")]
        [DataType(DataType.Date)]
        public DateTime DataInscriere { get; set; }
        public int IDFacultate { get; set; }
        public Facultate Facultate { get; set; }
        [Display(Name = "Specializare")]
        public ICollection<SpecializareStudent> SpecializareStudenti { get; set; }
     

    }
}
