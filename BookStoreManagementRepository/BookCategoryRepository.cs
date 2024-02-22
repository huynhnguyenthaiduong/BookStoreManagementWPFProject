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
    public class BookCategoryRepository : IBookCategoryRepository
    {
        public List<BookCategoryDTO> GetAllBookCategory() => BookCategoryDAO.Instance.GetAllBookCategory();
        public void CreateBookCategory(BookCategoryDTO newBookCategory) => BookCategoryDAO.Instance.CreateBookCategory(newBookCategory);
        public void UpdateBookCategory(BookCategoryDTO updatedBookCategory) => BookCategoryDAO.Instance.UpdateBookCategory(updatedBookCategory);
        public void DeleteBookCategory(int id) => BookCategoryDAO.Instance.DeleteBookCategory(id);
        public List<BookCategoryDTO> SearchBookCategory(string keyword) => BookCategoryDAO.Instance.SearchBookCategory(keyword);
        public List<string> GetBookCategoryNames() => BookCategoryDAO.Instance.GetBookCategoryNames();
    }
}
