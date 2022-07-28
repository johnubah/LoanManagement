using KOPA.LoanManagement.Application.DTO;
using KOPA.LoanManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.Contract.Infrastructure
{
    public interface ICustomerService
    {
        public Task<Customer> create(CustomerDTO customerDto);
        Task<Customer> GetCustomerById(long customerId);
    }
}
