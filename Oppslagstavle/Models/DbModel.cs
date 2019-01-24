using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Oppslagstavle.Models
{
    public class OppslagstavleContext : DbContext
    {
        public OppslagstavleContext(DbContextOptions<OppslagstavleContext> options)
            : base(options)
        { }

        public DbSet<Bruker> Brukere {get;set;}

        public class Bruker
        {
            public int BrukerId { get; set; }
            public String Navn { get; set; }
        }

    }
}
