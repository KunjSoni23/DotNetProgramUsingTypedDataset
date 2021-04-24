/*
    Author: Kunj Soni
    Date of Submission: 5 April 2021
    Title: Assignment 2

    Purpose: With the help of this console application, one can add products in database, 
             also one can fetch the data of produts through category id, product id,
             product name. In this program I used Typed Dataset and I used LocalDB as database source.
 */

using System;

namespace A2KunjSoni
{
    class Program
    {
        static void Main(string[] args)
        {
            CrudOperationsUsingTypedDataSet crud = new CrudOperationsUsingTypedDataSet();

            do
            {
                Console.Clear();
                //menu
                Console.WriteLine("\n\n\t\tASSIGNMENT - 2 by KUNJ SONI\n\n");
                Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");
                Console.WriteLine("\t\t1 - Get all Products");
                Console.WriteLine("\t\t2 - Get Product by Produt ID");
                Console.WriteLine("\t\t3 - Search Products by Name");
                Console.WriteLine("\t\t4 - Get Products by Category ID");
                Console.WriteLine("\t\t5 - Add New Product");
                Console.WriteLine("\t\t6 - Exit\n");

                Console.Write("\nEnter your choice: ");
                int choice;
                bool choiceIsNumeric = Int32.TryParse(Console.ReadLine(),out choice);
                while(!choiceIsNumeric){
                    Console.WriteLine("Invalid Input. Please Try again\n");
                    Console.Write("\nEnter your choice: ");
                    choiceIsNumeric = Int32.TryParse(Console.ReadLine(), out choice);
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        crud.Heading();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        crud.GetAllProducts();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                        break;

                    case 2:

                        Console.Clear();
                        Console.Write("\nEnter Product ID: ");
                        int id;
                        bool idIsNumeric = Int32.TryParse(Console.ReadLine(),out id);
                        while (!idIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again");
                            Console.Write("\nEnter Product ID: ");
                            idIsNumeric = Int32.TryParse(Console.ReadLine(), out id);
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        crud.Heading();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        crud.GetProductByID(id);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("\nEnter Product Name: ");
                        string name = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid Input.Please Try again\n");
                            Console.Write("Enter Product Name: ");
                            name = Console.ReadLine();
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        crud.Heading();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        crud.GetProductByName(name);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        crud.GetAllCategories();
                        Console.Write("\nEnter Category ID: ");
                        int cid;
                        bool cidIsNumeric = Int32.TryParse(Console.ReadLine(), out cid);
                        while (!cidIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again\n");
                            Console.Write("Enter Category ID: ");
                            cidIsNumeric = Int32.TryParse(Console.ReadLine(), out cid);
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        crud.Heading();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        crud.GetProductByCategoryID(cid);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                        break;

                    case 5:    
                        Console.Clear();
                        Console.WriteLine("\nList of Categories: \n");
                        crud.GetAllCategories();
                        Console.Write("\nEnter Category ID: ");
                        cidIsNumeric = Int32.TryParse(Console.ReadLine(), out cid);
                        while (!cidIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again\n");
                            Console.Write("Enter Category ID: ");
                            cidIsNumeric = Int32.TryParse(Console.ReadLine(), out cid);
                        }

                        Console.WriteLine("\nList of Suppliers: \n");
                        crud.GetSuppliers();
                        Console.Write("\nEnter Supplier ID:");
                        int sid;
                        bool sidIsNumeric = Int32.TryParse(Console.ReadLine(), out sid);
                        while (!sidIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again\n");
                            Console.Write("Enter Suppliers ID: ");
                            sidIsNumeric = Int32.TryParse(Console.ReadLine(), out sid);
                        }

                        Console.Write("\nEnter Product Name: ");
                        string pname = Console.ReadLine();
                        while (string.IsNullOrWhiteSpace(pname))
                        {
                            Console.WriteLine("Invalid Input.Please Try again\n");
                            Console.Write("Enter Product Name: ");
                            pname = Console.ReadLine();
                        }

                        Console.Write("\nEnter Unit Price: ");
                        int uprice;
                        bool upriceIsNumeric = Int32.TryParse(Console.ReadLine(), out uprice);
                        while (!upriceIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again\n");
                            Console.Write("Enter Unit Price: ");
                            upriceIsNumeric = Int32.TryParse(Console.ReadLine(), out uprice);
                        }

                        Console.Write("\nEnter Units in Stock: ");
                        short unitsInStock;
                        bool unitsInStockIsNumeric = Int16.TryParse(Console.ReadLine(), out unitsInStock);
                        while (!unitsInStockIsNumeric)
                        {
                            Console.WriteLine("Invalid Input. Please Try again\n");
                            Console.Write("Enter Units in Stock: ");
                            unitsInStockIsNumeric = Int16.TryParse(Console.ReadLine(), out unitsInStock);
                        }

                        crud.InsertProduct(pname,cid,sid,uprice,unitsInStock);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNew Product added Successfully\n");

                        Console.WriteLine("New Product:\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        crud.Heading();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        crud.GetNewInsertedID();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\nPress any key to continue... ");
                        Console.ReadKey();
                        break;

                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice. Please try again!");
                        break;
                }
            } while (true);  
        }
    }
}