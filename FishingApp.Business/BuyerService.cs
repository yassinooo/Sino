using FishingApp.Models;
using FishingApp.Data;
using System.Collections.Generic;
using System.Linq;

namespace FishingApp.Business
{
    public interface IBuyerService
    {
        IEnumerable<Buyer> GetAll();
        Buyer GetById(int id);
        void Add(Buyer entity);
        void Update(Buyer entity);
        void Delete(Buyer entity);
        void Save();
    }

    public class BuyerService : IBuyerService
    {
        private readonly IRepository<Buyer> _repo;
        public BuyerService(IRepository<Buyer> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Buyer> GetAll() => _repo.GetAll().ToList();
        public Buyer GetById(int id) => _repo.GetById(id);
        public void Add(Buyer entity) { _repo.Add(entity); _repo.Save(); }
        public void Update(Buyer entity) { _repo.Update(entity); _repo.Save(); }
        public void Delete(Buyer entity) { _repo.Delete(entity); _repo.Save(); }
        public void Save() => _repo.Save();
    }
}
