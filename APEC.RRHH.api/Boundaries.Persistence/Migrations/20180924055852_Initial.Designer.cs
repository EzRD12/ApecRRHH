﻿// <auto-generated />
using System;
using Boundaries.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Boundaries.Persistence.Migrations
{
    [DbContext(typeof(ApecRrhhContext))]
    [Migration("20180924055852_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.Competence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(400)");

                    b.Property<Guid?>("JobId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Competence");
                });

            modelBuilder.Entity("Core.Models.Departament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Departament");
                });

            modelBuilder.Entity("Core.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<Guid>("JobId");

                    b.Property<int>("MonthlySalary");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Core.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrencyType");

                    b.Property<Guid>("DepartamentId");

                    b.Property<int>("MaximumSalary");

                    b.Property<int>("MinimumSalary");

                    b.Property<int>("MinimumYearsExperienceLaboral");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("RiskLevel");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Core.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("JobId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int>("CurrentRole");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Identification")
                        .HasColumnType("varchar(400)");

                    b.Property<int>("IdentificationType");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(700);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(400)")
                        .HasMaxLength(900);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.Competence", b =>
                {
                    b.HasOne("Core.Models.Job")
                        .WithMany("Competences")
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("Core.Models.Employee", b =>
                {
                    b.HasOne("Core.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.Job", b =>
                {
                    b.HasOne("Core.Models.Departament", "Departament")
                        .WithMany("Jobs")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.Language", b =>
                {
                    b.HasOne("Core.Models.Job")
                        .WithMany("Languages")
                        .HasForeignKey("JobId");
                });
#pragma warning restore 612, 618
        }
    }
}
