﻿// <auto-generated />
using DogTrials.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DogTrials.Migrations
{
    [DbContext(typeof(DogTrialsContext))]
    partial class DogTrialsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DogTrials.Models.Club", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("DogTrials.Models.Dog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Breed");

                    b.Property<string>("CallName");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("OwnerID");

                    b.Property<string>("RegisteredName");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int>("Sex");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("DogTrials.Models.Entry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DogID");

                    b.Property<int?>("HandlerID");

                    b.Property<bool>("Paid");

                    b.Property<int?>("StakeID");

                    b.Property<int?>("TrialID");

                    b.HasKey("ID");

                    b.HasIndex("DogID");

                    b.HasIndex("HandlerID");

                    b.HasIndex("StakeID");

                    b.HasIndex("TrialID");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("DogTrials.Models.EntryFee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Fee");

                    b.Property<int?>("StakeID");

                    b.Property<int?>("TrialID");

                    b.HasKey("ID");

                    b.HasIndex("StakeID");

                    b.HasIndex("TrialID");

                    b.ToTable("EntryFee");
                });

            modelBuilder.Entity("DogTrials.Models.Judge", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PersonID");

                    b.Property<int?>("StakeID");

                    b.Property<int?>("TrialID");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.HasIndex("StakeID");

                    b.HasIndex("TrialID");

                    b.ToTable("Judge");
                });

            modelBuilder.Entity("DogTrials.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DogTrials.Models.Stake", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("Stake");
                });

            modelBuilder.Entity("DogTrials.Models.Trial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClubID");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("ID");

                    b.HasIndex("ClubID");

                    b.ToTable("Trial");
                });

            modelBuilder.Entity("DogTrials.Models.Dog", b =>
                {
                    b.HasOne("DogTrials.Models.Person", "Owner")
                        .WithMany("Dogs")
                        .HasForeignKey("OwnerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DogTrials.Models.Entry", b =>
                {
                    b.HasOne("DogTrials.Models.Dog", "Dog")
                        .WithMany()
                        .HasForeignKey("DogID");

                    b.HasOne("DogTrials.Models.Person", "Handler")
                        .WithMany()
                        .HasForeignKey("HandlerID");

                    b.HasOne("DogTrials.Models.Stake", "Stake")
                        .WithMany()
                        .HasForeignKey("StakeID");

                    b.HasOne("DogTrials.Models.Trial", "Trial")
                        .WithMany()
                        .HasForeignKey("TrialID");
                });

            modelBuilder.Entity("DogTrials.Models.EntryFee", b =>
                {
                    b.HasOne("DogTrials.Models.Stake", "Stake")
                        .WithMany()
                        .HasForeignKey("StakeID");

                    b.HasOne("DogTrials.Models.Trial", "Trial")
                        .WithMany()
                        .HasForeignKey("TrialID");
                });

            modelBuilder.Entity("DogTrials.Models.Judge", b =>
                {
                    b.HasOne("DogTrials.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID");

                    b.HasOne("DogTrials.Models.Stake", "Stake")
                        .WithMany()
                        .HasForeignKey("StakeID");

                    b.HasOne("DogTrials.Models.Trial", "Trial")
                        .WithMany()
                        .HasForeignKey("TrialID");
                });

            modelBuilder.Entity("DogTrials.Models.Trial", b =>
                {
                    b.HasOne("DogTrials.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubID");
                });
#pragma warning restore 612, 618
        }
    }
}
