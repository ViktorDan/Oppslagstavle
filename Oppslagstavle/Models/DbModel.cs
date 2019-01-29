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
        public DbSet<OppslagIBygg> DB_OppslagIBygg { get; set; }


        public class Borettslag
        {
            [Key]
            public int BorettslagId { get; set; }
            public string Navn { get; set; }
            public DateTime Opprettet { get; set; }
            // Fremmednøkler
            public List<Bygg> Bygg { get; set; } 
            public List<Styremedlem> Styremedlemmer { get; set; }
        }
        public class Bygg
        {
            [Key]
            public int ByggId { get; set; }
            public int ByggNr { get; set; }
            public string ByggType { get; set; }
            public string ByggNavn { get; set; }
            // Fremmednøkler
            public int BorettslagId { get; set; }
            public Borettslag Borettslag { get; set; }
            public List<Enhet> Enheter { get; set; }
            public List<OppslagIBygg> OppslagIBygg { get; set; } // ----------------> Peker til OppslagIBygg

        }
        public class Enhet
        {
            [Key]
            public int EnhetId { get; set; }
            // Fremmednøkler
            public int ByggId { get; set; }
            public Bygg Bygg { get; set; }
            public List<Beboer> Beboere { get; set; }
        }
       
        public class Person
        {
            [Key]
            public int PersonId { get; set; }
            public string Fornavn { get; set; }
            public string Etternavn { get; set; }
            public string Fulltnavn { get; set; }
            public string Epost { get; set; }
            public string Lowercase_Epost { get; set; }
            public string Tlf { get; set; }
        }
        public class Beboer : Person
        {
            public int EnhetId { get; set; }
            public Enhet Enhet { get; set; }
        }
        public class Styremedlem : Person
        {
            public bool Styreleder { get; set; }
            // Fremmednøkler
            public int BorettslagId { get; set; }
            public virtual Borettslag Borettslag { get; set; }
            public List<Oppslag> Oppslag { get; set; }
        }
        public class Oppslag
        {
            [Key]
            public int OppslagId { get; set; }
            public string Tittel { get; set; }
            public string Tekst { get; set; }
            public string Bilde { get; set; }
            public DateTime StartDato { get; set; }
            public DateTime SluttDato { get; set; }
            public string StartTid { get; set; }
            public string SluttTid { get; set; }
            public bool Deltakelse { get; set; }
            // Fremmednøkler
            public int PersonId { get; set; } // ----------------> Peker til Styremedlem
            public Styremedlem Styremedlem { get; set; }
            public List<OppslagIBygg> OppslagIBygg { get; set; } // ----------------> Peker til OppslagIBygg
        }
        public class OppslagIBygg
        {
            public int OppslagIByggId { get; set; }
            // Mellom-entitet i mange-til-mange forhold Oppslag og Bygg
            public int ByggId { get; set; }
            public Bygg Bygg { get; set; }

            public int OppslagId { get; set; }
            public Oppslag Oppslag { get; set; }
        }

    }
}
