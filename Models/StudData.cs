using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Studenti.Models
{
    public class StudData
    {
        public IEnumerable<Student> Studenti { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }
        public IEnumerable<SpecializareStudent> SpecializareStudent { get; set; }
    }
}
