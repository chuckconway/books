using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using books.Model;
using Dapper;

namespace books
{
    public class BooksService
    {
        public void GetFavoriteBooks()
        {
            const int bookType = 1;
            GetBooks(bookType);
        }

        public void GetGeneralBooks()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                var books = connection.Query<Book>("Select * From Books Where Type = @Type", new { type = 2 }).OrderBy(s => s.Sort);
                var html = books.Aggregate(string.Empty, (current, book) => current + ($"<p><strong>{book.Name}</strong> by <em>{book.Author}</em></p>" + Environment.NewLine));

                Console.WriteLine(html);
            }

            //const int bookType = 2;
            //GetBooks(bookType);
        }

        public void GetMyNightStandBooks()
        {
            const int bookType = 3;
            GetBooks(bookType);
        }

        private static void GetBooks(int bookType)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                var books = connection.Query<Book>("Select * From Books Where Type = @Type", new {type = bookType}).OrderBy(s => s.Sort);
                var html = books.Aggregate(string.Empty, (current, book) => current + ($"<div><a href='{book.AmazonUrl}' title='View {book.Name} on Amazon'><img src='{book.BookCoverImageUrl}' alt='{book.Name} by {book.Author}' /></a></div>" + Environment.NewLine));

                Console.WriteLine(html);
            }
        }
    }
}
