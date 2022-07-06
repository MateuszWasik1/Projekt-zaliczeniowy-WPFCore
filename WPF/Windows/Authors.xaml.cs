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
    /// Interaction logic for Authors.xaml
    /// </summary>
    public partial class Authors : Window
    {
        public Authors()
        {
            InitializeComponent();

            LibraryEntities db = new LibraryEntities();
            var authors = from a in db.Authors 
                          select new { 
                              FirstName = a.AFirstName,
                              LastName = a.ALastName,
                              FullName = a.AFullName
                          };

            this.gridAuthors.ItemsSource = authors.ToList();

        }

        private void addAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            Author author = new Author()
            {
                AFirstName = this.AuthorName.Text,
                ALastName = this.AuthorLastName.Text,
                AFullName = this.AuthorFullName.Text,
            };

            db.Authors.Add(author);
            db.SaveChanges();
        }

        private void loadAuthors_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            var authors = from a in db.Authors
                          select new
                          {
                              FirstName = a.AFirstName,
                              LastName = a.ALastName,
                              FullName = a.AFullName
                          };

            this.gridAuthors.ItemsSource = authors.ToList();
        }
    }
}
