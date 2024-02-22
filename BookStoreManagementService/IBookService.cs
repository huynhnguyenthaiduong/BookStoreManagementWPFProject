using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementService
{
    public interface IBookService
    {
        public List<BookDTO> GetAllBooks();
        public void AddBook(BookDTO newBook);
        public void UpdateBook(BookDTO updatedBook);
        public void RemoveBook(int bookId);
        public List<BookDTO> SearchBooks(string searchValue);
        public void UpdateStatusByQuantity();
    }
}
