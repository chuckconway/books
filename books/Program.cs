using System;

namespace books
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BooksService();
            //bookService.GetFavoriteBooks();

            //bookService.GetMyNightStandBooks();
            bookService.GetGeneralBooks();

            Console.ReadLine();
        }
    }
}
