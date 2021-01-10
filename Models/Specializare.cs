using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenti.Models
{
    public class Specializare
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public ICollection<SpecializareStudent> SpecializareStudenti { get; set; }
    }
}
