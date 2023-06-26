using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdmissionCommittee.Models
{
    public class Entrant: INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>(); 

        [SQLite.PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private string last_name;
        private string first_name;
        private string patronymic;
        private string gender;
        private string date_of_birth;
        private int age;
        private double grade_average;
        private string citizenship;
        private string citezenshipdiff;
        private string location;
        private string region;
        private string after_school;
        private string educationplace;
        private string speciality;
        private string disable;
        private string orphan;
        private string status;
        private string enrollment;
        private int year;
        private string snils;
        private byte[] orphan_img;
        private byte[] disable_img;

        #region Fields
        public string FirstName
        {
            get => first_name;
            set
            {
                RemoveError("FirstName");
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[а-яА-Я]+$"))
                {
                    first_name = value;
                    OnPropertyChanged("FirstName");
                }
                else
                {
                    first_name = null;
                    AddError("FirstName", "Поле может содержать только кириллицу");
                }
            }
        }

        public string LastName
        {
            get => last_name;
            set
            {
                RemoveError("LastName");
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[а-яА-Я]+$"))
                {
                    last_name = value;
                    OnPropertyChanged("LastName");
                }
                else
                {
                    last_name = null;
                    AddError("LastName", "Поле содержать только кириллицу");
                }
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set{

                RemoveError("Patronymic");
                if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[а-яА-Я]+$"))
                {
                    patronymic = value;
                    OnPropertyChanged("Patronymic");
                }
                else
                {
                    patronymic = null;
                    AddError("Patronymic", "Поле может содержать только кириллицу");
                }
            }
        }

        public string Gender
        {
            get => gender;
            set {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string DateOfBirth
        {
            get => date_of_birth;
            set
            {
                RemoveError("DateOfBirth");
                if (DateTime.TryParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                {
                    date_of_birth = value;
                    OnPropertyChanged("DateOfBirth");
                }

                else
                {
                    date_of_birth = null;
                    AddError("DateOfBirth", "Неверный формат даты");
                    Age = 0;
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public double GradeAverage
        {
            get => grade_average;
            set
            {
                RemoveError("GradeAverage");
                if (value <= 5 && value >= 3)
                {
                    grade_average = value;
                    OnPropertyChanged("GradeAverage");
                }
                else
                {
                    AddError("GradeAverage", "Ср.балл должен быть от 3 до 5");
                    grade_average = 0;
                }
            }
        }

        public string Citizenship
        {
            get => citizenship;
            set { 
                citizenship = value;
                OnPropertyChanged("Citizenship");
            }
        }

        public string? CitizenshipDiff
        {
            get => citezenshipdiff;
            set { 
                citezenshipdiff = value;
                OnPropertyChanged("CitizenshipDiff");
            }
        }

        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        public string? Region
        {
            get => region;
            set
            {
                region = value;
                OnPropertyChanged("Region");
            }
        }

        public string AfterSchool
        {
            get => after_school;
            set
            {
                after_school = value;
                OnPropertyChanged("AfterSchool");
            }

        }

        public string? EducationPlace
        {
            get => educationplace;
            set
            {
                educationplace = value;
                OnPropertyChanged("EducationPlace");
            }
        }

        public string SNILS
        {
            get => snils;
            set
            {
                RemoveError("SNILS");
                if (string.IsNullOrEmpty(value))
                {
                    AddError("SNILS", "СНИЛС не может быть пустым");
                    return;
                }

                // Удаляем все символы, кроме цифр, пробелов и дефисов
                string cleanValue = new string(value.Where(c => char.IsDigit(c) || c == ' ' || c == '-').ToArray());

                if (cleanValue.Length != 11)
                {
                    AddError("SNILS", "СНИЛС должен содержать 11 символов");
                    return;
                }

                int[] multipliers = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += multipliers[i] * int.Parse(cleanValue[i].ToString());
                }

                int controlNumber = 0;
                if (sum < 100)
                {
                    controlNumber = sum;
                }
                else if (sum == 100 || sum == 101)
                {
                    controlNumber = 0;
                }
                else
                {
                    controlNumber = sum % 101;
                }

                if (controlNumber != int.Parse(cleanValue.Substring(9)))
                {
                    AddError("SNILS", "Некорректный номер");
                    return;
                }
                

                if (new Regex(@"(\d)\1\1").IsMatch(cleanValue.Substring(0, 9)))
                {
                    AddError("SNILS", "В номере СНИЛС не может присутствовать одна и та же цифра три раза подряд");
                    return;
                }
                snils = value;
                OnPropertyChanged("SNILS");
            }
        } 

        public string Speciality
        {
            get => speciality;
            set { speciality = value;
                OnPropertyChanged("Speciality");
            }
        }

        public string Disable
        {
            get => disable;
            set
            {
                disable = value;
                OnPropertyChanged("Disable");
            }
        }

        public string Orphan
        {
            get => orphan;
            set
            {
                orphan = value;
                OnPropertyChanged("Orphan");
            }
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public string Enrollment
        {
            get => enrollment;
            set
            {
                enrollment = value;
                OnPropertyChanged("Enrollment");
            }
        }

        public int Year
        {
            get => year;
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public byte[]? DisableImg
        {
            get => disable_img;
            set 
            { 
                disable_img = value; 
                OnPropertyChanged("DisableImg"); 
            }
        }

        public byte[]? OrphanImg
        {
            get => orphan_img;
            set {
                orphan_img = value;
                OnPropertyChanged("OprhanImg");
            }
        }


        public bool CanCreate => !HasErrors;
        public bool CanSave => !HasErrors;
        public bool HasErrors => _propertyErrors.Any();

        #endregion
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName)){
                _propertyErrors.Add(propertyName, new List<string>());
            }
            _propertyErrors[propertyName].Add(errorMessage);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(CanCreate));
            OnPropertyChanged(nameof(CanSave));

        }

        public void RemoveError(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }
    }
}

