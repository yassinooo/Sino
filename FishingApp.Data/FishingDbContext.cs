using FishingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FishingApp.Data
{
    public class FishingDbContext : DbContext
    {
        public FishingDbContext(DbContextOptions<FishingDbContext> options) : base(options) { }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Fisherman> Fishermen { get; set; }
        public DbSet<Auctioneer> Auctioneers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<FishingType> FishingTypes { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Catch> Catches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Basic mapping and relations
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Fisherman)
                .WithMany()
                .HasForeignKey(b => b.FishermanID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Auctioneer)
                .WithMany()
                .HasForeignKey(b => b.AuctioneerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Writer)
                .WithMany()
                .HasForeignKey(b => b.WriterID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.Bid)
                .WithMany()
                .HasForeignKey(c => c.BidID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.Buyer)
                .WithMany()
                .HasForeignKey(c => c.BuyerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Catch>()
                .HasOne(c => c.FishingType)
                .WithMany()
                .HasForeignKey(c => c.FishingTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
