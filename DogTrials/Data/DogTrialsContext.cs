using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DogTrials.Models
{
    public class DogTrialsContext : DbContext
    {
        public DogTrialsContext (DbContextOptions<DogTrialsContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Stake> Stakes { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<Trial> Trials { get; set; }

        public DbSet<Entry> Entries { get; set; }

        public DbSet<EntryFee> Fees { get; set; }

        public DbSet<Judge> Judges { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dog>().ToTable("Dog");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Stake>().ToTable("Stake");
            modelBuilder.Entity<Club>().ToTable("Club");
            modelBuilder.Entity<Trial>().ToTable("Trial");
            modelBuilder.Entity<Entry>().ToTable("Entry");
            modelBuilder.Entity<EntryFee>().ToTable("EntryFee");
            modelBuilder.Entity<Judge>().ToTable("Judge");
        }
    }
}
