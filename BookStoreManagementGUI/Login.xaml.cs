using BookStoreManagementBO;
using BookStoreManagementGUI;
using BookStoreManagementService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WPFStudentMangementGUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountService _accountService = null;

        public Login()
        {
            InitializeComponent();
            _accountService = new AccountService();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Email.Text) && string.IsNullOrEmpty(txt_Password.Password))
            {
                MessageBox.Show("Email and Password are required");
            }
            else
            {
                Account acc = _accountService.Login(txt_Email.Text, txt_Password.Password);

                if (acc != null)
                {
                    switch (acc.Role)
                    {
                        case "Administrator":
                            AdminScreen adminScreen = new AdminScreen(acc);
                            this.Hide();
                            adminScreen.Show();
                            break;
                        case "Staff":
                            StaffScreen staffScreen = new StaffScreen(acc);
                            this.Hide();
                            staffScreen.Show();
                            break;
                        case "User":
                            MessageBox.Show("You don't have permission to access application.");
                            break;
                    }
                }
                else MessageBox.Show("INcorrect Email or Password");
            }
        }
    }
}
