using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.ViewModels;
using WpfEmployee.Models;
using System.Windows;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {
        NorthwindContext dc = new NorthwindContext();

        private EmployeeModel _SelectedEmployee;
        private ObservableCollection<EmployeeModel> _EmployeeList;
        private List<String> _TitleOfCourtesyList;

        private ObservableCollection<OrderModel> _OrderList;

        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get 
            {
                if (_EmployeeList == null)
                    _EmployeeList = loadEmployeeList();
                return _EmployeeList;
            }
        }

        private ObservableCollection<EmployeeModel> loadEmployeeList ()
        {
            ObservableCollection<EmployeeModel> localList = new ObservableCollection<EmployeeModel>();
            foreach(var e in dc.Employees)
            {
                localList.Add(new EmployeeModel(e));
            }
            return localList;
        }

        public ObservableCollection<OrderModel> OrdersList
        {
            get 
            {
                if (SelectedEmployee != null)
                    _OrderList = loadOrderList();
                return _OrderList; 
            }
        }

        private ObservableCollection<OrderModel> loadOrderList()
        {
            ObservableCollection<OrderModel> localList = new ObservableCollection<OrderModel>();
            var query = from Order o in dc.Orders
                        where (o.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId)
                        orderby o.OrderDate descending
                        select o;
            int i = 0;
            foreach (var order in query)
            {
                var total = dc.OrderDetails.Where(od => od.OrderId == order.OrderId).Sum(od => od.UnitPrice);
                            
                localList.Add(new OrderModel(order, total));
                i++;
                if(i == 3)
                    break;
            }
            return localList;
        }

        public List<String> ListTitle
        {
            get
            {
                if (_TitleOfCourtesyList == null)
                    _TitleOfCourtesyList = loadTitleOfCourtesyList();
                return _TitleOfCourtesyList;
            }
        }

        private List<String> loadTitleOfCourtesyList()
        {
            return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList(); 
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _SelectedEmployee; }
            set { _SelectedEmployee = value; OnPropertyChanged("OrdersList"); }
        }

        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddEmployee);
            }
        }

        private void AddEmployee()
        {
            Employee newEmployee = new Employee();
            EmployeeModel employeeModel = new EmployeeModel(newEmployee);
            EmployeesList.Add(employeeModel);

            SelectedEmployee = employeeModel;
            MessageBox.Show(SelectedEmployee.FullName);
            OnPropertyChanged("FullName");
            OnPropertyChanged("DisplayBirthDate");
        }
        

        public DelegateCommand SaveCommand
        {
            get
            {
                return _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee);
            }
        }

        private void SaveEmployee()
        {
            Employee verif = dc.Employees.Where(e => e.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId).SingleOrDefault();
            if (verif == null)
            {
                dc.Employees.Add(_SelectedEmployee.MonEmployee);
            }
            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
           
            


        }




    }
}
