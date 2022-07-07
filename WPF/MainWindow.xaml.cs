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

        }
        private void OpenClients_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OpenLibrarians_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
