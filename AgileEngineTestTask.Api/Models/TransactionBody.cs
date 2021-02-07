using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgileEngineTestTask1.Models
{
    public class TransactionBody
    {
        [Required(ErrorMessage = "You should provide a Type value.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "You should provide a Amount value.")]
        public decimal Amount { get; set; }
    }
}
