using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCommittee.Models
{
    public class Entrant: INotifyPropertyChanged
    {
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

        #region Fields
        public string FirstName
        {
            get => first_name;
            set
            {
                first_name = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => last_name;
            set
            {
                last_name = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set{ 
                patronymic = value; 
                OnPropertyChanged("Patronymic");
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
                date_of_birth = value;
                OnPropertyChanged("DateOfBirth");
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
                grade_average = value;
                OnPropertyChanged("GradeAverage");
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
            set { citezenshipdiff = value;
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

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}

