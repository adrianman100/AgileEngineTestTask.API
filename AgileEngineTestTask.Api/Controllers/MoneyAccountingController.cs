using AgileEngineTestTask1.Application.Services;
using AgileEngineTestTask1.Models;
using AgileEngineTestTask1.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTestTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyAccountingController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public MoneyAccountingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #region Account

        // GET api/<MoneyAccountingController>/balance
        [HttpGet("balance")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAccountBalance()
        {
            var accountBalance = await _accountService.GetBalance();

            return Ok(accountBalance);
        }

        #endregion

        #region Transactions 

        // GET api/<MoneyAccountingController>/transactions
        [HttpGet("transactions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TransactionDetail>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTransactions()
        {
            var trxs = await _accountService.GetTransactions();

            return trxs.Count > 0 ? Ok(trxs) : (ActionResult)NotFound();
        }

        // POST api/<MoneyAccountingController/transactions/commit>
        [HttpPost("transactions/commit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CommitTransaction([FromBody] TransactionBody transactionBody)
        {
            if(transactionBody.Amount < 0)
            {
                return Forbid();
            }

            switch (transactionBody.Type)
            {
                case TransactionType.Credit:
                    _accountService.Credit(transactionBody.Amount);
                    break;
                case TransactionType.Debit:
                    await _accountService.Debit(transactionBody.Amount);
                    break;
                default:
                    return Forbid();
            }

            return Ok();
        }

        // GET api/<MoneyAccountingController>/transactions/5
        [HttpGet("transactions/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionDetail))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTransactionById(string id)
        {
            var trx = await _accountService.GetTransactionById(id);

            return trx != null ? Ok(trx) : (ActionResult)NotFound();
        }

        #endregion
    }
}
