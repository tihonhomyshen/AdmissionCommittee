using AdmissionCommittee.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Win32;
using Microsoft.Windows.Themes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

            orphanComboBox.ItemsSource = new string[]
            {
                "Да", "Нет"
            };

            statusComboBox.ItemsSource = new string[]
            {
                "Бюджетной", "Платной",
            };

            disableComboBox.ItemsSource = new string[]
            {
                "Да", "Нет"
            };

            enrollmentComboBox.ItemsSource = new string[]
            {
                "Да", "Нет"
            };

            citizenshipComboBox.ItemsSource = new string[]
            {
                "Россия", "Армения", "Азербайджан", "Беларусь", "Казахстан",
                "Кыргызстан", "Узбекистан", "Таджикистан", "Другие",
            };

            specialityComboBox.ItemsSource = new string[]
            {
                "Специальность 07.02.01 - «Архитектура»", "Специальность 21.02.09 - «Гидрогеология и инженерная геология»",
                "Специальность 09.02.07 - «Информационные системы и программирование»", "Специальность 08.02.01 - «Строительство и эксплуатация зданий и сооружений»",
                "Специальность 11.02.17 - «Разработка электронных устройств и систем»", "Специальность 38.02.01 - «Экономика и бухгалтерский учет» (по отраслям)»",
            };

            locationComboBox.ItemsSource = new string[]
            {
                "Костромская область", "Республика Адыгея", "Республика Алтай", "Республика Башкортостан", "Республика Бурятия",
                "Республика Дагестан", "Донецкая Народная Республика", "Республика Ингушетия", 
                "Кабардино-Балкарская Республика", "Карачаево-Черкесская Республика", "Республика Калмыкия",
                "Республика Карелия", "Республика Коми", "Республика Крым", "Луганская Народная Республика",
                "Республика Марий Эл", "Республика Мордовия", "Республика Саха(Якутия)", "Республика Северная Осетия-Алания",
                "Республика Татарстан", "Республика Тыва", "Удмуртская Республика", "Республика Хакасия", "Чеченская Республика",
                "Чувашская Республика-Чувашия", "Алтайский край", "Забайкальский край", "Камчатский край", "Краснодарский край",
                "Красноярский край", "Пермский край", "Приморский край", "Ставропольский край", "Хабаровский край",
                "Амурская область", "Архангельская область", "Астраханская область", "Белгородская область", "Брянская область,",
                "Владимирская область", "Волгоградская область", "Воронежская область", "Запорожская область", "Ивановская область",
                "Иркутская область", "Калининградская область", "Калужская область", "Кемеровская область", "Кировская область",
                "Курганская область", "Курская область", "Ленинградская область", "Липецкая область",
                "Магаданская область", "Московская область", "Мурманская область", "Нижегородская область", "Новгородская область",
                "Новосибирская область", "Омская область", "Оренбургская область", "Орловская область", "Пензенская область",
                "Псковская область", "Ростовская область", "Рязанская область", "Самарская область", "Саратовская область",
                "Сахалинская область", "Свердловская область", "Смоленская область", "Тамбовская область", "Тверская область",
                "Томская область", "Тульская область", "Тюменская область", "Ульяновская область", "Херсонская область", 
                "Челябинская область", "Ярославская область", "Москва", "Санкт-Петербург", "Севастополь", "Еврейская АО",
                "Ненецкий АО", "Ханты-Мансийский АО", "Чукотский АО", "Ямало-Ненецкий АО", "Иностранный гражданин",
            };

            afterschoolComboBox.ItemsSource = new string[]
            {
                "Закончил только 9 классов", "Закончил только 11 классов", "Обучался в другом месте",
            };

            regionComboBox.ItemsSource = new string[]
            {
                "г.Кострома", "г.Буй", "г.Волгореченск", "г.Галич", "г.Мантурово", "г.Шарья","г.Нерехта и Нерехтский район", 
                "Антроповский район", "Буйский район", "Вохомский район", "Галический район", "Кадыйский район", "Костромской район",
                "Красносельский район", "Макарьевский район", "Октябрьский район","Островский район", "Павинский район", 
                "Поназыревский район", "Пыщугский район", "Солигаличиский район","Судиславский район", "Сусанинский район",
                "Чухломской район", "Шарьинский район", "Межевской МО", "Кологривский МО", "Нейский МО", "Парфеньевский МО",
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

        private void citizenshipComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если выбрано "Другие" -> текстбокс для записи гос-ва, иначе очищается
            if (citizenshipComboBox.SelectedValue != null && citizenshipComboBox.SelectedValue.ToString() == "Другие") {
                CitizenshipTextBox.IsEnabled = true;
            }

            else { CitizenshipTextBox.IsEnabled = false; CitizenshipTextBox.Text = "";  }


            // Автоматическое выставление полей для иностранных гражданинов (ин.гр. _ locationCombobox)

            if (e.AddedItems.Count > 0 && e.AddedItems[0].ToString() == "Другие") {
                CitizenshipTextBox.Text = string.Empty;
            }
        }



        private void locationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (locationComboBox.SelectedValue != null && locationComboBox.SelectedValue.ToString() == "Костромская область")
            {
                regionComboBox.IsEnabled = true;
            }
            else {  regionComboBox.IsEnabled = false; regionComboBox.Text = ""; }
        }

        private void afterschoolComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (afterschoolComboBox.SelectedValue != null && afterschoolComboBox.SelectedValue.ToString() == "Обучался в другом месте")
            {
                EducationTextBox.IsEnabled = true;
            }
            else { EducationTextBox.IsEnabled = false; EducationTextBox.Text = ""; }
        }

        private void OrphanAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Entrant.OrphanImg = imageBytes;
            }
        }

        private void DisableAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Entrant.DisableImg = imageBytes;
            }
        }

        private void orphanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orphanComboBox.SelectedValue != null && orphanComboBox.SelectedValue.ToString() == "Да")
            {
                OrphanButton.IsEnabled = true;
            }
            else {  OrphanButton.IsEnabled = false;}
        }

        private void disableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (disableComboBox.SelectedValue != null && disableComboBox.SelectedValue.ToString() == "Да")
            {
                DisableButton.IsEnabled = true;
            }
            else { DisableButton.IsEnabled = false; }
        }
    }
}