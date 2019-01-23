using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Oppslagstavle.Models
{
    public abstract class Bruker
    {
        private string Fornavn { get; set; }
        private string Etternavn { get; set; }
        private string Epost { get; set; }
        private string Leilighetsnr { get; set; }
        private Bygg Bygg { get; set; }
        
    }
}
