using BookStoreManagementBO;
using BookStoreManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = null;

        public AccountService()
        {
            if (_accountRepository == null)
                _accountRepository = new AccountRepository();
        }

        public Account Login(string email, string password) => _accountRepository.Login(email, password);
        public List<Account> GetAllAccounts() => _accountRepository.GetAllAccounts();
        public void CreateAccount(Account createdAccount) => _accountRepository.CreateAccount(createdAccount);
        public void UpdateAccount(Account updateAccount) => _accountRepository.UpdateAccount(updateAccount);
        public void DeleteAccount(int id) => _accountRepository.DeleteAccount(id);
        public List<Account> SearchAccount(string searchValue) => _accountRepository.SearchAccount(searchValue);
    }
}
