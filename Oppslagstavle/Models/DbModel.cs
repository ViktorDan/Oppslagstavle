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
            [Key]
            private int EnhetId { get; set; }
            // Fremmednøkler
            private int ByggId { get; set; }
            private Bygg Bygg { get; set; }
            private List<Beboer> Beboere { get; set; }
        }
        public class Beboer
        {
            [Key]
            // Fremmednøkler
            private int PersonId { get; set; }
            private Person Person { get; set; }
            private int EnhetId { get; set; }
            private Enhet Enhet { get; set; }
        }
        public class Person
        {
            [Key]
            private int PersonId { get; set; }
            // Fremmednøkler

        }
        
        public class Styremedlem
        {
            [Key]
            // Fremmednøkler
            private int PersonId { get; set; }
            private Person Person { get; set; }
            private int OppslagId { get; set; }
            private Oppslag Oppslag { get; set; }
        }
        public class Oppslag
        {
            [Key]
            private int OppslagId { get; set; }
            // Fremmednøkler
            private int PersonId { get; set; }
            private Styremedlem Styremedlem { get; set; }
        }

    }
}
