using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel
    {
        private readonly Employee _monEmployee;

        /*public Employee MonEmployee
        {
            get { return _monEmployee; }
        }*/

        public EmployeeModel(Employee current)
        {
            this._monEmployee = current;
        }

        public String DisplayBirthDate
        {
            get
            {
                if (this._monEmployee.BirthDate.HasValue)
                    return _monEmployee.BirthDate.Value.ToString();
                return "NA";
            }
        }

        public String DisplayHireDate
        {
            get
            {
                if (this._monEmployee.HireDate.HasValue)
                    return _monEmployee.HireDate.Value.ToString();
                return "NA";
            }
        }
        public String FullName
        {
            get
            {
                return (this._monEmployee.LastName+" "+this._monEmployee.FirstName);
            }
        }

        public String LastName
        {
            get
            {
                return this._monEmployee.LastName;
            }
            set
            {
                this._monEmployee.LastName = value;
            }
        }
        public String FirstName
        {
            get
            {
                return this._monEmployee.FirstName;
            }
            set
            {
                this._monEmployee.FirstName = value;
            }
        }
        public String? TitleOfCourtesy
        {
            get
            {
                return this._monEmployee.TitleOfCourtesy;
            }
            set
            {
                _monEmployee.TitleOfCourtesy = value;
            }
        }

        public DateTime? BirthDate
        {
            get { return _monEmployee.BirthDate; }
            set { _monEmployee.BirthDate = value; }
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set { _monEmployee.HireDate = value; }
        }
    }
}
