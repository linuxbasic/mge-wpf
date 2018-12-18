using ch.hsr.wpf.gadgeothek.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace me.basig.linus.mge
{
    /// <summary>
    /// Interaktionslogik für GadgetListPage.xaml
    /// </summary>
    public partial class GadgetListPage : Page
    {
        public GadgetListPage()
        {
            InitializeComponent();

            List<Gadget> items = new List<Gadget>();
            items.Add(new Gadget() { Name = "test" });

            gadgets.ItemsSource = items;
        }
    }
}
