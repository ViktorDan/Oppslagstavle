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
        private int AID { get; set; }
        private Boolean Deltagbar { get; set; }
        private int Deltagere { get; set; }
    }
}
