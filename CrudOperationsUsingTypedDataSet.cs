/*
    Author: Kunj Soni
    Date of Submission: 5 April 2021
    Title: Assignment 2

    Purpose: With the help of this console application, one can add products in database, 
             also one can fetch the data of produts through category id, product id,
             product name. In this program I used Typed Dataset and I used LocalDB as database source.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace A2KunjSoni
{
    class CrudOperationsUsingTypedDataSet
    {
        //instance for Dataset file
        private NorthwindDatasetTableAdapters.ProductsTableAdapter _adpProducts;
        private NorthwindDataset.ProductsDataTable _tblProducts;

        private NorthwindDatasetTableAdapters.CategoriesTableAdapter _adpCategories;
        private NorthwindDataset.CategoriesDataTable _tblCategories;

        private NorthwindDatasetTableAdapters.Products1TableAdapter _adpProd1;
        private NorthwindDataset.Products1DataTable _tblProd1;

        private NorthwindDatasetTableAdapters.SuppliersTableAdapter _adpSuppliers;
        private NorthwindDataset.SuppliersDataTable _tblSuppliers;

        //constructor
        internal CrudOperationsUsingTypedDataSet()
        {
            _adpProducts = new NorthwindDatasetTableAdapters.ProductsTableAdapter();
            _tblProducts = new NorthwindDataset.ProductsDataTable();
            _adpCategories = new NorthwindDatasetTableAdapters.CategoriesTableAdapter();
            _tblCategories = new NorthwindDataset.CategoriesDataTable();
            _adpProd1 = new NorthwindDatasetTableAdapters.Products1TableAdapter();
            _tblProd1 = new NorthwindDataset.Products1DataTable();
            _adpSuppliers = new NorthwindDatasetTableAdapters.SuppliersTableAdapter();
            _tblSuppliers = new NorthwindDataset.SuppliersDataTable();
        }

        //Heading for every output
        internal void Heading()
        {
            Console.WriteLine($"{"ProductID",10} | {"ProductName",-40} | {"CategoryName",-25} | {"CompanyName",-40} | {"UnitPrice",10} | {"UnitsInStock",10}\n");
        }

        //method to get all products from Northwind Database
        internal void GetAllProducts()
        {
            //Get Method
            _tblProducts = _adpProducts.GetProducts();

            foreach (var row in _tblProducts)
            {
                Console.WriteLine($"{row.ProductID,10} | {row.ProductName,-40} | {row.CategoryName,-25} | {row.CompanyName,-40} | {row.UnitPrice.ToString("C"),10} | {row.UnitsInStock,10}");
            }
        }

        //method to get all products by ID
        internal void GetProductByID(int id)
        {
            _tblProducts = _adpProducts.GetProducts();

            var row = _tblProducts.FindByProductID(id);

            if (row != null)
            {
                Console.WriteLine($"{row.ProductID,10} | {row.ProductName,-40} | {row.CategoryName,-25} | {row.CompanyName,-40} | {row.UnitPrice.ToString("C"),10} | {row.UnitsInStock,10}");

            }
            else
            {
                Console.WriteLine("Invalid Product ID. Please try again!");
            }
        }


        //method to get all the product by name
        internal void GetProductByName(string name)
        {
            _tblProducts = _adpProducts.GetDataByProductName(name);

            if (_tblProducts.Count > 0)
            {
                foreach (var row in _tblProducts)
                {
                    Console.WriteLine($"{row.ProductID,10} | {row.ProductName,-40} | {row.CategoryName,-25} | {row.CompanyName,-40} | {row.UnitPrice.ToString("C"),10} | {row.UnitsInStock,10}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product Name. Please try again!");
            }
        }

        //method to get all categories
        internal void GetAllCategories()
        {
            _tblCategories = _adpCategories.GetCategories();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"CategoryID",12} | {"CategoryName",-25}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var row in _tblCategories)
            {
                Console.WriteLine($"{row.CategoryID,12} | {row.CategoryName,-25}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        //method to get products by categoryID
        internal void GetProductByCategoryID(int id)
        {
            _tblProducts = _adpProducts.GetProductsByCategoryID(id);

            if (_tblProducts.Count > 0)
            {
                foreach (var row in _tblProducts)
                {
                    Console.WriteLine($"{row.ProductID,10} | {row.ProductName,-40} | {row.CategoryName,-25} | {row.CompanyName,-40} | {row.UnitPrice.ToString("C"),10} | {row.UnitsInStock,10}");
                }
            }
            else
            {
                Console.WriteLine("Invalid Category ID. Please try again!");
            }

        }

        //method to get all suppliers
        internal void GetSuppliers()
        {
            _tblSuppliers = _adpSuppliers.GetSuppliers();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{"SupplierID",12} | {"CompanyName",-25}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var row in _tblSuppliers)
            {
                Console.WriteLine($"{row.SupplierID,12} | {row.CompanyName,-25}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //method to insert all suppliers
        internal void InsertProduct(string productName, int categoryID, int supplierID, int unitPrice, short unitsInStock)
        {
            _adpProd1.Insert(productName, categoryID, supplierID, unitPrice, unitsInStock);
        }

        //method to get latest id
        internal void GetNewInsertedID()
        {
            _tblProducts = _adpProducts.GetLatestID();

            if (_tblProducts.Count > 0)
            {
                foreach (var row in _tblProducts)
                {
                    Console.WriteLine($"{row.ProductID,10} | {row.ProductName,-40} | {row.CategoryName,-25} | {row.CompanyName,-40} | {row.UnitPrice.ToString("C"),10} | {row.UnitsInStock,10}");

                }
            }
            else
            {
                Console.WriteLine("Need to Insert Data Again!");
            }
        }

    }
}
