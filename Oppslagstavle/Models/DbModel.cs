using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// https://docs.microsoft.com/en-us/ef/core/modeling/relationships

namespace Oppslagstavle.Models
{
    public class OppslagstavleContext : DbContext
    {
        public OppslagstavleContext(DbContextOptions<OppslagstavleContext> options)
            : base(options)
        { }

        public DbSet<Borettslag> DB_Borettslag { get; set; }
        public DbSet<Bygg> DB_Bygg { get; set; }
        public DbSet<Enhet> DB_Enheter { get; set; }
        public DbSet<Person> DB_Personer { get; set; }
        public DbSet<Beboer> DB_Beboere { get; set; }
        public DbSet<Styremedlem> DB_Styremedlemmer { get; set; }
        public DbSet<Oppslag> DB_Oppslag { get; set; }


        public class Borettslag
        {
            [Key]
            private int BorettslagId { get; set; }
            private string Navn { get; set; }
            private DateTime Opprettet { get; set; }
            private List<Bygg> Bygg { get; set; }

        }
        public class Bygg
        {
            [Key]
            private int ByggId { get; set; }
            // Fremmednøkler
            private int BorettslagId { get; set; }
            private Borettslag Borettslag { get; set; }
            private List<Enhet> Enheter { get; set; }

        }
        public class Enhet
        {
            // Fremmednøkler
            private int ByggId { get; set; }
            private Bygg Bygg { get; set; }
            private 
        }
        public class Person
        {

        }
        public class Beboer
        {

        }
        public class Styremedlem
        {

        }
        public class Oppslag
        {

        }

    }
}
