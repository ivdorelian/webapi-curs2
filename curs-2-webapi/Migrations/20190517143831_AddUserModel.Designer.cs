﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using curs_2_webapi.Models;

namespace curs_2_webapi.Migrations
{
    [DbContext(typeof(FlowersDbContext))]
    [Migration("20190517143831_AddUserModel")]
    partial class AddUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("curs_2_webapi.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FlowerId");

                    b.Property<bool>("Important");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("FlowerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("curs_2_webapi.Models.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Colors");

                    b.Property<DateTime>("DatePicked");

                    b.Property<int>("FlowerSize");

                    b.Property<bool>("IsArtificial");

                    b.Property<string>("Name");

                    b.Property<int>("SmellLevel");

                    b.HasKey("Id");

                    b.ToTable("Flowers");
                });

            modelBuilder.Entity("curs_2_webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("curs_2_webapi.Models.Comment", b =>
                {
                    b.HasOne("curs_2_webapi.Models.Flower")
                        .WithMany("Comments")
                        .HasForeignKey("FlowerId");
                });
#pragma warning restore 612, 618
        }
    }
}