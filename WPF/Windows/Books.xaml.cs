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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        public Books()
        {
            InitializeComponent();

            LibraryEntities db = new LibraryEntities();

            this.gridBooks.ItemsSource = db.Books.ToList();
        }

        private void addBookButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            WPF.Entities.Books book = new WPF.Entities.Books()
            {
                BISBN = this.BookISBN.Text,
                BTitle = this.BookTitle.Text,
            };

            db.Books.Add(book);
            db.SaveChanges();
        }

        private void loadBooks_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            this.gridBooks.ItemsSource = db.Books.ToList();
        }

        private int updatingBookId = 0;

        private void gridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridBooks.SelectedIndex >= 0)
            {
                if (this.gridBooks.SelectedItems.Count >= 0)
                {
                    if (this.gridBooks.SelectedItems[0].GetType() == typeof(WPF.Entities.Books))
                    {
                        WPF.Entities.Books book = (WPF.Entities.Books)this.gridBooks.SelectedItems[0];
                        this.BookISBNChange.Text = book.BISBN;
                        this.BookTitleChange.Text = book.BTitle;
                        this.updatingBookId = book.BID;
                    }
                }
            }
        }

        private void updateBook_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            var book = db.Books.Where(x => x.BID == updatingBookId).SingleOrDefault();

            if (book != null)
            {
                book.BISBN = this.BookISBNChange.Text;
                book.BTitle = this.BookTitleChange.Text;
            };

            db.SaveChanges();
        }

        private void deleteBook_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Czy jesteś pewny, że chcesz usunąć książkę ?", "Usuń książkę", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (msgResult == MessageBoxResult.Yes)
            {
                LibraryEntities db = new LibraryEntities();

                var book = db.Books.Where(x => x.BID == updatingBookId).SingleOrDefault();
                if (book != null)
                {
                    db.Books.Remove(book);
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
        private void OpenMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWindow.Show();
        }
    }
}
