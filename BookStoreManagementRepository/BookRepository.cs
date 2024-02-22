using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using BookStoreManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementRepository
{
    public class BookRepository : IBookRepository
    {
        public List<BookDTO> GetAllBooks() => BookDAO.Instance.GetAllBooks();
        public void AddBook(BookDTO newBook) => BookDAO.Instance.AddBook(newBook);
        public void UpdateBook(BookDTO updatedBook) => BookDAO.Instance.UpdateBook(updatedBook);
        public void RemoveBook(int bookId) => BookDAO.Instance.RemoveBook(bookId);
        public List<BookDTO> SearchBooks(string searchValue) => BookDAO.Instance.SearchBooks(searchValue);
        public void UpdateStatusByQuantity() => BookDAO.Instance.UpdateStatusByQuantity();
    }
}
