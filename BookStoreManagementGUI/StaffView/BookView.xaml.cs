using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using BookStoreManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        private readonly IBookService _bookService;
        private readonly IBookCategoryService _bookCategoryService;

        public BookView()
        {
            InitializeComponent();
            _bookService = new BookService();
            _bookCategoryService = new BookCategoryService();
            LoadData();
        }

        public void LoadData()
        {
            dtgv_BookInfo.UnselectAll();
            cmb_Category.ItemsSource = _bookCategoryService.GetBookCategoryNames();
            _bookService.UpdateStatusByQuantity();

            //Empty data fields
            ClearDataInputField();

            List<BookDTO> books = new List<BookDTO>();
            if (String.IsNullOrEmpty(txt_Search.Text))
            {
                books = _bookService.GetAllBooks();
            }
            else
            {
                //Search by name
                books = _bookService.SearchBooks(txt_Search.Text);
            }

            dtgv_BookInfo.ItemsSource = books;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check input fields
                if (CheckInputField())
                {
                    if (ckb_IsAvailable.IsChecked == false)
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to add unvailable book?", "Add unavailable book", System.Windows.MessageBoxButton.YesNo);
                        if (messageBoxResult == MessageBoxResult.No) return;
                    }

                    if (dtpk_ImportDate.SelectedDate > DateTime.Now)
                    {
                        MessageBox.Show("Import date is invalid ( Import date > today)");
                        return;
                    }
                    AddBook();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddBook()
        {
            BookDTO addBook = new BookDTO
            {
                BookId = 0,
                Name = txt_Name.Text,
                Description = txt_Description.Text,
                ImportDate = (DateTime)dtpk_ImportDate.SelectedDate,
                OriginSource = txt_OriginSource.Text,
                Quantity = int.Parse(txt_Quantity.Text),
                Price = double.Parse(txt_Price.Text),
                IsAvailable = ckb_IsAvailable.IsChecked,
                Category = cmb_Category.SelectedItem.ToString()
            };

            _bookService.AddBook(addBook);
            LoadData();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (dtgv_BookInfo.SelectedItems.Count)
                {
                    case 0:
                        MessageBox.Show("Please Chose Book Category to update");
                        break;
                    case 1:
                        //Check input fields
                        if (CheckInputField())
                        {
                            BookDTO book = (BookDTO)dtgv_BookInfo.SelectedItem;
                            BookDTO addBook = new BookDTO
                            {
                                BookId = book.BookId,
                                Name = txt_Name.Text,
                                Description = txt_Description.Text,
                                ImportDate = (DateTime)dtpk_ImportDate.SelectedDate,
                                OriginSource = txt_OriginSource.Text,
                                Quantity = int.Parse(txt_Quantity.Text),
                                Price = double.Parse(txt_Price.Text),
                                IsAvailable = ckb_IsAvailable.IsChecked,
                                Category = cmb_Category.SelectedItem.ToString()
                            };

                            _bookService.UpdateBook(addBook);
                            LoadData();
                        }
                        break;
                    default:
                        MessageBox.Show("Cannot update multiple book category");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (dtgv_BookInfo.SelectedItems.Count)
            {
                case 0:
                    MessageBox.Show("Please Chose Book Category to update");
                    break;
                case 1:
                    BookDTO book = (BookDTO)dtgv_BookInfo.SelectedItem;

                    _bookService.RemoveBook(book.BookId);
                    LoadData();
                    break;
                default:
                    MessageBox.Show("Cannot update multiple book category");
                    break;
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtgv_BookInfo.UnselectAll();
            //Empty input fields
            ClearDataInputField();
        }

        private void dtgv_BookInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookDTO book = (BookDTO)dtgv_BookInfo.SelectedItem;
            if (book != null)
            {
                //Fill data to input fields
                txt_Name.Text = book.Name;
                txt_Description.Text = book.Description;
                dtpk_ImportDate.SelectedDate = book.ImportDate;
                txt_OriginSource.Text = book.OriginSource;
                txt_Quantity.Text = book.Quantity.ToString();
                txt_Price.Text = book.Price.ToString();
                ckb_IsAvailable.IsChecked = book.IsAvailable;
                cmb_Category.SelectedItem = book.Category;

            }
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ClearDataInputField()
        {
            txt_Name.Text = string.Empty;
            txt_Description.Text = string.Empty;
            dtpk_ImportDate.SelectedDate = DateTime.Now;
            txt_OriginSource.Text = string.Empty;
            txt_Quantity.Text = "0";
            txt_Price.Text = "0";
            ckb_IsAvailable.IsChecked = false;
            cmb_Category.SelectedIndex = 0;
        }

        private bool CheckInputField()
        {
            if (string.IsNullOrEmpty(txt_Name.Text) ||
                string.IsNullOrEmpty(txt_OriginSource.Text) ||
                string.IsNullOrEmpty(txt_Quantity.Text) ||
                string.IsNullOrEmpty(txt_Price.Text))
                throw new Exception("The required input must be filled");

            return true;
        }

        private void txt_Quantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void txt_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }
    }
}
