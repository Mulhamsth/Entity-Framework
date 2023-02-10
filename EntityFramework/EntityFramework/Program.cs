using BookLibrary;
using Messages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFramework
{
    internal class Program
    {
        static IEnumerable<Author> CreateFakeData()
        {
            var authors = new List<Author>
            {
                new Author
                {
                    Name = "Jane Austen", Books = new List<Book>
                    {
                        new Book{Title = "Emma", YearOfPublication = 1815},
                        new Book{Title = "Persuasion", YearOfPublication = 1818},
                        new Book{Title = "Mansfield Park", YearOfPublication = 1814}
                    }
                },
                new Author
                {
                    Name = "Ian Fleming", Books = new List<Book>
                    {
                        new Book{Title = "Dr No", YearOfPublication = 1958},
                        new Book{Title = "Goldfinger", YearOfPublication = 1959},
                        new Book{Title = "From Russia with Love", YearOfPublication = 1957}
                    }
                }
            };
            return authors;
        }
        static IEnumerable<MessagesBT> MessagesData()
        {
            var messages = new List<MessagesBT>
            {
                new MessagesBT{Id = 1, Text = "This is a test message" },
                new GlobalMessages{Id = 2, Text = "This should be a Global message"},
                new DirectMessages{Id = 3, Text = "This should be a Direct message"}
            };
            return messages;
        }
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<MessageContext>()
                .UseSqlite("Filename=../../../MessagesDB.db")
                .Options;

            using var db = new MessageContext(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var messages = MessagesData();
            db.AddRange(messages);
            db.SaveChanges();

            //using var db = new BookContext(options);

            //db.Database.EnsureCreated();

            ////var authors = CreateFakeData();

            ////db.AddRange(authors);
            ////db.SaveChanges();

            //var recentBooks = from b in db.Books where b.YearOfPublication > 1900 select b;

            //foreach (var book in recentBooks.Include(b => b.Author))
            //{
            //    Console.WriteLine($"{book} is by {book.Author}");
            //}
        }
    }
}