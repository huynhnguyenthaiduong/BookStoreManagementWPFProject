using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementDAO
{
    public class BookCategoryDAO
    {
        private readonly BookStoreManagementDBContext _dbContext = null;

        private static BookCategoryDAO instance = null;
        public static BookCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookCategoryDAO();
                }
                return instance;
            }
        }

        public BookCategoryDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new BookStoreManagementDBContext();
            }
        }

        public List<BookCategoryDTO> GetAllBookCategory()
        {
            return _dbContext.BookCategories.Select(bc => new BookCategoryDTO
            {
                CategoryId = bc.CategoryId,
                CategoryName = bc.CategoryName,
            }).ToList();
        }

        public List<BookCategoryDTO> SearchBookCategory(string keyword)
        {
            return _dbContext.BookCategories.Select(bc => new BookCategoryDTO
            {
                CategoryId = bc.CategoryId,
                CategoryName = bc.CategoryName,
            }).Where(bc => bc.CategoryName.Contains(keyword)).ToList();
        }

        public void CreateBookCategory(BookCategoryDTO newBookCategory)
        {
            BookCategory category = _dbContext.BookCategories.Where(bc => bc.CategoryName.Equals(newBookCategory.CategoryName)).FirstOrDefault();

            if (category == null)
            {
                BookCategory createdCategory = new BookCategory
                {
                    CategoryId = newBookCategory.CategoryId,
                    CategoryName = newBookCategory.CategoryName,
                };

                _dbContext.BookCategories.Add(createdCategory);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateBookCategory(BookCategoryDTO updatedBookCategory)
        {
            BookCategory bookCategory = _dbContext.BookCategories.FirstOrDefault(x => x.CategoryId == updatedBookCategory.CategoryId);

            if (bookCategory != null)
            {
                BookCategory updatedCategory = new BookCategory
                {
                    CategoryId = updatedBookCategory.CategoryId,
                    CategoryName = updatedBookCategory.CategoryName,
                };

                _dbContext.Entry<BookCategory>(bookCategory).CurrentValues.SetValues(updatedCategory);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteBookCategory(int id)
        {
            BookCategory bookCategory = _dbContext.BookCategories.FirstOrDefault(x => x.CategoryId == id);

            if (bookCategory != null)
            {
                _dbContext.Remove(bookCategory);
                _dbContext.SaveChanges();
            }
        }

        public int GetBookCategoryId(string categoryName)
        {
            BookCategory bookCategory = _dbContext.BookCategories.FirstOrDefault(bc => bc.CategoryName == categoryName);
            if (bookCategory != null)
            {
                return bookCategory.CategoryId;
            }
            return 0;
        }

        public List<string> GetBookCategoryNames()
        {
            List<string> categoryName = _dbContext.BookCategories.Select(x => x.CategoryName).ToList();
            return categoryName;
        }
    }
}
