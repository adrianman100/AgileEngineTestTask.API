using AgileEngineTestTask1.Application.Models;
using AgileEngineTestTask1.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgileEngineTestTask1.Models
{
    public class Account : IAccount
    {
        private readonly object balanceLock = new object();
        private decimal balance;

        private readonly List<TransactionDetail> transactions;

        public Account(decimal initialBalance)
        {
            balance = initialBalance;
            transactions = new List<TransactionDetail>();
        }

        public decimal Debit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The debit amount cannot be negative.");
            }

            decimal appliedAmount = 0;
            lock (balanceLock)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                    appliedAmount = amount;

                    transactions.Add(new TransactionDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        Type = TransactionType.Debit,
                        Amount = amount,
                        EffectiveDate = DateTime.Now
                    });
                }
            }
            return appliedAmount;
        }

        public void Credit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The credit amount cannot be negative.");
            }

            lock (balanceLock)
            {
                balance += amount;

                transactions.Add(new TransactionDetail
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = TransactionType.Credit,
                    Amount = amount,
                    EffectiveDate = DateTime.Now
                });
            }
        }

        public decimal GetBalance()
        {
            lock (balanceLock)
            {
                return balance;
            }
        }

        public List<TransactionDetail> GetTransactions()
        {
            return transactions;
        }
    }
}
