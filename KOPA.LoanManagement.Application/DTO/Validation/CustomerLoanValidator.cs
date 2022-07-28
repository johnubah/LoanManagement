using FluentValidation;
using KOPA.LoanManagement.Application.Contract.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.DTO.Validation
{
    public class CustomerLoanValidator : AbstractValidator<CustomerLoanDTO>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerLoanValidator(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
            RuleFor(rule => rule.TotalLoanAmount)
                .GreaterThan(0)
                .WithMessage("Total Amount must be greater than zero");

            RuleFor(rule => rule.DailyRate)
                .GreaterThan(0)
                .WithMessage("Daily Rate must be greater than zero");

            RuleFor(rule => rule.CustomerId)
              .GreaterThan(0)
              .MustAsync(async (id, token) =>
              {
                  return await this._customerRepository.Exists(id);
              })
             .WithMessage("Customer does not exists");
              
            


        }
    }
}
