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
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _bookCategoryRepository = null;

        public BookCategoryService()
        {
            if (_bookCategoryRepository == null)
                _bookCategoryRepository = new BookCategoryRepository();
        }

        public List<BookCategoryDTO> GetAllBookCategory() => _bookCategoryRepository.GetAllBookCategory();
        public void CreateBookCategory(BookCategoryDTO newBookCategory) => _bookCategoryRepository.CreateBookCategory(newBookCategory);
        public void UpdateBookCategory(BookCategoryDTO updatedBookCategory) => _bookCategoryRepository.UpdateBookCategory(updatedBookCategory);
        public void DeleteBookCategory(int id) => _bookCategoryRepository.DeleteBookCategory(id);
        public List<BookCategoryDTO> SearchBookCategory(string keyword) => _bookCategoryRepository.SearchBookCategory(keyword);
        public List<string> GetBookCategoryNames() => _bookCategoryRepository.GetBookCategoryNames();
    }
}
