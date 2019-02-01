﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oppslagstavle.Models;

namespace Oppslagstavle.Migrations
{
    [DbContext(typeof(OppslagstavleContext))]
    [Migration("20190131140317_Seed_DTrump++")]
    partial class Seed_DTrump
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Borettslag", b =>
                {
                    b.Property<int>("BorettslagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatoOpprettet");

                    b.Property<string>("Navn");

                    b.HasKey("BorettslagId");

                    b.ToTable("DB_Borettslag");

                    b.HasData(
                        new { BorettslagId = 1, DatoOpprettet = new DateTime(2018, 1, 31, 22, 12, 0, 0, DateTimeKind.Unspecified), Navn = "The White House" }
                    );
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Bygg", b =>
                {
                    b.Property<int>("ByggId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BorettslagId");

                    b.Property<string>("ByggNavn");

                    b.Property<int>("ByggNr");

                    b.Property<string>("ByggType");

                    b.HasKey("ByggId");

                    b.HasIndex("BorettslagId");

                    b.ToTable("DB_Bygg");

                    b.HasData(
                        new { ByggId = 1, BorettslagId = 1, ByggNavn = "A", ByggNr = 1, ByggType = "Blokk" }
                    );
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Enhet", b =>
                {
                    b.Property<int>("EnhetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ByggId");

                    b.Property<int>("EnhetsNr");

                    b.HasKey("EnhetId");

                    b.HasIndex("ByggId");

                    b.ToTable("DB_Enheter");

                    b.HasData(
                        new { EnhetId = 1, ByggId = 1, EnhetsNr = 3 }
                    );
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Oppslag", b =>
                {
                    b.Property<int>("OppslagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bilde");

                    b.Property<bool>("Deltakelse");

                    b.Property<int>("PersonId");

                    b.Property<DateTime>("SluttDato");

                    b.Property<string>("SluttTid");

                    b.Property<DateTime>("StartDato");

                    b.Property<string>("StartTid");

                    b.Property<string>("Tekst");

                    b.Property<string>("Tittel");

                    b.HasKey("OppslagId");

                    b.HasIndex("PersonId");

                    b.ToTable("DB_Oppslag");
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+OppslagIBygg", b =>
                {
                    b.Property<int>("ByggId");

                    b.Property<int>("OppslagId");

                    b.HasKey("ByggId", "OppslagId");

                    b.HasIndex("OppslagId");

                    b.ToTable("DB_OppslagIBygg");
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Epost");

                    b.Property<string>("Etternavn");

                    b.Property<string>("Fornavn");

                    b.Property<string>("Fulltnavn");

                    b.Property<string>("Lowercase_Epost");

                    b.Property<int>("PersonType");

                    b.Property<string>("Tlf");

                    b.HasKey("PersonId");

                    b.ToTable("Personer");

                    b.HasDiscriminator<int>("PersonType");
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Beboer", b =>
                {
                    b.HasBaseType("Oppslagstavle.Models.OppslagstavleContext+Person");

                    b.Property<int>("EnhetId");

                    b.HasIndex("EnhetId");

                    b.ToTable("Beboer");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new { PersonId = 1, Epost = "Donald.Trump@gov.com", Etternavn = "Trump", Fornavn = "Donald", Fulltnavn = "Donald Trump", Lowercase_Epost = "donald.trump@gov.com", Tlf = "12121212", EnhetId = 1 }
                    );
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Styremedlem", b =>
                {
                    b.HasBaseType("Oppslagstavle.Models.OppslagstavleContext+Person");

                    b.Property<int>("BorettslagId");

                    b.Property<bool>("Styreleder");

                    b.HasIndex("BorettslagId");

                    b.ToTable("Styremedlem");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Bygg", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Borettslag", "Borettslag")
                        .WithMany("Bygg")
                        .HasForeignKey("BorettslagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Enhet", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Bygg", "Bygg")
                        .WithMany("Enheter")
                        .HasForeignKey("ByggId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Oppslag", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Styremedlem", "Styremedlem")
                        .WithMany("Oppslag")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+OppslagIBygg", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Bygg", "Bygg")
                        .WithMany("OppslagIBygg")
                        .HasForeignKey("ByggId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Oppslag", "Oppslag")
                        .WithMany("OppslagIBygg")
                        .HasForeignKey("OppslagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Beboer", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Enhet", "Enhet")
                        .WithMany("Beboere")
                        .HasForeignKey("EnhetId");
                });

            modelBuilder.Entity("Oppslagstavle.Models.OppslagstavleContext+Styremedlem", b =>
                {
                    b.HasOne("Oppslagstavle.Models.OppslagstavleContext+Borettslag", "Borettslag")
                        .WithMany("Styremedlemmer")
                        .HasForeignKey("BorettslagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
