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
using System.Windows.Shapes;
using WPF.Entities;

namespace WPF.Windows
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {

        public Customers()
        {
            InitializeComponent();

            LibraryEntities db = new LibraryEntities();

            this.gridCustomers.ItemsSource = db.Customers.ToList();
        }

        private void addCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            WPF.Entities.Customers customer = new WPF.Entities.Customers()
            {
                CFirstName = this.CustomerName.Text,
                CLastName = this.CustomerLastName.Text,
                CCardName = this.CustomerCard.Text,
            };

            db.Customers.Add(customer);
            db.SaveChanges();
        }

        private void loadCustomers_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            this.gridCustomers.ItemsSource = db.Customers.ToList();
        }

        private int updatingCustomerId = 0;

        private void gridCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridCustomers.SelectedIndex >= 0)
            {
                if (this.gridCustomers.SelectedItems.Count >= 0)
                {
                    if (this.gridCustomers.SelectedItems[0].GetType() == typeof(WPF.Entities.Customers))
                    {
                        WPF.Entities.Customers customer = (WPF.Entities.Customers)this.gridCustomers.SelectedItems[0];
                        this.CustomerNameChange.Text = customer.CFirstName;
                        this.CustomerLastNameChange.Text = customer.CLastName;
                        this.CustomerCardChange.Text = customer.CCardName;
                        this.updatingCustomerId = customer.CID;
                    }
                }
            }
        }

        private void updateCustomer_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            var customer = db.Customers.Where(x => x.CID == updatingCustomerId).SingleOrDefault();

            if (customer != null)
            {
                customer.CFirstName = this.CustomerNameChange.Text;
                customer.CLastName = this.CustomerLastNameChange.Text;
                customer.CCardName = this.CustomerCardChange.Text;
            };

            db.SaveChanges();
        }

        private void deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Czy jesteś pewny, że chcesz usunąć klienta?", "Usuń klienta", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (msgResult == MessageBoxResult.Yes)
            {
                LibraryEntities db = new LibraryEntities();

                var customer = db.Customers.Where(x => x.CID == updatingCustomerId).SingleOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                };
            }
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
        private void OpenLibrarians_Click(object sender, RoutedEventArgs e)
        {
            Librarians librarians = new Librarians();
            this.Visibility = Visibility.Hidden;
            librarians.Show();
        }
        private void OpenMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
