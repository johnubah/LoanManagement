using KOPA.LoanManagement.Application.Contract.Persistence;
using KOPA.LoanManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Persistence.Repository
{
    public class CustomerLoanRepository : GenericRepository<CustomerLoan>, ICustomerLoanRepository
    {
        private readonly LoanManagementDbContext _loanManagementDbContext;
        public CustomerLoanRepository(LoanManagementDbContext loanManagementDbContext) : base(loanManagementDbContext)
        {
            this._loanManagementDbContext = loanManagementDbContext;
                 
        }
    }
}
