using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.DTO
{
    public class CustomerLoanDTO
    {
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public long ShopID { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public decimal DailyRate { get; set; }


    }
}
