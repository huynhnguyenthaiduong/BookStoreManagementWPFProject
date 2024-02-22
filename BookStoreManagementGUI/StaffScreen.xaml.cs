using BookStoreManagementBO;
using BookStoreManagementGUI.AdminView;
using BookStoreManagementGUI.StaffView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFStudentMangementGUI;

namespace BookStoreManagementGUI
{
    /// <summary>
    /// Interaction logic for StaffScreen.xaml
    /// </summary>
    public partial class StaffScreen : Window
    {
        private UserControl currentPage;
        public UserControl CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        private Account userAcc;

        public StaffScreen(Account account)
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            rbtn_Book.IsChecked = true;

            userAcc = account;
            txt_UserName.Text = account.FullName;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Miniimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void rbtn_Book_Checked(object sender, RoutedEventArgs e)
        {
            CurrentPage = new BookView();
            ct_Content.Content = currentPage.Content;
        }

        private void rbtn_BookCategory_Checked(object sender, RoutedEventArgs e)
        {
            CurrentPage = new BookCategoryView();
            ct_Content.Content = currentPage.Content;
        }

        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }
    }
}
