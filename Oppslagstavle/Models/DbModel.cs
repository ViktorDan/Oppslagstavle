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

// DbModel struktur:
// - DbContext.
// - DbSet.
// - ModelBuilder - Primærnøkler, Relasjoner, Seeding.
// - DbModels - Borettslag, Bygg, Enhet, Person, Beboer, Styremedlem, Oppslag, OppslagIBygg.

namespace Oppslagstavle.Models
{
    public class OppslagstavleContext : DbContext
    {
        public OppslagstavleContext(DbContextOptions<OppslagstavleContext> options)
            : base(options)
        {}

        

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

            // Seed - Legge inn dummydata
            modelBuilder.Entity<Beboer>().HasData(
                new Beboer {PersonId = 1, Fornavn = "Donald", Etternavn = "Trump",Fulltnavn = "Donald Trump", Epost = "Donald.Trump@gov.com", Lowercase_Epost = "donald.trump@gov.com", Tlf = "12121212", EnhetId = 1 },
                new Beboer { PersonId = 7, Fornavn = "Hillary", Etternavn = "Clinton", Fulltnavn = "Hillary Clinton", Epost = "Hillary.Clinton@gov.com", Lowercase_Epost = "hillary.clinton@gov.com", Tlf = "17161514", EnhetId = 1 },
                new Beboer { PersonId = 8, Fornavn = "Cheesy", Etternavn = "McSteak", Fulltnavn = "Cheesy McSteak", Epost = "Cheesy.McSteak@Mccern.no", Lowercase_Epost = "cheesy.mcsteak@mccern.no", Tlf = "25252525", EnhetId = 2 },
                new Beboer { PersonId = 9, Fornavn = "Chicken", Etternavn = "McSalsa", Fulltnavn = "Chicken McSalsa", Epost = "Chicken.McSalsa@Mccern.no", Lowercase_Epost = "chicken.mcsalsa@mccern.no", Tlf = "25252525", EnhetId = 3 },
                new Beboer { PersonId = 10, Fornavn = "Big", Etternavn = "McBigmac", Fulltnavn = "Big McBigmac", Epost = "Big.McBigmac@Mccern.no", Lowercase_Epost = "big.mcbigmac@mccern.no", Tlf = "25252525", EnhetId = 4 },
                new Beboer { PersonId = 11, Fornavn = "Quarter", Etternavn = "Pounder", Fulltnavn = "Quarter Pounder", Epost = "Quarter.Pounder@Mccern.no", Lowercase_Epost = "quarter.pounder@mccern.no", Tlf = "25252525", EnhetId = 5 }
                );
            modelBuilder.Entity<Enhet>().HasData(
                new Enhet { EnhetId = 1, EnhetsNr = 3, ByggId = 1 },
                new Enhet { EnhetId = 2, EnhetsNr = 30, ByggId = 1 },
                new Enhet { EnhetId = 3, EnhetsNr = 500, ByggId = 1 },
                new Enhet { EnhetId = 4, EnhetsNr = 1, ByggId = 2 },
                new Enhet { EnhetId = 5, EnhetsNr = 90, ByggId = 2 }
                );
            modelBuilder.Entity<Bygg>().HasData(
                new Bygg { ByggId = 1, ByggNr = 1, ByggType = "Blokk", ByggNavn = "A", BorettslagId = 1 },
                new Bygg { ByggId = 2, ByggNr = 2, ByggType = "Rekkehus", ByggNavn = "B", BorettslagId = 1 },
                new Bygg { ByggId = 3, ByggNr = 3, ByggType = "Blokk", ByggNavn = "C", BorettslagId = 2 }
                );
            modelBuilder.Entity<Borettslag>().HasData(
                new Borettslag { BorettslagId = 1, Navn = "The White House", DatoOpprettet = new DateTime(2018,01,31,22,12,00) },
                new Borettslag { BorettslagId = 2, Navn = "McDonalds", DatoOpprettet = new DateTime(2018,01,31,22,12,00) }
                );
            modelBuilder.Entity<Styremedlem>().HasData(
                new Styremedlem { PersonId = 2, Styreleder = true, Fornavn = "Donald", Etternavn = "Duck", Fulltnavn = "Donald Duck", Epost = "Donald.Duck@andebymail.ab", Lowercase_Epost = "donald.duck@andebymail.ab", Tlf = "12345678", BorettslagId = 1 },
                new Styremedlem { PersonId = 3, Styreleder = false, Fornavn = "Elvis", Etternavn = "Presley", Fulltnavn = "Elvis Presley", Epost = "Elvis.Presley@kentucky.us", Lowercase_Epost = "elvis.presley@kentucky.us", Tlf = "12131415", BorettslagId = 1 },
                new Styremedlem { PersonId = 4, Styreleder = false, Fornavn = "Skrue", Etternavn = "McDuck", Fulltnavn = "Skrue McDuck", Epost = "Skrue.McDuck@andebymail.ab", Lowercase_Epost = "skrue.mcduck@andebymail.ab", Tlf = "65748392", BorettslagId = 1 },
                new Styremedlem { PersonId = 5, Styreleder = false, Fornavn = "Ole", Etternavn = "Olsen", Fulltnavn = "Ole Olsen", Epost = "Ole.Olsen@Olsenmail.ole", Lowercase_Epost = "ole.olsen@olsenmail.ole", Tlf = "90182039", BorettslagId = 2 },
                new Styremedlem { PersonId = 6, Styreleder = true, Fornavn = "Gunnar", Etternavn = "Solstad", Fulltnavn = "Gunnar Solstad", Epost = "Gunnar.Solstad@norgemail.no", Lowercase_Epost = "gunnar.solstad@norgemail.no", Tlf = "25252525", BorettslagId = 2 }
                );
            modelBuilder.Entity<Oppslag>().HasData(
                new Oppslag { OppslagId = 1, Tittel = "Søppel i oppgang", Tekst = "Nå er det noen som har lagt igjen søppel i oppgangen flere ganger. Dette er ikke tillatt da det lukter søppel i hele oppgangen. Når man tar søpla ut av døra skal man gå hele veien ut døra og kaste søpla i søppeldunkene! Mvh Styret",
                Bilde = "URL", StartDato = new DateTime(2018, 01, 31, 22, 12, 00), SluttDato = new DateTime(2018, 01, 31, 22, 12, 00), StartTid = "14:00", SluttTid = "15:00", Deltakelse = true, PersonId = 2 },
                new Oppslag { OppslagId = 2, Tittel = "Hund og katt", Tekst = "Det er ikke tillatt med dyrehold i Borettslaget! Skal du ha kjæledyr, vennligst flytt. Mvh Styret",
                Bilde = "URL", StartDato = new DateTime(2018, 01, 31, 22, 12, 00), SluttDato = new DateTime(2018, 01, 31, 22, 12, 00), StartTid = "14:00", SluttTid = "15:00", Deltakelse = true, PersonId = 3 },
                new Oppslag { OppslagId = 3, Tittel = "Sommerfest", Tekst = "Nå er det tid for sommerfest! Dette vil foregå i bakgården hvor det er to stk grill tilgjengelig. Ta med mat og drikke og godt humør! Mvh Styret",
                Bilde = "URL", StartDato = new DateTime(2018, 01, 31, 22, 12, 00), SluttDato = new DateTime(2018, 01, 31, 22, 12, 00), StartTid = "14:00", SluttTid = "15:00", Deltakelse = true, PersonId = 4 },
                new Oppslag { OppslagId = 4, Tittel = "Ny dato for søppeltømming", Tekst = "Styret har fått mail fra kommunen om at søppeltømming vil skje på mandager fra nå av. Mvh Styret",
                Bilde = "URL", StartDato = new DateTime(2018, 01, 31, 22, 12, 00), SluttDato = new DateTime(2018, 01, 31, 22, 12, 00), StartTid = "14:00", SluttTid = "15:00", Deltakelse = true, PersonId = 3 },
                new Oppslag { OppslagId = 5, Tittel = "Lukk porten etter dere", Tekst = "Det har oppstått et problem med porten vår som gjør at den ikke lukker seg ordentlig. Vi ber derfor våre beboere om å se til at porten går ordentlig igjen etter seg slik at ikke uvedkommende får adgang. Mvh Styret",
                Bilde = "URL", StartDato = new DateTime(2018, 01, 31, 22, 12, 00), SluttDato = new DateTime(2018, 01, 31, 22, 12, 00), StartTid = "14:00", SluttTid = "15:00", Deltakelse = true, PersonId = 3 }
                );
            modelBuilder.Entity<OppslagIBygg>().HasData(
                new OppslagIBygg { ByggId = 1, OppslagId = 2 },
                new OppslagIBygg { ByggId = 2, OppslagId = 1 },
                new OppslagIBygg { ByggId = 1, OppslagId = 3 },
                new OppslagIBygg { ByggId = 1, OppslagId = 4 },
                new OppslagIBygg { ByggId = 2, OppslagId = 5 },
                new OppslagIBygg { ByggId = 1, OppslagId = 5 }
                );
        }

        public class Borettslag
        {
            public int BorettslagId { get; set; }
            public string Navn { get; set; }
            public DateTime DatoOpprettet { get; set; }
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
