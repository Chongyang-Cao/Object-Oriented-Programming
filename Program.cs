// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

class Book
{
    private long _ISBN;
    private decimal _Price;
    private string Title { get; set; }
    private Person Author { get; set; }
    public string Genre { get; set; }
    public long ISBN { get { return _ISBN; } set { if (Convert.ToString(value).Length == 13) { _ISBN = value; }; } }
    public decimal Price { get { return _Price; } set { _Price = Math.Truncate(100 * value) / 100; } }
    public Book(string _Title, Person _Author, string _Genre, long _ISBN, decimal _Price)
    {
        Title = _Title;
        Author = _Author;
        Genre = _Genre;
        ISBN = _ISBN;
        Price = _Price;
    }
    public string getTitle()
    {
        return Title;
    }
    public string getAuthor()
    {
        return Author.Title + " " + Author.Name;
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
    public class Audiobook : Book
    {
        public Person Reader { get; set; }
        public Audiobook(string _Title, Person _Author, string _Genre, long _ISBN, decimal _Price, Person _Reader) : base(_Title, _Author, _Genre, _ISBN, _Price)
        {
            Reader = _Reader;
        }
        public string getReader()
        {
            return Reader.Title + " " + Reader.Name;
        }
    }
    
}
class Person
{
    public string Name{ get; set; }
    public string Nationality { get; set; }
    public string Title { get; set; }
    public Person(string name, string nationality, string title)
    {
        Name = name;
        Nationality = nationality;
        Title = title;
    }
}


namespace Application
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Book book1 = new Book("Mike the Poltergheist", new Person("Edward Fryer","Dutch", "Mr"), "Children Fiction", 6533186710118, Convert.ToDecimal(3.50));
            Console.WriteLine(book1.getTitle());
            Console.WriteLine(book1.getAuthor());
            Console.WriteLine(book1.ISBN);
            Console.WriteLine(book1.Price);
            book1.sale(book1, 1);
            Console.WriteLine(book1.Price);
            Book Audiobook1 = new Book.Audiobook("Mike the Poltergheist", new Person("Edward Fryer", "Dutch", "Mr"), "Children Fiction", 6533186710118, Convert.ToDecimal(3.50), new Person("Rick Dray", "British", "Mr"));
            
        }
        
    }

}

