using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// https://docs.microsoft.com/en-us/ef/core/modeling/relationships

// ***************** OBS --> OnDelete er satt til ClientSetNull på Beboer og Oppslag.           ***************** //
// ***************** Dette for å unngå Cascade cycles som gjør det umulig å opprette relations. ***************** //
// Se ER-Diagram for forklaring på databasen.

namespace Oppslagstavle.Models
{
    public class OppslagstavleContext : DbContext
    {
        public OppslagstavleContext(DbContextOptions<OppslagstavleContext> options)
            : base(options)
        { }

        // Oppretter entiter i databasen slik at det kan gjøres CRUD actions mot dem. Person er ikke med her.
        public DbSet<Borettslag> DB_Borettslag { get; set; }
        public DbSet<Bygg> DB_Bygg { get; set; }
        public DbSet<Enhet> DB_Enheter { get; set; }
        public DbSet<Beboer> DB_Beboere { get; set; }
        public DbSet<Styremedlem> DB_Styremedlemmer { get; set; }
        public DbSet<Oppslag> DB_Oppslag { get; set; }
        public DbSet<OppslagIBygg> DB_OppslagIBygg { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definerer primærnøkler
            modelBuilder.Entity<OppslagIBygg>()
                .HasKey(k => new { k.ByggId, k.OppslagId });
            modelBuilder.Entity<Oppslag>()
                .HasKey(k => k.OppslagId);
            modelBuilder.Entity<Borettslag>()
                .HasKey(k => k.BorettslagId);
            modelBuilder.Entity<Bygg>()
                .HasKey(k => k.ByggId);
            modelBuilder.Entity<Enhet>()
                .HasKey(k => k.EnhetId);
            modelBuilder.Entity<Beboer>()
                .HasKey(k => k.PersonId);
            modelBuilder.Entity<Styremedlem>()
                .HasKey(k => k.PersonId);

            // Definerer relasjoner med navigation properties og fremmednøkler
            modelBuilder.Entity<OppslagIBygg>()
                .HasOne(p => p.Bygg)
                .WithMany(b => b.OppslagIBygg)
                .HasForeignKey(p => p.ByggId);

            modelBuilder.Entity<OppslagIBygg>()
                 .HasOne(p => p.Oppslag)
                 .WithMany(b => b.OppslagIBygg)
                 .HasForeignKey(p => p.OppslagId);

            modelBuilder.Entity<Person>()
                .ToTable("Personer")
                .HasDiscriminator<int>("PersonType")
                .HasValue<Beboer>(1)
                .HasValue<Styremedlem>(2);

            modelBuilder.Entity<Oppslag>()
                .HasOne(p => p.Styremedlem)
                .WithMany(b => b.Oppslag)
                .HasForeignKey(p => p.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Styremedlem>()
                 .HasOne(p => p.Borettslag)
                 .WithMany(b => b.Styremedlemmer)
                 .HasForeignKey(p => p.BorettslagId);

            modelBuilder.Entity<Bygg>()
                .HasOne(p => p.Borettslag)
                .WithMany(b => b.Bygg)
                .HasForeignKey(p => p.BorettslagId);

            modelBuilder.Entity<Enhet>()
                .HasOne(p => p.Bygg)
                .WithMany(b => b.Enheter)
                .HasForeignKey(p => p.ByggId);

            modelBuilder.Entity<Beboer>()
                .HasOne(p => p.Enhet)
                .WithMany(b => b.Beboere)
                .HasForeignKey(p => p.EnhetId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public class Borettslag
        {
            public int BorettslagId { get; set; }
            public string Navn { get; set; }
            public DateTime Opprettet { get; set; }
            // Relasjoner
            public List<Bygg> Bygg { get; set; }
            public List<Styremedlem> Styremedlemmer { get; set; }
        }
        public class Bygg
        {
            public int ByggId { get; set; }
            public int ByggNr { get; set; }
            public string ByggType { get; set; }
            public string ByggNavn { get; set; }
            // Relasjoner
            public int BorettslagId { get; set; }
            public Borettslag Borettslag { get; set; }
            public List<Enhet> Enheter { get; set; }
            public List<OppslagIBygg> OppslagIBygg { get; set; } // ----------------> Peker til OppslagIBygg

        }
        public class Enhet
        {
            public int EnhetId { get; set; }
            public int EnhetsNr { get; set; }
            // Relasjoner
            public int ByggId { get; set; }
            public Bygg Bygg { get; set; }
            public List<Beboer> Beboere { get; set; }
        }
        
        // Person er en abstrakt klasse fordi den ikke skal instansieres. Det har vi Child klassene til.
        public abstract class Person
        {
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
            // Relasjoner
            public int EnhetId { get; set; }
            public Enhet Enhet { get; set; }
        }
        public class Styremedlem : Person
        {
            public bool Styreleder { get; set; }
            // Relasjoner
            public int BorettslagId { get; set; }
            public Borettslag Borettslag { get; set; }
            public List<Oppslag> Oppslag { get; set; }
        }
        public class Oppslag
        {
            public int OppslagId { get; set; }
            public string Tittel { get; set; }
            public string Tekst { get; set; }
            public string Bilde { get; set; }
            public DateTime StartDato { get; set; }
            public DateTime SluttDato { get; set; }
            public string StartTid { get; set; }
            public string SluttTid { get; set; }
            public bool Deltakelse { get; set; }
            // Relasjoner
            public int PersonId { get; set; } // ----------------> FK som peker til Styremedlem
            public Styremedlem Styremedlem { get; set; }
            public List<OppslagIBygg> OppslagIBygg { get; set; } // ----------------> Peker til OppslagIBygg
        }
        public class OppslagIBygg
        {
            // Mellom-entitet i mange-til-mange forhold Oppslag og Bygg
            // Relasjoner
            public int ByggId { get; set; }
            public Bygg Bygg { get; set; }
            public int OppslagId { get; set; }
            public Oppslag Oppslag { get; set; }
        }

    }
}
