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
        static void Define(Book book, string _Name, string _Author, string _Genre, long _ISBN, decimal _Price)
        {
            book.Name = _Name;
            book.Author = _Author;
            book.Genre = _Genre;
            book.ISBN = _ISBN;
            book.Price = _Price;
        }
        static void Main(string[] args)
        {
            Book book1 = new Book();
            Program.Define(book1, "Mike the Poltergheist", "Edward", "Children Fiction", 6533186710118, Convert.ToDecimal(3.50)) ;
            Console.WriteLine(book1.getName());
            Console.WriteLine(book1.getAuthor());
            Console.WriteLine(book1.ISBN);
            book1.sale(book1, 1);
            Console.WriteLine(book1.Price);
        }
        
    }

}

