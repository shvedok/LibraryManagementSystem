using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem.Entities
{
    public class User
    {
        public string Name { get; private set; }
        public List<Book> BorrowedBooks { get; private set; } = new();

        public User(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.");
            Name = name;
        }

        public void BorrowBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (BorrowedBooks.Contains(book))
                throw new InvalidOperationException("You have already borrowed this book.");

            book.Borrow();
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (!BorrowedBooks.Contains(book))
                throw new InvalidOperationException("You cannot return a book you haven't borrowed.");

            book.ReturnBook();
            BorrowedBooks.Remove(book);
        }
    }
}