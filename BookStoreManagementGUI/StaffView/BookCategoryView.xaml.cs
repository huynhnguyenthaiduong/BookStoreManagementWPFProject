using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using BookStoreManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreManagementGUI.StaffView
{
    /// <summary>
    /// Interaction logic for BookCategoryView.xaml
    /// </summary>
    public partial class BookCategoryView : UserControl
    {
        private readonly IBookCategoryService _bookCategoryService = null;

        public BookCategoryView()
        {
            InitializeComponent();
            _bookCategoryService = new BookCategoryService();
            LoadData();
        }

        public void LoadData()
        {
            dtgv_BookCategoryInfo.UnselectAll();
            txt_Name.Text = string.Empty;

            List<BookCategoryDTO> bookCategories = new List<BookCategoryDTO>();
            if (String.IsNullOrEmpty(txt_Search.Text))
            {
                bookCategories = _bookCategoryService.GetAllBookCategory();
                dtgv_BookCategoryInfo.ItemsSource = bookCategories;
            }
            else
            {
                bookCategories = _bookCategoryService.SearchBookCategory(txt_Search.Text);
            }

            dtgv_BookCategoryInfo.ItemsSource = bookCategories;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("Category Name is required.");
            }
            else
            {
                BookCategoryDTO bookCategory = new BookCategoryDTO
                {
                    CategoryId = 0,
                    CategoryName = txt_Name.Text,
                };

                _bookCategoryService.CreateBookCategory(bookCategory);
                LoadData();
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            switch (dtgv_BookCategoryInfo.SelectedItems.Count)
            {
                case 0:
                    MessageBox.Show("Please Chose Book Category to update");
                    break;
                case 1:
                    if (string.IsNullOrEmpty(txt_Name.Text))
                    {
                        MessageBox.Show("Category Name is required.");
                    }
                    else
                    {
                        BookCategoryDTO category = (BookCategoryDTO)dtgv_BookCategoryInfo.SelectedItem;
                        BookCategoryDTO updatedCategory = new BookCategoryDTO
                        {
                            CategoryId = category.CategoryId,
                            CategoryName = txt_Name.Text,
                        };

                        _bookCategoryService.UpdateBookCategory(updatedCategory);
                        LoadData();
                    }
                    break;
                default:
                    MessageBox.Show("Cannot update multiple book category");
                    break;
            }
        }

        private void dtgv_BookCategoryInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookCategoryDTO category = (BookCategoryDTO)dtgv_BookCategoryInfo.SelectedItem;
            if (category != null)
                txt_Name.Text = category.CategoryName.ToString();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (dtgv_BookCategoryInfo.SelectedItems.Count)
            {
                case 0:
                    MessageBox.Show("Please Chose Book Category to update");
                    break;
                case 1:
                    BookCategoryDTO category = (BookCategoryDTO)dtgv_BookCategoryInfo.SelectedItem;

                    _bookCategoryService.DeleteBookCategory(category.CategoryId);
                    LoadData();
                    break;
                default:
                    MessageBox.Show("Cannot update multiple book category");
                    break;
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtgv_BookCategoryInfo.UnselectAll();
            txt_Name.Text = String.Empty;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
