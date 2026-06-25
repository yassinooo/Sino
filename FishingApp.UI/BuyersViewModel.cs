using System.Collections.ObjectModel;
using FishingApp.Business;
using FishingApp.Models;
using System.Linq;

namespace FishingApp.UI
{
    public class BuyersViewModel
    {
        private readonly IBuyerService _buyerService;
        public ObservableCollection<Buyer> Buyers { get; set; } = new ObservableCollection<Buyer>();

        public BuyersViewModel(IBuyerService buyerService)
        {
            _buyerService = buyerService;
            Load();
        }

        public void Load()
        {
            Buyers.Clear();
            foreach (var b in _buyerService.GetAll()) Buyers.Add(b);
        }

        public void Add(Buyer buyer)
        {
            _buyerService.Add(buyer);
            Load();
        }

        public void Delete(Buyer buyer)
        {
            _buyerService.Delete(buyer);
            Load();
        }
    }
}
