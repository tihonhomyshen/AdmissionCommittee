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
                "Ненецкий АО", "Ханты-Мансийский АО", "Чукотский АО", "Ямало-Ненецкий АО",
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