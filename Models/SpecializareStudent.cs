using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenti.Models
{
    public class SpecializareStudent
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int IDSpecializare { get; set; }
        public Specializare Specializare { get; set; }


    }
}
