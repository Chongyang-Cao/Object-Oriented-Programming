// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Book
{
    private long _ISBN;
    private decimal _Price;
    public string Name { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public long ISBN { get{ return _ISBN; } set { if (Convert.ToString(value).Length == 13) { _ISBN = value; }; } }
    public decimal Price { get{ return _Price; } set { _Price = Math.Truncate(100*value)/100; } }
    public string getName()
    {
        return Name;
    }
    public string getAuthor()
    {
        return Author;
    }
    public string getGenre()
    {
        return Genre;
    }
    public void sale(Book book, decimal price_off)
    {
        decimal original = book.Price;
        book.Price = original - Math.Truncate(100 * price_off) / 100;
    }
}

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.Name = "Mike the Poltergheist";
            book1.Author = "Edward";
            book1.Genre = "Children";
            book1.ISBN = 6533186971011;
            book1.Price = Convert.ToDecimal(3.50);
            Console.WriteLine(book1.getName());
            Console.WriteLine(book1.getAuthor());
            book1.sale(book1, 1);
            Console.WriteLine(book1.Price);
        }
    }
}

