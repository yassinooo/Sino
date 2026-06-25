using System.Windows;
using FishingApp.Models;

namespace FishingApp.UI
{
    public partial class BuyersWindow : Window
    {
        private readonly BuyersViewModel _vm;
        public BuyersWindow(BuyersViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
            DataContext = _vm;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var sample = new Buyer { BuyerName = "New Buyer", BuyerAddress = "Address", BuyerPhone = "000" };
            _vm.Add(sample);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DgBuyers.SelectedItem is Buyer b)
            {
                _vm.Delete(b);
            }
        }
    }
}
