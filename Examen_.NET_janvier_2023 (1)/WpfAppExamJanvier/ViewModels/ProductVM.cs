using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppExamJanvier.Models;

namespace WpfAppExamJanvier.ViewModels
{
    public class ProductVM
    {
        NorthwindContext dc = new NorthwindContext();

        private ProductModel _selectedProduct;
        private ObservableCollection<ProductModel> _ProductsList;

        private DelegateCommand _abandonCommand;

        private List<dynamic> _ProductsSoldByCountry;


        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; }
        }
        public ObservableCollection<ProductModel> ListProduct 
        {
            get
            {
                if (_ProductsList == null)
                    _ProductsList = loadProductList();
                return _ProductsList;
            }
        }
        private ObservableCollection<ProductModel> loadProductList()
        {
            ObservableCollection<ProductModel> localList = new ObservableCollection<ProductModel>();
            var query = dc.Products.Where(p => p.Discontinued == false).ToList();

            foreach(var product in query)
            {
                localList.Add(new ProductModel(product));
            }
            return localList;
        }

        public DelegateCommand Abandon
        {
            get
            {
                return _abandonCommand = _abandonCommand ?? new DelegateCommand(AbandonDelegate);
            }

        }
        public void AbandonDelegate()
        {
            Product prod = dc.Products.Where(p => p.ProductId == SelectedProduct.MonProduct.ProductId).SingleOrDefault();
            if(prod != null)
            {
                prod.Discontinued = true;
                dc.Products.Update(prod);
                dc.SaveChanges();
                ListProduct.Remove(SelectedProduct);
                MessageBox.Show("Update en base de données faite");
            }
                
        }

        public void CountryCount()
        {

        }

        public List<dynamic> ProductsSoldByCountry
        {
            get
            {
                if (_ProductsSoldByCountry == null)
                {
                    _ProductsSoldByCountry = loadProductsSoldByCountry();
                }

                return _ProductsSoldByCountry;
            }
        }

        private List<dynamic> loadProductsSoldByCountry()
        {
            List<dynamic> localCollection = dc.OrderDetails
                .Where(od => od.Quantity > 0) // Filtrer les lignes de commande avec au moins une vente
                .Select(od => new { od.Product.Supplier.Country, od.Product.ProductName })
                .GroupBy(p => p.Country)
                .Select(g => new
                {
                    Country = g.Key,
                    ProductCount = g.Select(p => p.ProductName).Distinct().Count()
                })
                .OrderByDescending(p => p.ProductCount)
                .ToList<dynamic>();

            return localCollection;
        }

    }
}
