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

            this.gridAuthors.ItemsSource = db.Authors.ToList();
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

            this.gridAuthors.ItemsSource = db.Authors.ToList();
        }

        private int updatingAuthorId = 0;

        private void gridAuthors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridAuthors.SelectedIndex >= 0)
            {
                if (this.gridAuthors.SelectedItems.Count >= 0)
                {
                    if (this.gridAuthors.SelectedItems[0].GetType() == typeof(Author))
                    {
                        Author author = (Author)this.gridAuthors.SelectedItems[0];
                        this.AuthorNameChange.Text = author.AFirstName;
                        this.AuthorLastNameChange.Text = author.ALastName;
                        this.AuthorFullNameChange.Text = author.AFullName;
                        this.updatingAuthorId = author.AID;
                    }
                }
            }
        }

        private void updateAutor_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            var author = db.Authors.Where(x => x.AID == updatingAuthorId).SingleOrDefault();

            if (author != null)
            {
                author.AFirstName = this.AuthorNameChange.Text;
                author.ALastName = this.AuthorLastNameChange.Text;
                author.AFullName = this.AuthorFullNameChange.Text;
            };

            db.SaveChanges();
        }

        private void deleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Czy jesteś pewny, że chcesz usunąć autora ?", "Usuń autora", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if(msgResult == MessageBoxResult.Yes)
            {
                LibraryEntities db = new LibraryEntities();

                var author = db.Authors.Where(x => x.AID == updatingAuthorId).SingleOrDefault();
                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                };
            }
        }
    }
}
