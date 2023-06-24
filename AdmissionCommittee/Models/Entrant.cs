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
        private string location;
        private string after_school;
        private int documents;

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

        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged("Location");
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

        public int Documents
        {
            get => documents;
            set
            {
                documents = value;
                OnPropertyChanged("Documents");
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

