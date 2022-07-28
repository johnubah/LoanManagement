using KOPA.LoanManagement.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.DTO
{
    public class CustomerLoanResponseDTO : IResponse
    {
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public decimal TotalLoanAmount { get; set; }
        public bool Successful { get; set; }
        public string Message { get; set; }
        public long LoanId { get; set; }
    }
}
