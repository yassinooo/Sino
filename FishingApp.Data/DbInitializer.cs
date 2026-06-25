using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using FishingApp.Models;

namespace FishingApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<FishingDbContext>();

            // Ensure database is created (works without running migrations)
            context.Database.EnsureCreated();

            // Seed data only if empty
            if (!context.Fishermen.Any())
            {
                var fishermen = new[] {
                    new Fisherman { FishermanName = "Ahmed Ali", FishermanNote = "Local fisherman" },
                    new Fisherman { FishermanName = "Khaled Omar", FishermanNote = "Experienced" }
                };
                context.Fishermen.AddRange(fishermen);
            }

            if (!context.Auctioneers.Any())
            {
                var auctioneers = new[] {
                    new Auctioneer { AuctioneerName = "Port Auction 1", AuctioneerNote = "Main port" }
                };
                context.Auctioneers.AddRange(auctioneers);
            }

            if (!context.Writers.Any())
            {
                var writers = new[] {
                    new Writer { WriterName = "System", WriterNote = "Seeded" }
                };
                context.Writers.AddRange(writers);
            }

            if (!context.Buyers.Any())
            {
                var buyers = new[] {
                    new Buyer { BuyerName = "SuperMarket A", BuyerAddress = "Port Road", BuyerPhone = "0123456789", DateRegistered = System.DateTime.UtcNow }
                };
                context.Buyers.AddRange(buyers);
            }

            if (!context.FishingTypes.Any())
            {
                var types = new[] {
                    new FishingType { TypeName = "Tuna" },
                    new FishingType { TypeName = "Sardine" }
                };
                context.FishingTypes.AddRange(types);
            }

            if (!context.Bids.Any())
            {
                var fisherman = context.Fishermen.FirstOrDefault();
                var auctioneer = context.Auctioneers.FirstOrDefault();
                var writer = context.Writers.FirstOrDefault();

                var bids = new[] {
                    new Bid { Fisherman = fisherman, FishermanID = fisherman.FishermanID, Auctioneer = auctioneer, AuctioneerID = auctioneer.AuctioneerID, Writer = writer, WriterID = writer.WriterID, BidAmount = 1500, BidDate = System.DateTime.UtcNow, BidNumber = "BID-001" }
                };
                context.Bids.AddRange(bids);
            }

            if (!context.Catches.Any())
            {
                var bid = context.Bids.FirstOrDefault();
                var buyer = context.Buyers.FirstOrDefault();
                var type = context.FishingTypes.FirstOrDefault();

                if (bid != null && buyer != null && type != null)
                {
                    var catches = new[] {
                        new Catch { Bid = bid, BidID = bid.BidID, Buyer = buyer, BuyerID = buyer.BuyerID, FishingType = type, FishingTypeID = type.FishingTypeID, CatchDate = System.DateTime.UtcNow, TotalAmount = 2000, UnitPrice = 20, WeightKG = 100, Quantity = 50 }
                    };
                    context.Catches.AddRange(catches);
                }
            }

            context.SaveChanges();
        }
    }
}
