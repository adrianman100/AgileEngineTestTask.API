using AgileEngineTestTask1.Application.Models;
using AgileEngineTestTask1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgileEngineTestTask1.Application.Services
{
    public interface IAccountService
    {
        Task<decimal> Debit(decimal amount);
        void Credit(decimal amount);
        Task<List<TransactionHistory>> GetTransactions();
        Task<decimal> GetBalance();
        Task<TransactionDetail> GetTransactionById(string id);
    }
}