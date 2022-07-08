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
using WPF.Windows;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenAuthors_Click(object sender, RoutedEventArgs e)
        {
            Authors authors = new Authors();
            this.Visibility = Visibility.Hidden;
            authors.Show();
        }
        private void OpenBooks_Click(object sender, RoutedEventArgs e)
        {
            Books books = new Books();
            this.Visibility = Visibility.Hidden;
            books.Show();
        }
        private void OpenClients_Click(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            this.Visibility = Visibility.Hidden;
            customers.Show();
        }
        private void OpenLibrarians_Click(object sender, RoutedEventArgs e)
        {
            Librarians librarians = new Librarians();
            this.Visibility = Visibility.Hidden;
            librarians.Show();
        }
    }
}
