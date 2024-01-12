using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTraining.Models;

namespace WpfAppTraining.ViewModels
{
    class EmployeeModel : DbContext
    {

        private readonly Employee _employee;

        public EmployeeModel()
        {
        }

        public EmployeeModel(Employee employee)
        {
            _employee = employee;
        }


        public virtual DbSet<Employee> Employees { get; set; } = null!;


        public int Id {
            get { return _employee.EmployeeId; }
        }

       public string Name {
            get { return _employee.FirstName; }
        }

        public DateTime Birthdate { get; }
    }
}
