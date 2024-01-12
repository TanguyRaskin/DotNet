﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel : INotifyPropertyChanged
    {   
        private readonly Employee _employee;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Employee MonEmployee { get { return _employee; } }
        public EmployeeModel(Employee current)
        {
            this._employee = current;
        }
        public String FirstName 
        { 
            get { return _employee.FirstName; }
            set { _employee.FirstName = value; OnPropertyChanged("FullName"); } 
        }
        public String LastName 
        { 
            get { return _employee.LastName; }
            set { _employee.LastName = value; OnPropertyChanged("FullName"); }
        }
        public DateTime? BirthDate 
        {   
            get { return _employee.BirthDate; }
            set { _employee.BirthDate = value; OnPropertyChanged("DisplayName");  }
        }
        public DateTime? HireDate 
        {
            get { return _employee.HireDate; }
            set { _employee.HireDate = value;}
        }
        public String? TitleOfCourtesy 
        { 
            get { return _employee.TitleOfCourtesy; } 
            set { _employee.TitleOfCourtesy = value; } 
        }

        public String FullName
        {
            get { return String.Format("{0} {1}", _employee.FirstName, _employee.LastName).Trim(); }
        }
        public String DisplayBirthDate
        {
            get 
            { 
                if(_employee.BirthDate.HasValue)
                    return _employee.BirthDate.Value.ToString();
                return "";
            }
        }
        
    }
}
