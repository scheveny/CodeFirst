﻿// <auto-generated />
using System;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirst.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20240618101423_Shop_Init")]
    partial class Shop_Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirst.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Mail")
                        .IsUnique()
                        .HasFilter("[Mail] IS NOT NULL");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "115 rue Fontgiève",
                            Age = 36,
                            City = "Clermont-Ferrand",
                            Mail = "scheveny@gmail.com",
                            Name = "Sylvain Cheveny"
                        },
                        new
                        {
                            Id = 2,
                            Address = "12 avenue des Champs-Élysées",
                            Age = 28,
                            City = "Paris",
                            Mail = "marie.dubois@gmail.com",
                            Name = "Marie Dubois"
                        },
                        new
                        {
                            Id = 3,
                            Address = "8 rue de la Paix",
                            Age = 45,
                            City = "Lyon",
                            Mail = "paul.martin@gmail.com",
                            Name = "Paul Martin"
                        },
                        new
                        {
                            Id = 4,
                            Address = "20 rue Victor Hugo",
                            Age = 32,
                            City = "Marseille",
                            Mail = "sophie.bernard@gmail.com",
                            Name = "Sophie Bernard"
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Description = "Pêché en Atlantique Nord-Est",
                            Name = "Dos de cabillaud",
                            Price = 44.899999999999999,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 2,
                            Description = "Origine France",
                            Name = "Filet de bœuf",
                            Price = 34.5,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 3,
                            Description = "Origine France",
                            Name = "Pomme Granny Smith",
                            Price = 2.2999999999999998,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            ClientId = 4,
                            Description = "Cultivées sans pesticides",
                            Name = "Carottes bio",
                            Price = 3.1000000000000001,
                            Type = 3
                        },
                        new
                        {
                            Id = 5,
                            ClientId = 1,
                            Description = "Fromage au lait cru",
                            Name = "Camembert de Normandie",
                            Price = 5.5,
                            Type = 4
                        },
                        new
                        {
                            Id = 6,
                            ClientId = 2,
                            Description = "Cuit au four à bois",
                            Name = "Pain de campagne",
                            Price = 4.2000000000000002,
                            Type = 5
                        },
                        new
                        {
                            Id = 7,
                            ClientId = 3,
                            Description = "Pâtisserie artisanale",
                            Name = "Croissant",
                            Price = 1.5,
                            Type = 6
                        },
                        new
                        {
                            Id = 8,
                            ClientId = 4,
                            Description = "Préparée maison",
                            Name = "Ratatouille en conserve",
                            Price = 6.7999999999999998,
                            Type = 7
                        },
                        new
                        {
                            Id = 9,
                            ClientId = 1,
                            Description = "Surgelés rapidement après récolte",
                            Name = "Mélange de légumes surgelés",
                            Price = 4.0,
                            Type = 8
                        });
                });

            modelBuilder.Entity("CodeFirst.Models.Product", b =>
                {
                    b.HasOne("CodeFirst.Models.Client", "Client")
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CodeFirst.Models.Client", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
