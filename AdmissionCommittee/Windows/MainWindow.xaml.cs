using AdmissionCommittee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace AdmissionCommittee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db.Database.EnsureCreated();
            db.Entrants.Load();
            DataContext = db.Entrants.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EntrantWindow EntrantWindow = new EntrantWindow(new Entrant());
            if (EntrantWindow.ShowDialog() == true)
            {
                Entrant Entrant = EntrantWindow.Entrant;
                db.Entrants.Add(Entrant);
                db.SaveChanges();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Entrant? entrant = entrantsList.SelectedItem as Entrant;
            if (entrant is null) return;

            EntrantWindow EntrantWindow = new EntrantWindow(new Entrant
            {
                Id = entrant.Id,
                FirstName = entrant.FirstName, 
                LastName = entrant.LastName,
                Patronymic = entrant.Patronymic,
                Gender = entrant.Gender,
                DateOfBirth = entrant.DateOfBirth,
                Age = entrant.Age,
                GradeAverage = entrant.GradeAverage,
                Citizenship = entrant.Citizenship,
                Location = entrant.Location,
                AfterSchool = entrant.AfterSchool,
                Documents = entrant.Documents
            });

            if (EntrantWindow.ShowDialog() == true)
            {
                entrant = db.Entrants.Find(EntrantWindow.Entrant.Id);
                if (entrant != null)
                {
                    entrant.FirstName = EntrantWindow.Entrant.FirstName;
                    entrant.LastName = EntrantWindow.Entrant.LastName;
                    entrant.Patronymic = EntrantWindow.Entrant.Patronymic;
                    entrant.Gender = EntrantWindow.Entrant.Gender;
                    entrant.DateOfBirth = entrant.DateOfBirth;
                    entrant.Age = EntrantWindow.Entrant.Age;
                    entrant.GradeAverage = EntrantWindow.Entrant.GradeAverage;
                    entrant.Citizenship = EntrantWindow.Entrant.Citizenship;
                    entrant.Location = EntrantWindow.Entrant.Location;
                    entrant.AfterSchool = EntrantWindow.Entrant.AfterSchool;
                    entrant.Documents = EntrantWindow.Entrant.Documents;

                    db.SaveChanges();
                    entrantsList.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Entrant? entrant = entrantsList.SelectedItem as Entrant;
            if (entrant is null) return;
            db.Entrants.Remove(entrant);
            db.SaveChanges();
        }
    }
}
