using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetHotel.Models;

namespace PetHotel.Data
{
    public class PetHotelContext : DbContext
    {
        public PetHotelContext (DbContextOptions<PetHotelContext> options)
            : base(options)
        {
        }

        public DbSet<PetHotel.Models.Pet> Pet { get; set; } = default!;
        public DbSet<PetHotel.Models.Owner> Owner { get; set; } = default!;
        public DbSet<PetHotel.Models.Booking> Booking { get; set; } = default!;
        public DbSet<PetHotel.Models.Room> Room { get; set; } = default!;
        public DbSet<PetHotel.Models.Category> Type { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories"); 

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("CategoryId"); 

                entity.Property(c => c.CategoryName).HasColumnName("RoomTypeName"); 
                entity.Property(c => c.Price).HasColumnType("decimal(5, 2)");

                entity.HasMany(c => c.Rooms)
                    .WithOne(r => r.Category)
                    .HasForeignKey(r => r.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Rooms"); 

                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id).HasColumnName("RoomId"); 

                entity.Property(r => r.RoomNumber).HasColumnName("RoomNumber"); 
                entity.Property(r => r.isOccupied).HasColumnName("Availability"); 

                entity.HasOne(r => r.Category)
                    .WithMany(c => c.Rooms)
                    .HasForeignKey(r => r.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull); 
            });

            base.OnModelCreating(modelBuilder);
        }



    }
}
