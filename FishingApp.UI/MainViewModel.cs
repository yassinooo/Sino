using FishingApp.Business;
using FishingApp.Models;
using System.Collections.ObjectModel;

namespace FishingApp.UI
{
    public class MainViewModel
    {
        public ObservableCollection<Bid> Bids { get; set; } = new ObservableCollection<Bid>();

        private readonly IBidService _bidService;

        public MainViewModel(IBidService bidService)
        {
            _bidService = bidService;
            Load();
        }

        private void Load()
        {
            var bids = _bidService.GetAllBids();
            Bids.Clear();
            foreach (var b in bids)
                Bids.Add(b);
        }
    }
}
