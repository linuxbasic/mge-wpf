using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System.Collections.Generic;
using System.Configuration;

namespace me.basig.linus.mge
{
    class CustomerListViewModel
    {
        private LibraryAdminService Service;
        public List<Customer> Customers { get; set; } 

        public CustomerListViewModel()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var ServerUrl = appSettings.Get("server");
            Service = new LibraryAdminService(ServerUrl);
        }

        public void LoadData()
        {
            Customers = Service.GetAllCustomers();
        }
    }
}
