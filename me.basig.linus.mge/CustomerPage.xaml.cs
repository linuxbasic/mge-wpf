using ch.hsr.wpf.gadgeothek.service;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace me.basig.linus.mge
{
    /// <summary>
    /// Interaktionslogik für CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        CustomerViewModel ViewModel { get; set; }
        public CustomerPage()
        {
            InitializeComponent();
            var appSettings = ConfigurationManager.AppSettings;
            var ServerUrl = appSettings.Get("server");
            var Service = new LibraryAdminService(ServerUrl);
            ViewModel = new CustomerViewModel(Service);
            DataContext = ViewModel;
            ViewModel.LoadCustomers();
        }


        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.SaveCustomer();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ViewModel.DeleteCustomer();
            }
               
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.NewCustomer();
        }

        private void Reset_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.ResetCustomer();
        }
    }
}
