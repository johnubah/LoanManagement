using KOPA.LoanManagement.Application.Contract.Infrastructure;
using KOPA.LoanManagement.Application.Contract.Persistence;
using KOPA.LoanManagement.Application.DTO;
using KOPA.LoanManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Infrastructure
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public Task<Customer> create(CustomerDTO customerDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetCustomerById(long customerId)
        {
            return await this._customerRepository.Get(customerId);
        }
    }
}
