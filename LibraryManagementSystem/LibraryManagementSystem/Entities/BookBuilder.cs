namespace LibraryManagementSystem.Entities
{
    public class BookBuilder
    {
        public string Title { get; }
        public string Author { get; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public int YearPublished { get; private set; }
        public string Genre { get; private set; }

        public BookBuilder(string title, string author)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
                throw new ArgumentException("Title and Author are mandatory fields.");
            Title = title;
            Author = author;
        }

        public BookBuilder WithISBN(string isbn)
        {
            ISBN = isbn;
            return this;
        }

        public BookBuilder WithPublisher(string publisher)
        {
            Publisher = publisher;
            return this;
        }

        public BookBuilder WithYearPublished(int year)
        {
            YearPublished = year;
            return this;
        }

        public BookBuilder WithGenre(string genre)
        {
            Genre = genre;
            return this;
        }

        public Book Build()
        {
            return new Book(this);
        }
    }
}
