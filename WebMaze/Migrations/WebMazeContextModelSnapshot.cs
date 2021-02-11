﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMaze.DbStuff;

namespace WebMaze.Migrations
{
    [DbContext(typeof(WebMazeContext))]
    partial class WebMazeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebMaze.DbStuff.Model.Adress", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<long?>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Bus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("BusRouteId")
                        .HasColumnType("bigint");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("WorkerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.BusRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Route")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusRoute");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.BusStop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusStop");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.CitizenUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CitizenUser");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.HealthDepartment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthDepartment");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.BodyIdentificationReport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CorpseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfIdentification")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdentifyingPersonId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDateSet")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIdentified")
                        .HasColumnType("bit");

                    b.Property<long?>("PoliceOfficerId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CorpseId")
                        .IsUnique();

                    b.HasIndex("IdentifyingPersonId");

                    b.HasIndex("PoliceOfficerId");

                    b.ToTable("BodyIdentificationReport");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.ContentForMorgue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContentForMorgue");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.ForensicReport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CauseOfDeath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CorpseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfForensic")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReportRecorded")
                        .HasColumnType("bit");

                    b.Property<long?>("PathologistId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CorpseId")
                        .IsUnique();

                    b.HasIndex("PathologistId");

                    b.ToTable("ForensicReport");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.Funeral", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CorpseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfFuneral")
                        .HasColumnType("datetime2");

                    b.Property<long?>("RitualServiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CorpseId")
                        .IsUnique();

                    b.HasIndex("RitualServiceId");

                    b.ToTable("Funeral");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BodyDamage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CorpseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ThingsFromBody")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CorpseId");

                    b.ToTable("RegisterCardForMorgue");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.RitualService", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("BurialType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrlPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RitualService");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Policeman", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Policemen");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Violation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("BlamingPolicemanId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("TypeOfViolationId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BlamingPolicemanId");

                    b.HasIndex("TypeOfViolationId");

                    b.HasIndex("UserId");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.ViolationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Article")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Penalty")
                        .HasColumnType("money");

                    b.Property<string>("Punishment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TermOfPunishment")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TypesOfViolation");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.UserTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Adress", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "Owner")
                        .WithMany("Adresses")
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Bus", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.BusRoute", "BusRoute")
                        .WithMany()
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusRoute");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.BodyIdentificationReport", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", "Corpse")
                        .WithOne("BodyIdentificationReport")
                        .HasForeignKey("WebMaze.DbStuff.Model.Morgue.BodyIdentificationReport", "CorpseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "IdentifyingPerson")
                        .WithMany()
                        .HasForeignKey("IdentifyingPersonId");

                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "PoliceOfficer")
                        .WithMany()
                        .HasForeignKey("PoliceOfficerId");

                    b.Navigation("Corpse");

                    b.Navigation("IdentifyingPerson");

                    b.Navigation("PoliceOfficer");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.ForensicReport", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", "Corpse")
                        .WithOne("ForensicReport")
                        .HasForeignKey("WebMaze.DbStuff.Model.Morgue.ForensicReport", "CorpseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "Pathologist")
                        .WithMany()
                        .HasForeignKey("PathologistId");

                    b.Navigation("Corpse");

                    b.Navigation("Pathologist");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.Funeral", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", "Corpse")
                        .WithOne("Funeral")
                        .HasForeignKey("WebMaze.DbStuff.Model.Morgue.Funeral", "CorpseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMaze.DbStuff.Model.Morgue.RitualService", "RitualService")
                        .WithMany()
                        .HasForeignKey("RitualServiceId");

                    b.Navigation("Corpse");

                    b.Navigation("RitualService");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "Corpse")
                        .WithMany()
                        .HasForeignKey("CorpseId");

                    b.Navigation("Corpse");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Policeman", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.Violation", b =>
                {
                    b.HasOne("WebMaze.DbStuff.Model.Police.Policeman", "BlamingPoliceman")
                        .WithMany()
                        .HasForeignKey("BlamingPolicemanId");

                    b.HasOne("WebMaze.DbStuff.Model.Police.ViolationType", "TypeOfViolation")
                        .WithMany("Violations")
                        .HasForeignKey("TypeOfViolationId");

                    b.HasOne("WebMaze.DbStuff.Model.CitizenUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("BlamingPoliceman");

                    b.Navigation("TypeOfViolation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.CitizenUser", b =>
                {
                    b.Navigation("Adresses");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Morgue.RegisterCardForMorgue", b =>
                {
                    b.Navigation("BodyIdentificationReport");

                    b.Navigation("ForensicReport");

                    b.Navigation("Funeral");
                });

            modelBuilder.Entity("WebMaze.DbStuff.Model.Police.ViolationType", b =>
                {
                    b.Navigation("Violations");
                });
#pragma warning restore 612, 618
        }
    }
}
