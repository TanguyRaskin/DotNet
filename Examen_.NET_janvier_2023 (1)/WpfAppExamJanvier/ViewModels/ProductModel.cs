using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppExamJanvier.Models;

namespace WpfAppExamJanvier.ViewModels
{
    public class ProductModel
    {
        private readonly Product _monProduct;

        public Product MonProduct
        {
            get { return _monProduct; }
        }

        public ProductModel (Product current)
        {
            this._monProduct = current;
        }

        public String ProductId 
        { 
            get { return _monProduct.ProductId.ToString();  }   
        }
        public String ProductName 
        {
            get { return _monProduct.ProductName; }
            set { _monProduct.ProductName = value;  }
        }
        
        public String ProductCategorie
        {
            get { return _monProduct.Category.CategoryName; }
        }

        public String ProductSupplier
        {
            get { return _monProduct.Supplier.ContactName; }
        }
        
    }
}
