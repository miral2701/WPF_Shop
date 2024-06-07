using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Shop_WPF
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        private CollectionDataSource dataSource=new CollectionDataSource();

        public Cart(ObservableCollection<Product> a)
        {
            InitializeComponent();
            dataSource.NotifiableCollection = a;
            this.DataContext = dataSource;
            int sum = 0;
            foreach (Product p in a)
            {
                sum += p.Price * p.Count;
            }
            TotalTextBlock.Text = sum.ToString()+" $";
        }
    }

    public class CollectionDataSource
    {
        public ICollection<Product> NotifiableCollection { get; set; }
      
    }


}
