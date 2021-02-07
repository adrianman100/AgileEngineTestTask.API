using AgileEngineTestTask1.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTestTask1.Models
{
    public interface IAccount
    {
        decimal Debit(decimal amount);
        void Credit(decimal amount);
        decimal GetBalance();
        List<TransactionDetail> GetTransactions();
    }
}
