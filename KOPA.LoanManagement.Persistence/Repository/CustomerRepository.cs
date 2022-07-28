using KOPA.LoanManagement.Application.Contract.Persistence;
using KOPA.LoanManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Persistence.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LoanManagementDbContext loanManagementDbContext) : base(loanManagementDbContext)
        {
        }
    }
}
