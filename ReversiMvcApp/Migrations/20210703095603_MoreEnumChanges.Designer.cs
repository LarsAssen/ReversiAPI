﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReversiMvcApp.Data;

namespace ReversiMvcApp.Migrations
{
    [DbContext(typeof(ReversiDbContext))]
    [Migration("20210703095603_MoreEnumChanges")]
    partial class MoreEnumChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReversiMvcApp.Models.Speler", b =>
                {
                    b.Property<string>("GUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AantalGelijk")
                        .HasColumnType("int");

                    b.Property<int>("AantalGewonnen")
                        .HasColumnType("int");

                    b.Property<int>("AantalVerloren")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpelID")
                        .HasColumnType("int");

                    b.HasKey("GUID");

                    b.HasIndex("SpelID");

                    b.ToTable("Speler");
                });

            modelBuilder.Entity("ReversiMvcApp.Models.Stone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kleur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpelID")
                        .HasColumnType("int");

                    b.Property<int>("xLocation")
                        .HasColumnType("int");

                    b.Property<int>("yLocation")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SpelID");

                    b.ToTable("Stone");
                });

            modelBuilder.Entity("ReversiMvcApp.Spel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AandeBeurt")
                        .HasColumnType("int");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speler1GUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Speler1Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speler2GUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Speler2Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Speler1GUID");

                    b.HasIndex("Speler2GUID");

                    b.ToTable("Spel");
                });

            modelBuilder.Entity("ReversiMvcApp.Models.Speler", b =>
                {
                    b.HasOne("ReversiMvcApp.Spel", "Spel")
                        .WithMany()
                        .HasForeignKey("SpelID");
                });

            modelBuilder.Entity("ReversiMvcApp.Models.Stone", b =>
                {
                    b.HasOne("ReversiMvcApp.Spel", "Spel")
                        .WithMany("Stones")
                        .HasForeignKey("SpelID");
                });

            modelBuilder.Entity("ReversiMvcApp.Spel", b =>
                {
                    b.HasOne("ReversiMvcApp.Models.Speler", "Speler1")
                        .WithMany()
                        .HasForeignKey("Speler1GUID");

                    b.HasOne("ReversiMvcApp.Models.Speler", "Speler2")
                        .WithMany()
                        .HasForeignKey("Speler2GUID");
                });
#pragma warning restore 612, 618
        }
    }
}
