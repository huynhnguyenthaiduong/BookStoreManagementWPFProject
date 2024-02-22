using BookStoreManagementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementRepository
{
    public interface IAccountRepository
    {
        public Account Login(string email, string password);
        public List<Account> GetAllAccounts();
        public void CreateAccount(Account createdAccount);
        public void UpdateAccount(Account updateAccount);
        public void DeleteAccount(int id);
        public List<Account> SearchAccount(string searchValue);
    }
}
