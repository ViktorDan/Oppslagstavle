using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Bygg
    {
        [Key]
        private int ByID { get; set; }
        private string Navn { get; set; }
        private List<Bruker> Brukere { get; set; }
    }
}
