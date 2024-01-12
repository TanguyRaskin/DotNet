using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class OrderModel
    {

        private readonly Order _order;
        private readonly decimal _totalPrice;

        public Order Order { get { return _order; } }
        public OrderModel(Order current, decimal total)
        {
            this._order = current;
            this._totalPrice = total;
        }

        public String OrderId { get { return _order.OrderId.ToString(); } }

        public String OrderDate { get { return _order.OrderDate.ToString();} }

        public String OrderPrice { get { return _totalPrice.ToString(); } }
    }
}
