using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTraining.ViewModels
{
    internal class EmployeeVM
    {
        private List<EmployeeModel> _listEmployees;

        private EmployeeModel context = new EmployeeModel();

        public List<EmployeeModel> EmployeesList
        {
            get { return _listEmployees = _listEmployees ?? LoadListEmployee(); }
        }


        private List<EmployeeModel> LoadListEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            
            foreach(var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }

            return localCollection;
        }
    }
}
