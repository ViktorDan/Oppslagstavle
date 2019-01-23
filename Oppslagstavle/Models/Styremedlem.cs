using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oppslagstavle.Models
{
    public class Styremedlem : Bruker
    {
       [Key]
       private string SID { get; set; }       
       private Boolean Styreleder { get; set; }
    }
}
