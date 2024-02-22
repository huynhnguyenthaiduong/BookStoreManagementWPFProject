using BookStoreManagementBO;
using BookStoreManagementBO.DTOs;
using BookStoreManagementService;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BookStoreManagementGUI.AdminView
{
    /// <summary>
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        private readonly IAccountService _accountService = null;

        public AccountView()
        {
            InitializeComponent();
            _accountService = new AccountService();
            LoadData();
        }

        public void LoadData()
        {
            dtgv_AccountInfo.UnselectAll();
            cmb_Role.ItemsSource = new List<string> { "Administrator", "Staff", "User" };

            //Set data input empty
            txt_FullName.Text = string.Empty;
            txt_Email.Text = string.Empty;
            psw_Password.Password = string.Empty;
            cmb_Role.SelectedIndex = 0;

            List<Account> accounts = new List<Account>();
            if (String.IsNullOrEmpty(txt_Search.Text))
            {
                accounts = _accountService.GetAllAccounts();
            }
            else
            {
                //Search
                accounts = _accountService.SearchAccount(txt_Search.Text);
            }

            dtgv_AccountInfo.ItemsSource = accounts;
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //check data validation
                if (InputFieldValidation())
                {
                    Account account = new Account
                    {
                        AccountId = 0,
                        FullName = txt_FullName.Text,
                        Password = psw_Password.Password,
                        Email = txt_Email.Text,
                        Role = cmb_Role.SelectedItem.ToString(),
                    };

                    _accountService.CreateAccount(account);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (dtgv_AccountInfo.SelectedItems.Count)
                {
                    case 0:
                        MessageBox.Show("Please Chose Book Category to update");
                        break;
                    case 1:
                        //Check data validation
                        if (InputFieldValidation())
                        {
                            Account account = (Account)dtgv_AccountInfo.SelectedItem;
                            Account updatedAccount = new Account
                            {
                                AccountId = account.AccountId,
                                FullName = txt_FullName.Text,
                                Password = psw_Password.Password,
                                Email = txt_Email.Text,
                                Role = cmb_Role.SelectedItem.ToString(),
                            };

                            _accountService.UpdateAccount(updatedAccount);
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

        private bool InputFieldValidation()
        {
            if (string.IsNullOrEmpty(txt_Email.Text) ||
                   string.IsNullOrEmpty(txt_FullName.Text) ||
                   string.IsNullOrEmpty(psw_Password.Password))
                throw new Exception("All input fields must be filled!");

            if (!IsValidEmailAddress(txt_Email.Text))
                throw new Exception("Invalid Email format");

            return true;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            switch (dtgv_AccountInfo.SelectedItems.Count)
            {
                case 0:
                    MessageBox.Show("Please Chose Book Category to update");
                    break;
                case 1:
                    Account account = (Account)dtgv_AccountInfo.SelectedItem;

                    _accountService.DeleteAccount(account.AccountId);
                    LoadData();
                    break;
                default:
                    MessageBox.Show("Cannot update multiple book category");
                    break;
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            dtgv_AccountInfo.UnselectAll();
            //Empty input field
            txt_FullName.Text = string.Empty;
            txt_Email.Text = string.Empty;
            psw_Password.Password = string.Empty;
            cmb_Role.SelectedIndex = 0;
        }

        private void dtgv_AccountInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account account = (Account)dtgv_AccountInfo.SelectedItem;
            if (account != null)
            {
                //Fill data
                txt_FullName.Text = account.FullName;
                txt_Email.Text = account.Email;
                psw_Password.Password = account.Password;
                cmb_Role.SelectedValue = account.Role;
            }
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public bool IsValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}
