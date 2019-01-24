using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Oppslag
    {
        public Styremedlem Forfatter { get; set; }
        public Bygg Bygg { get; set; }
        public string Publisert { get; set; }
        public string Sluttdato { get; set; }
        public string Tittel { get; set; }
        public string Tekst { get; set; }
        public string Bilde { get; set; }


        
    }
}
