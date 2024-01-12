using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM
    {
        private NorthwindContext dc = new NorthwindContext();
        private List<EmployeeModel> _employeesList;
        private List<String> _listTitle;

        public List<EmployeeModel> EmployeesList
        {
            get { return _employeesList = _employeesList ?? LoadEmployee(); }
        }

        private List<EmployeeModel> LoadEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach(var item in dc.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }

        public List<String> ListTitle
        {
            get { return _listTitle = _listTitle ?? LoadTitreOfCourtesy(); }
        }

        private List<String> LoadTitreOfCourtesy()
        {
            return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }


    }
}
