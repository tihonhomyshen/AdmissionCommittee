﻿// <auto-generated />
using AdmissionCommittee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdmissionCommittee.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230626094339_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("AdmissionCommittee.Models.Entrant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AfterSchool")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Citizenship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CitizenshipDiff")
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOfBirth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Disable")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("DisableImg")
                        .HasColumnType("BLOB");

                    b.Property<string>("EducationPlace")
                        .HasColumnType("TEXT");

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("GradeAverage")
                        .HasColumnType("REAL");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Orphan")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("OrphanImg")
                        .HasColumnType("BLOB");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<string>("SNILS")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Entrants");
                });
#pragma warning restore 612, 618
        }
    }
}