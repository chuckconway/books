namespace books.Model
{
    public class Book
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string AuthorFirstName { get; set; }

        public string AuthorLastName { get; set; }

        public string BookCoverImageUrl { get; set; }

        public string AmazonUrl { get; set; }

        public string Sort { get; set; }

        public byte Type { get; set; }
    }
}
