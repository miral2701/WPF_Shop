using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Cart2=new ObservableCollection<Product>();

        ProductDataSource p =new ProductDataSource();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                foreach(var item in p.Products)
            {
                if (item==listBox1.SelectedItem)
                {
                    item.Count--;
                    Product pr = new Product(item.Name,item.Price,1,"");
                    Cart2.Add(pr);
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(Cart2);
            cart.Show();
        }
    }

    public  class ProductDataSource
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductDataSource()
        {
            Products = new[]
            {
                new Product("Apple", 2, 23,"Resources/apple.png"),
                new Product("Orange", 5, 19,"Resources/orange.png"),
                new Product("Cherry", 6, 40, "Resources/chery2.png"),
                new Product("Pineapple", 13, 60, "Resources/Pineapple.png"),
                new Product("Banana", 3, 45, "Resources/banana.png")

             };
        }
    }

    public class Product:INotifyPropertyChanged
    {
        private int price;
        private  string name;
        private  int count;
        private readonly string image;

        public Product(string name, int price, int count,string source)
        {
            this.price = price;
            this.name = name;
            this.count = count;
            image = source;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int Count
        {
            set
            {
                count = value;
                NotifyPropertyChanged();

            }
            get
            {
                return count;
            }
        }
        public bool IsActive { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                value = name;
            }
        }
        public string Image => image;

        public int Price => price;
        //public override string ToString()
        //{
        //    return"Name: "+Name+"\n"+"Price: "+Price+"\n"+"Count: "+Count;
        //}
    }
}