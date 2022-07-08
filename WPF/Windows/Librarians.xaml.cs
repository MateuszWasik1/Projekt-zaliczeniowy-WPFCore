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
    /// Interaction logic for Librarians.xaml
    /// </summary>
    public partial class Librarians : Window
    {
        public Librarians()
        {
            InitializeComponent();

            LibraryEntities db = new LibraryEntities();

            this.gridLibrarians.ItemsSource = db.Librarians.ToList();
        }

        private void addLibrarianButton_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            WPF.Entities.Librarians librarian = new WPF.Entities.Librarians()
            {
                LFirstName = this.LibrarianName.Text,
                LLastName = this.LibrarianLastName.Text,
                LEmail = this.LibrarianEmail.Text,
            };

            db.Librarians.Add(librarian);
            db.SaveChanges();
        }

        private void loadLibrarians_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            this.gridLibrarians.ItemsSource = db.Librarians.ToList();
        }

        private int updatingLibrarianId = 0;

        private void gridLibrarians_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridLibrarians.SelectedIndex >= 0)
            {
                if (this.gridLibrarians.SelectedItems.Count >= 0)
                {
                    if (this.gridLibrarians.SelectedItems[0].GetType() == typeof(WPF.Entities.Librarians))
                    {
                        WPF.Entities.Librarians librarian = (WPF.Entities.Librarians)this.gridLibrarians.SelectedItems[0];
                        this.LibrarianNameChange.Text = librarian.LFirstName;
                        this.LibrarianLastNameChange.Text = librarian.LLastName;
                        this.LibrarianEmailChange.Text = librarian.LEmail;
                        this.updatingLibrarianId = librarian.LID;
                    }
                }
            }
        }

        private void updateLibrarian_Click(object sender, RoutedEventArgs e)
        {
            LibraryEntities db = new LibraryEntities();

            var librarian = db.Librarians.Where(x => x.LID == updatingLibrarianId).SingleOrDefault();

            if (librarian != null)
            {
                librarian.LFirstName = this.LibrarianNameChange.Text;
                librarian.LLastName = this.LibrarianLastNameChange.Text;
                librarian.LEmail = this.LibrarianEmailChange.Text;
            };

            db.SaveChanges();
        }

        private void deleteLibrarian_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Czy jesteś pewny, że chcesz usunąć bibliotekarza?", "Usuń bibliotekarza", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (msgResult == MessageBoxResult.Yes)
            {
                LibraryEntities db = new LibraryEntities();

                var librarian = db.Librarians.Where(x => x.LID == updatingLibrarianId).SingleOrDefault();
                if (librarian != null)
                {
                    db.Librarians.Remove(librarian);
                    db.SaveChanges();
                };
            }
        }
    }
}
