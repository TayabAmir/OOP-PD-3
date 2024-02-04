using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            List<Book> books = new List<Book>();
            do
            {
                Console.Clear();
                Console.WriteLine("1.Add book");
                Console.WriteLine("2.View All the books infomation");
                Console.WriteLine("3.Get the author details of a specific book.");
                Console.WriteLine("4.Sell copies of a specific book");
                Console.WriteLine("5.Restock a specific book");
                Console.WriteLine("6.See the count of the Books present in your bookList.");
                Console.WriteLine("Choose the option....");
                opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    Console.WriteLine("Enter the name of book: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the author of book: ");
                    string author = Console.ReadLine();
                    Console.WriteLine("Enter the publication year of book: ");
                    string pubYear = Console.ReadLine();
                    Console.WriteLine("Enter the price of book: ");
                    string price = Console.ReadLine();
                    Book obj = new Book(title,author,pubYear,price);
                    books.Add(obj);
                }
                else if(opt==2)
                {
                    for(int i = 0;i<books.Count;i++)
                        Console.WriteLine(books[i].getTitle() + books[i].getAuthor() + books[i].getPublicationYear() + books[i].getPrice() + "Quantity: " +books[i].quantityinStock + "\n \n");
                }
                else if(opt==3)
                {
                    Console.WriteLine("Enter the title of book: ");
                    string book = Console.ReadLine();
                    for(int i=0;i<books.Count;i++)
                    {
                        if (books[i].title == book)
                        {
                            Console.WriteLine("Author of the " + book + " is: " + books[i].author);
                            break;
                        }
                    }
                }
                else if(opt==4)
                {
                    Console.WriteLine("Enter the title of book: ");
                    string book = Console.ReadLine();
                    Console.WriteLine("Enter the number of copies to sell: ");
                    int copies = int.Parse(Console.ReadLine());
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].title == book)
                        {
                            books[i].sellCopies(copies);
                            break;
                        }
                    }
                    Console.WriteLine("Invalid Title");
                }
                else if (opt == 5)
                {
                    Console.WriteLine("Enter the title of book: ");
                    string book = Console.ReadLine();
                    Console.WriteLine("Enter the number of copies to add: ");
                    int copies = int.Parse(Console.ReadLine());
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].title == book)
                        {
                            books[i].restock(copies);
                            break;
                        }
                    }
                    Console.WriteLine("Invalid Title");
                }
                else if(opt==6)
                {
                    Console.WriteLine("Total number of books: " + books.Count);
                }
                Console.ReadKey();
            } while (opt != 0);
        }
    }
}
