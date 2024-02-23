using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementDAO
{
    public class BookDAO
    {
        private readonly BookStoreManagementDBContext _dbContext = null;

        private static BookDAO instance = null;
        public static BookDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookDAO();
                }
                return instance;
            }
        }

        public BookDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new BookStoreManagementDBContext();
            }
        }

        public List<BookDTO> GetAllBooks()
        {
            return _dbContext.Books.Select(b => new BookDTO
            {
                BookId = b.BookId,
                Name = b.Name,
                Description = b.Description,
                ImportDate = b.ImportDate,
                OriginSource = b.OriginSource,
                Quantity = b.Quantity,
                Price = b.Price,
                IsAvailable = b.IsAvailable,
                Category = b.Category.CategoryName
            }).ToList();
        }

        public List<BookDTO> SearchBooks(string searchValue)
        {
            return _dbContext.Books.Select(b => new BookDTO
            {
                BookId = b.BookId,
                Name = b.Name,
                Description = b.Description,
                ImportDate = b.ImportDate,
                OriginSource = b.OriginSource,
                Quantity = b.Quantity,
                Price = b.Price,
                IsAvailable = b.IsAvailable,
                Category = b.Category.CategoryName
            }).Where(b => b.Name.Contains(searchValue)).ToList();
        }

        public void AddBook(BookDTO newBook)
        {
            Book book = _dbContext.Books.FirstOrDefault(b => b.Name == newBook.Name);

            if (book == null)
            {
                int categoryId = BookCategoryDAO.Instance.GetBookCategoryId(newBook.Category);

                if (categoryId > 0)
                {
                    Book addBook = new Book
                    {
                        BookId = 0,
                        Name = newBook.Name,
                        Description = newBook.Description,
                        ImportDate = newBook.ImportDate,
                        OriginSource = newBook.OriginSource,
                        Quantity = newBook.Quantity,
                        Price = newBook.Price,
                        IsAvailable = newBook.IsAvailable,
                        CategoryId = categoryId
                    };
                    _dbContext.Books.Add(addBook);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Invalid Category");
                }
            }
            else
            {
                throw new Exception("Book Name has already used");
            }
        }

        public void RemoveBook(int bookId)
        {
            Book book = _dbContext.Books.FirstOrDefault(b => b.BookId == bookId && b.IsAvailable == true);

            if (book != null)
            {
                book.IsAvailable = false;
                _dbContext.Books.Update(book);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateBook(BookDTO updatedBook)
        {
            Book book = _dbContext.Books.FirstOrDefault(b => b.BookId == updatedBook.BookId);

            if (book != null)
            {
                int categoryId = BookCategoryDAO.Instance.GetBookCategoryId(updatedBook.Category);

                if (categoryId > 0)
                {
                    Book addBook = new Book
                    {
                        BookId = updatedBook.BookId,
                        Name = updatedBook.Name,
                        Description = updatedBook.Description,
                        ImportDate = updatedBook.ImportDate,
                        OriginSource = updatedBook.OriginSource,
                        Quantity = updatedBook.Quantity,
                        Price = updatedBook.Price,
                        IsAvailable = updatedBook.IsAvailable,
                        CategoryId = categoryId
                    };
                    _dbContext.Entry<Book>(book).CurrentValues.SetValues(addBook);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Invalid Category");
                }
            }
            else { throw new Exception("Book is not existed"); }
        }

        public void UpdateStatusByQuantity()
        {
            List<Book> books = _dbContext.Books.ToList();

            foreach (Book book in books)
            {
                if (book.Quantity == 0 && book.IsAvailable == true)
                {
                    _dbContext.Entry(book).Property("IsAvailable").CurrentValue = false;
                    _dbContext.SaveChanges();
                }
            }
        }
    }
}
