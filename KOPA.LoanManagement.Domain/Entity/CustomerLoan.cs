using KOPA.LoanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Domain.Entity
{
    public class CustomerLoan : BaseEntity
    {
        
        public long CustomerId { get; set; }
        public long ProductInStoreId { get; set; }  
        public decimal TotalLoanAmount { get; set; }
        public decimal DailyRate { get; set; }
        public decimal LoanBalance { get; set; }
        public LoanStatus  Status { get; set; }
        public DateTime? LastPaymentDate { get; set; }


    }
}
