using AdmissionCommittee.Models;
using Microsoft.Windows.Themes;
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

namespace AdmissionCommittee
{
    /// <summary>
    /// Логика взаимодействия для EntrantWindow.xaml
    /// </summary>
    public partial class EntrantWindow : Window
    {
        public Entrant Entrant { get; private set; }
        public EntrantWindow(Entrant entrant)
        {
            InitializeComponent();

            gendersComboBox.ItemsSource = new string[]
            {
                "Мужской", "Женский"
            };


            citizenshipComboBox.ItemsSource = new string[]
            {
                "Россия", "Армения", "Азербайджан", "Беларусь", "Казахстан",
                "Кыргызстан", "Узбекистан", "Таджикистан",
            };



            Entrant = entrant;
            DataContext = Entrant;

        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        //public static int GetAge(string DateOfBirth)
        //{
        //    var now = DateTime.Today;
        //    DateTime dateTime = DateTime.Parse(DateOfBirth);
        //    return now.Year - dateTime.Year - 1 + ((now.Month > dateTime.Month || now.Month == dateTime.Month && now.Day >= dateTime.Day) ? 1 : 0);
        //}

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    GetAge(Entrant.DateOfBirth);
        //}
        }
    }