using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.basig.linus.mge
{
    class CustomerViewModel
    {
        private LibraryAdminService Service;
        public List<Customer> AllCustomers { get; set; }
        public Customer SelectedCustomer { get; set; }
        public CustomerViewModel()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var ServerUrl = appSettings.Get("server");
            Service = new LibraryAdminService(ServerUrl);
        }

        public void LoadCustomers()
        {
            AllCustomers = Service.GetAllCustomers();
        }
    }
}
