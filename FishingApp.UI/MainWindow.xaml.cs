using System.Windows;

namespace FishingApp.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm, BuyersWindow buyersWindow)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void MenuItem_Buyers_Click(object sender, RoutedEventArgs e)
        {
            // Resolve BuyersWindow from DI
            var w = ((App)Application.Current)._host.Services.GetService(typeof(BuyersWindow)) as BuyersWindow;
            w?.ShowDialog();
        }
    }
}
