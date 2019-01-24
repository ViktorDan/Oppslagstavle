using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Arrangement : Oppslag
    {
        [Key]
        public int AID { get; set; }
        public Boolean Deltagbar { get; set; }
        public int Deltagere { get; set; }
        public string Hvor { get; set; }
        public string Når { get; set; }
        public DateTime Dato { get; set; }
    }
}
