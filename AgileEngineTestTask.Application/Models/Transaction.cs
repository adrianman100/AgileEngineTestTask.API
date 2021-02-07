using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgileEngineTestTask1.Models
{
    public class TransactionDetail
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
