using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Kunngjøring : Oppslag
    {
        [Key]
        private int KID { get; set; }
    }
}
