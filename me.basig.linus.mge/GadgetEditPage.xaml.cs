using ch.hsr.wpf.gadgeothek.domain;
using System.Windows.Controls;

namespace me.basig.linus.mge
{
    /// <summary>
    /// Interaktionslogik für GadgetEditPage.xaml
    /// </summary>
    public partial class GadgetEditPage : Page
    {
        public GadgetEditPage()
        {
            InitializeComponent();

            condition.ItemsSource = System.Enum.GetValues(typeof(Condition));
        }
    }
}
