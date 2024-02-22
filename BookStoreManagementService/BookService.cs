using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using BookStoreManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository = null;

        public BookService()
        {
            if (_bookRepository == null)
                _bookRepository = new BookRepository();
        }
        public List<BookDTO> GetAllBooks() => _bookRepository.GetAllBooks();
        public void AddBook(BookDTO newBook) => _bookRepository.AddBook(newBook);
        public void UpdateBook(BookDTO updatedBook) => _bookRepository.UpdateBook(updatedBook);    
        public void RemoveBook(int bookId) => _bookRepository.RemoveBook(bookId);
        public List<BookDTO> SearchBooks(string searchValue) => _bookRepository.SearchBooks(searchValue);
        public void UpdateStatusByQuantity() => _bookRepository.UpdateStatusByQuantity();
    }
}
