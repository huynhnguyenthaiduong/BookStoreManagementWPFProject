using BookStoreManagementBO;
using BookStoreManagementDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementRepository
{
    public class AccountRepository : IAccountRepository
    {
        public Account Login(string email, string password) => AccountDAO.Instance.Login(email, password);
        public List<Account> GetAllAccounts() => AccountDAO.Instance.GetAllAccounts();
        public void CreateAccount(Account createdAccount) => AccountDAO.Instance.CreateAccount(createdAccount);
        public void UpdateAccount(Account updateAccount) => AccountDAO.Instance.UpdateAccount(updateAccount);
        public void DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);
        public List<Account> SearchAccount(string searchValue) => AccountDAO.Instance.SearchAccount(searchValue);
    }
}
