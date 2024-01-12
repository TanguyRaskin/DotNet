using ConsoleAppNorthwindSQL.Models;
using System;



namespace ConsoleAppNorthwindSQL
{
    public class Program
    {

        private static NorthwindContext context = new NorthwindContext();
        private IQueryable<Customer> _listeCustomers;




        public static void Main() {

            IQueryable<Customer> _listeCustomers;
            IQueryable<Product> _listeProduct;


            //B1 afficher les customer d'une ville donne
            /*
            Console.WriteLine("Entrez la ville de votre choix");
            String _ville = Console.ReadLine();

            _listeCustomers = (from c in context.Customers where c.City == _ville select c);


            foreach (Customer c in _listeCustomers)
            {
                Console.WriteLine("{0}",c.ContactName);
            }
            */
            //B2 afficher les produits de la categorie Beverages et Condiments

            Console.WriteLine("Catégorie : Beverages");

            _listeProduct = (from p in context.Products where p.Category.CategoryName == "Beverages" select p);

            foreach (Product p in _listeProduct)
            {
                Console.WriteLine("{0}", p.ProductName);   
            }

            Console.WriteLine("Catégorie : Condiments");

            _listeProduct = (from p in context.Products where p.Category.CategoryName == "Condiments" select p);

            foreach (Product p in _listeProduct)
            {
                Console.WriteLine(p.ProductName);
            }


        }
    }
}