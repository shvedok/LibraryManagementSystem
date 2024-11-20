using System;
using System.Collections.Generic;
using System.Linq;


namespace LibraryManagementSystem.Entities
{
    public class Library
    {
        private static Library instance;
        private readonly List<Book> books = new();
        private readonly List<User> users = new();

        private Library() { }

        public static Library Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        public void AddBook(Book book)
        {
            if (!books.Any(b => b.ISBN == book.ISBN))
            {
                books.Add(book);
            }
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public List<Book> FindBooksByTitle(string title)
        {
            return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> FindBooksByAuthor(string author)
        {
            return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void RegisterUser(User user)
        {
            if (!users.Any(u => u.Name == user.Name))
            {
                users.Add(user);
            }
        }
    }
}