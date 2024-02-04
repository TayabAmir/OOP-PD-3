using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class Book
    {
        public string title;
        public string author;
        public string pubYear;
        public string price;
        public int quantityinStock;
        public Book(string title,string author,string pubYear,string price) 
        {
            this.title = title;
            this.author = author;
            this.pubYear = pubYear;
            this.price = price;
        }

        public string getTitle()
        {
            return "Title: "+title + "\n";
        }
        public string getAuthor()
        {
            return "Author: " + author + "\n";
        }
        public string getPublicationYear()
        {
            return "Publication Year: "+pubYear + "\n";
        }
        public string getPrice()
        {
            return "Price: " + price + "\n";
        }
        public void sellCopies(int numberOfCopies)
        {
            if(numberOfCopies < quantityinStock)
            {
                quantityinStock -= numberOfCopies;
            }
            else
            {
                Console.WriteLine("Number of copies cannot be greater than stock quantity");
            }
        }
        public int restock(int additionalCopies)
        {
                return additionalCopies+quantityinStock;
        }
        public string bookDetails()
        {
            return title + author + pubYear + price + quantityinStock.ToString(); 
        }

    }
}   
