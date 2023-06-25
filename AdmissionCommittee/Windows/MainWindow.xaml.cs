using AdmissionCommittee.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public partial class MainWindow : System.Windows.Window
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
            entrantsDataGrid.ItemsSource = db.Entrants.Local.ToObservableCollection();
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
            Entrant? entrant = entrantsDataGrid.SelectedItem as Entrant;
            if (entrant is null) return;

            EntrantWindow EntrantWindow = new EntrantWindow(new Entrant
            {
                Id = entrant.Id,
                LastName = entrant.LastName,
                FirstName = entrant.FirstName, 
                Patronymic = entrant.Patronymic,
                Gender = entrant.Gender,
                DateOfBirth = entrant.DateOfBirth,
                Age = entrant.Age,
                GradeAverage = entrant.GradeAverage,
                Citizenship = entrant.Citizenship,
                CitizenshipDiff = entrant.CitizenshipDiff,
                Location = entrant.Location,
                Region = entrant.Region,
                AfterSchool = entrant.AfterSchool,
                EducationPlace = entrant.EducationPlace,
                Speciality = entrant.Speciality,
                SNILS = entrant.SNILS,
                Disable = entrant.Disable,
                Orphan = entrant.Orphan,
                Status = entrant.Status,
                Enrollment = entrant.Enrollment,
                Year = entrant.Year,
                OrphanImg = entrant.OrphanImg,
                DisableImg = entrant.DisableImg,
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
                    entrant.CitizenshipDiff = EntrantWindow.Entrant.CitizenshipDiff;
                    entrant.Location = EntrantWindow.Entrant.Location;
                    entrant.Region = EntrantWindow.Entrant.Region;
                    entrant.AfterSchool = EntrantWindow.Entrant.AfterSchool;
                    entrant.EducationPlace = EntrantWindow.Entrant.EducationPlace;
                    entrant.SNILS = EntrantWindow.Entrant.SNILS;
                    entrant.Speciality = EntrantWindow.Entrant.Speciality;
                    entrant.Disable = EntrantWindow.Entrant.Disable;
                    entrant.Enrollment = EntrantWindow.Entrant.Enrollment;
                    entrant.Orphan = EntrantWindow.Entrant.Orphan;
                    entrant.Status = EntrantWindow.Entrant.Status;
                    entrant.Year = EntrantWindow.Entrant.Year;
                    entrant.OrphanImg = EntrantWindow.Entrant.OrphanImg;
                    entrant.DisableImg = EntrantWindow.Entrant.DisableImg;

                    db.SaveChanges();
                    entrantsDataGrid.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Entrant? entrant = entrantsDataGrid.SelectedItem as Entrant;
            if (entrant is null) return;
            db.Entrants.Remove(entrant);
            db.SaveChanges();
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ObservableCollection<Entrant> entrants = db.Entrants.Local.ToObservableCollection();
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                string fileName = "Абитуриенты";
                string filePath = @".\\..\\..\\..\" + fileName + ".xlsx";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                FileInfo newFile = new FileInfo(filePath);

                using (ExcelPackage exlpck = new ExcelPackage(newFile))
                {
                    ExcelWorksheet worksheet = exlpck.Workbook.Worksheets.Add("Абитуриенты");
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Имя";
                    worksheet.Cells[1, 3].Value = "Фамилия";
                    worksheet.Cells[1, 4].Value = "Отчество";
                    worksheet.Cells[1, 5].Value = "Пол";
                    worksheet.Cells[1, 6].Value = "Дата рождения";
                    worksheet.Cells[1, 7].Value = "Возраст";
                    worksheet.Cells[1, 8].Value = "Ср.балл";
                    worksheet.Cells[1, 9].Value = "Гражданство";
                    worksheet.Cells[1, 10].Value = "Гр. другое";
                    worksheet.Cells[1, 11].Value = "Субъект РФ";
                    worksheet.Cells[1, 12].Value = "Регион/город";
                    worksheet.Cells[1, 13].Value = "После 9/11";
                    worksheet.Cells[1, 14].Value = "Место обучения";
                    worksheet.Cells[1, 15].Value = "Специальность";
                    worksheet.Cells[1, 16].Value = "СНИЛС";
                    worksheet.Cells[1, 17].Value = "Инвалидность";
                    worksheet.Cells[1, 18].Value = "Сирота";
                    worksheet.Cells[1, 19].Value = "Поступил";
                    worksheet.Cells[1, 20].Value = "Год";
                    worksheet.Cells[1, 21].Value = "пр.Сирота";
                    worksheet.Cells[1, 22].Value = "пр.Инвалидность";
                    for (int i = 0; i < entrants.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = entrants[i].Id.ToString();
                        worksheet.Cells[i + 2, 2].Value = entrants[i].FirstName;
                        worksheet.Cells[i + 2, 3].Value = entrants[i].LastName;
                        worksheet.Cells[i + 2, 4].Value = entrants[i].Patronymic;
                        worksheet.Cells[i + 2, 5].Value = entrants[i].Gender;
                        worksheet.Cells[i + 2, 6].Value = entrants[i].DateOfBirth;
                        worksheet.Cells[i + 2, 7].Value = entrants[i].Age;
                        worksheet.Cells[i + 2, 8].Value = entrants[i].GradeAverage;
                        worksheet.Cells[i + 2, 9].Value = entrants[i].Citizenship;
                        worksheet.Cells[i + 2, 10].Value = entrants[i].CitizenshipDiff;
                        worksheet.Cells[i + 2, 11].Value = entrants[i].Location;
                        worksheet.Cells[i + 2, 12].Value = entrants[i].Region;
                        worksheet.Cells[i + 2, 13].Value = entrants[i].AfterSchool;
                        worksheet.Cells[i + 2, 14].Value = entrants[i].EducationPlace;
                        worksheet.Cells[i + 2, 15].Value = entrants[i].Speciality;
                        worksheet.Cells[i + 2, 16].Value = entrants[i].SNILS;
                        worksheet.Cells[i + 2, 17].Value = entrants[i].Disable;
                        worksheet.Cells[i + 2, 18].Value = entrants[i].Orphan;
                        worksheet.Cells[i + 2, 19].Value = entrants[i].Enrollment;
                        worksheet.Cells[i + 2, 20].Value = entrants[i].Year;
                        if (entrants[i].OrphanImg != null && entrants[i].OrphanImg.Length > 0)
                        {
                            worksheet.Cells[i + 2, 22].Value = "Да";
                        }
                        else { worksheet.Cells[i + 2, 22].Value = "Нет"; }
                        if (entrants[i].DisableImg != null && entrants[i].DisableImg.Length > 0)
                        {
                            worksheet.Cells[i + 2, 23].Value = "Да";
                        }
                        else { worksheet.Cells[i + 2, 23].Value = "Нет"; }
                    }
                    int columnCount = worksheet.Dimension.End.Column;
                    for (int i = 1; i < columnCount; i++)
                    {
                        worksheet.Column(i).AutoFit();
                    }


                    // Вызываем метод AutoFitRows для всего листа, чтобы подогнать высоту каждой строки по содержимому
                    exlpck.Save();
                }
                MessageBox.Show("Создался файл" + " " + fileName + ".xlsx");
            }
            catch
            {
                MessageBox.Show("Не удалось создать");
            }
        }




        private void Search_TBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                entrantsDataGrid.ItemsSource = db.Entrants.Where(item => item.FirstName == Search_TBox.Text || item.FirstName.Contains(Search_TBox.Text)
                    || item.LastName == Search_TBox.Text || item.LastName.Contains(Search_TBox.Text) 
                    || item.Gender == Search_TBox.Text || item.Gender.Contains(Search_TBox.Text)).ToList();
                    
            }

            catch (Exception ex){ 
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
