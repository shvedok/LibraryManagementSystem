using LibraryManagementSystem.Entities;
using Xunit;

namespace LibraryManagementSystem.Tests
{
    public class LibraryManagementTests
    {
        private Library library;
        private User user;
        private Book book1, book2;

        public LibraryManagementTests()
        {
            library = Library.Instance; // Singleton instance
            user = new User("Alice");
            library.RegisterUser(user);

            // Use BookBuilder to create books
            book1 = new BookBuilder("The Great Gatsby", "F. Scott Fitzgerald")
            .WithISBN("978-3-16-148410-0")
            .WithPublisher("Scribner")
            .WithYearPublished(1925)
            .WithGenre("Classic")
            .Build();

            book2 = new BookBuilder("1984", "George Orwell")
                .WithISBN("978-0-452-28423-4")
                .Build();


            library.AddBook(book1);
            library.AddBook(book2);
        }

        [Fact]
        public void BookBuilder_CreatesBookWithCorrectAttributes()
        {
            Assert.Equal("The Great Gatsby", book1.Title);
            Assert.Equal("F. Scott Fitzgerald", book1.Author);
            Assert.Equal("978-3-16-148410-0", book1.ISBN);
        }

        [Fact]
        public void Library_IsSingleton()
        {
            var anotherLibraryInstance = Library.Instance;
            Assert.Same(library, anotherLibraryInstance);
        }

        [Fact]
        public void User_CanBorrowBook()
        {
            user.BorrowBook(book1);
            Assert.True(book1.IsBorrowed);
            Assert.Contains(book1, user.BorrowedBooks);
        }

        [Fact]
        public void User_CanReturnBook()
        {
            user.BorrowBook(book1);
            user.ReturnBook(book1);
            Assert.False(book1.IsBorrowed);
            Assert.DoesNotContain(book1, user.BorrowedBooks);
        }

        [Fact]
        public void Library_CanFindBooksByAuthor()
        {
            var booksByOrwell = library.FindBooksByAuthor("George Orwell").ToList();
            Assert.Single(booksByOrwell);
            Assert.Equal("1984", booksByOrwell[0].Title);
        }

        [Fact]
        public void User_CannotBorrowAlreadyBorrowedBook()
        {
            user.BorrowBook(book1);
            var anotherUser = new User("Bob");
            library.RegisterUser(anotherUser);

            Assert.Throws<InvalidOperationException>(() => anotherUser.BorrowBook(book1));
        }
    }
}