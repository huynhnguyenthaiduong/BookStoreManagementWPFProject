using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementService
{
    public interface IBookCategoryService
    {
        public List<BookCategoryDTO> GetAllBookCategory();
        public void CreateBookCategory(BookCategoryDTO newBookCategory);
        public void UpdateBookCategory(BookCategoryDTO updatedBookCategory);
        public void DeleteBookCategory(int id);
        public List<BookCategoryDTO> SearchBookCategory(string keyword);
        public List<string> GetBookCategoryNames();
    }
}
