

using Northwind_API.Models;

namespace Northwind_API.Repository
{
    public class EmployeeRepo
    {
        private Employee _employee;

        public EmployeeRepo(Employee emp)
        {
            this._employee = emp;
        }

    }
}
