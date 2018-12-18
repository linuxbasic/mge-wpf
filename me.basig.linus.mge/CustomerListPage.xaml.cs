using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Controls;

namespace me.basig.linus.mge
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class CustomerListPage : Page
    {
        LibraryAdminService Service;

        public CustomerListPage()
        {
            InitializeComponent();
            var appSettings = ConfigurationManager.AppSettings;
            var ServerUrl = appSettings.Get("server");
            Service = new LibraryAdminService(ServerUrl);

            customers.ItemsSource = Service.GetAllCustomers();


        }
    }
}
