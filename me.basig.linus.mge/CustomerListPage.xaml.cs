using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace me.basig.linus.mge
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class CustomerListPage : Page
    {
        LibraryAdminService Service;

        CustomerListViewModel ViewModel { get; set; }

        public CustomerListPage()
        {
            InitializeComponent();
            ViewModel = new CustomerListViewModel();
            DataContext = ViewModel;
            ViewModel.LoadData();
        }
    }
}
