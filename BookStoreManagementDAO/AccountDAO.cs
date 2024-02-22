using BookStoreManagementBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagementDAO
{
    public class AccountDAO
    {
        private readonly BookStoreManagementDBContext _dbContext = null;

        private static AccountDAO instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new BookStoreManagementDBContext();
            }
        }

        public Account Login(string email, string password)
        {
            return _dbContext.Accounts.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public List<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public List<Account> SearchAccount(string searchValue)
        {
            return _dbContext.Accounts.Where(a => a.FullName.Contains(searchValue)).ToList();
        }

        public void CreateAccount(Account createdAccount)
        {
            Account account = _dbContext.Accounts.Where(a => a.Email.Equals(createdAccount.Email)).FirstOrDefault();

            if (account == null)
            {
                _dbContext.Accounts.Add(createdAccount);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Email has already use");
            }
        }

        public void UpdateAccount(Account updateAccount)
        {
            Account account = _dbContext.Accounts.Where(a => a.AccountId == updateAccount.AccountId).FirstOrDefault();

            if (account != null)
            {
                _dbContext.Entry<Account>(account).CurrentValues.SetValues(updateAccount);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Account is not existed");
            }
        }

        public void DeleteAccount(int id)
        {
            Account account = _dbContext.Accounts.Where(a => a.AccountId == id).FirstOrDefault();

            if (account != null)
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();
            }
        }
    }
}
