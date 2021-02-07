using AgileEngineTestTask1.Application.Models;
using AgileEngineTestTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AgileEngineTestTask1.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly Account account;
        public AccountService()
        {
            account = new Account(0);
        }
        public async Task<decimal> Debit(decimal amount)
        {
            // Wrapping synchronous code into asynchronous call 
            var task = Task.Run(() => {
                // Access to the DB, web request
                Thread.Sleep(500);
                return account.Debit(amount);
                });
            return await task;
        }

        public void Credit(decimal amount)
        {
            Task.Run(() => {
                // Access to the DB, web request
                Thread.Sleep(500);
                account.Credit(amount);
            });
        }

        public async Task<List<TransactionHistory>> GetTransactions()
        {
            // Wrapping synchronous code into asynchronous call 
            var task = Task.Run(() => {
                // Access to the DB, web request
                Thread.Sleep(500);
                return account.GetTransactions().Select(e => new TransactionHistory
                {
                    Id = e.Id,
                    Type = e.Type,
                    Amount = e.Amount
                }).ToList();
            });

            return await task;
        }

        public async Task<decimal> GetBalance()
        {
            // Wrapping synchronous code into asynchronous call
            var task = Task.Run(() => {
                // Access to the DB, web request
                Thread.Sleep(500);
                return account.GetBalance();
                });
            return await task;
        }

        public async Task<TransactionDetail> GetTransactionById(string id)
        {
            // Wrapping synchronous code into asynchronous call
            var task =  Task.Run(() => {
                // Access to the DB, web request
                Thread.Sleep(500);
                return account.GetTransactions().FirstOrDefault(x => x.Id == id);
                });
            return await task;
        }
    }
}
