using AdmissionCommittee.Models;
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
            Entrant = entrant;
            DataContext = Entrant;

        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
