using FishingApp.Models;
using FishingApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace FishingApp.Business
{
    public interface IBidService
    {
        IEnumerable<Bid> GetAllBids();
    }

    public class BidService : IBidService
    {
        private readonly IRepository<Bid> _bidRepo;

        public BidService(IRepository<Bid> bidRepo)
        {
            _bidRepo = bidRepo;
        }

        public IEnumerable<Bid> GetAllBids()
        {
            return _bidRepo.GetAll().ToList();
        }
    }

    public interface ICatchService
    {
        IEnumerable<Catch> GetAllCatches();
    }

    public class CatchService : ICatchService
    {
        private readonly IRepository<Catch> _catchRepo;

        public CatchService(IRepository<Catch> catchRepo)
        {
            _catchRepo = catchRepo;
        }

        public IEnumerable<Catch> GetAllCatches()
        {
            return _catchRepo.GetAll().ToList();
        }
    }
}
