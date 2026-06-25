using System;

namespace FishingApp.Models
{
    public class Buyer
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerPhone { get; set; }
        public DateTime? DateRegistered { get; set; }
        public bool IsCreditEnabled { get; set; }
        public decimal? CreditLimit { get; set; }
        public decimal? CurrentBalance { get; set; }
    }

    public class Fisherman
    {
        public int FishermanID { get; set; }
        public string FishermanName { get; set; }
        public string FishermanNote { get; set; }
    }

    public class Auctioneer
    {
        public int AuctioneerID { get; set; }
        public string AuctioneerName { get; set; }
        public string AuctioneerNote { get; set; }
    }

    public class Writer
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterNote { get; set; }
    }

    public class FishingType
    {
        public int FishingTypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class Bid
    {
        public int BidID { get; set; }
        public int FishermanID { get; set; }
        public int AuctioneerID { get; set; }
        public int WriterID { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidDate { get; set; }
        public decimal? BidTax { get; set; }
        public decimal? BidTaxAmount { get; set; }
        public string BidNumber { get; set; }
        public string Notes { get; set; }

        // Navigation
        public Fisherman Fisherman { get; set; }
        public Auctioneer Auctioneer { get; set; }
        public Writer Writer { get; set; }
    }

    public class Catch
    {
        public int CatchID { get; set; }
        public int BidID { get; set; }
        public int BuyerID { get; set; }
        public int FishingTypeID { get; set; }
        public DateTime CatchDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Tax { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal WeightKG { get; set; }
        public int Quantity { get; set; }

        // Navigation
        public Bid Bid { get; set; }
        public Buyer Buyer { get; set; }
        public FishingType FishingType { get; set; }
    }
}
