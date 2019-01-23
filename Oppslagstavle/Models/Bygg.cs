using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Bygg
    {
        private string Navn { get; set; }
        private List<Bruker> Brukere { get; set; }
    }
}
