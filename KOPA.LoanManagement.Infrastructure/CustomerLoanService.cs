using AutoMapper;
using FluentValidation;
using KOPA.LoanManagement.Application.Common;
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
    public class CustomerLoanService : ICustomerLoanService
    {
        private readonly ICustomerLoanRepository _customerLoanRepository;
        private readonly IValidator<CustomerLoanDTO> _customerLoanValidator;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerLoanService(ICustomerLoanRepository customerLoanRepository,
            IValidator<CustomerLoanDTO> customerLoanValidator,
            ICustomerService customerService,
            IMapper mapper)
        {
            this._customerLoanRepository = customerLoanRepository;
            this._customerLoanValidator = customerLoanValidator;
            this._customerService = customerService;
            this._mapper = mapper;

        }
        public  async Task<CustomerLoanResponseDTO> Create(CustomerLoanDTO customerLoanDTO)
        {
            //Validate the Input
            var customerValidationResponse = await this._customerLoanValidator.ValidateAsync(customerLoanDTO);
            if (!customerValidationResponse.IsValid)
            {
                StringBuilder errorMessageBuilder = new StringBuilder();

                foreach (var error in customerValidationResponse.Errors)
                {
                    errorMessageBuilder.Append(error.ErrorMessage).Append(Environment.NewLine);
                }
                LoanException<CustomerLoanResponseDTO> validationEx = new LoanException<CustomerLoanResponseDTO>(_mapper.Map<CustomerLoanDTO, CustomerLoanResponseDTO>(customerLoanDTO), errorMessageBuilder.ToString());
                throw validationEx;
            }
            //Validate that customer is eligible for loan
            var customerIsEligibleForLoan = await LoanEligible(customerLoanDTO.CustomerId);
            if(!customerIsEligibleForLoan)
            {
                throw new LoanException<CustomerLoanResponseDTO>(_mapper.Map<CustomerLoanDTO, CustomerLoanResponseDTO>(customerLoanDTO), MessageDifinition.CustomerNotEligibleDisplay);
                
            }
            try
            {
                CustomerLoan customerLoan = this._mapper.Map<CustomerLoanDTO, CustomerLoan>(customerLoanDTO);
             
                var customerLoanCreated =  await this._customerLoanRepository.Add(customerLoan);
                CustomerLoanResponseDTO customerDTOResponse = _mapper.Map<CustomerLoanDTO, CustomerLoanResponseDTO>(customerLoanDTO);
                customerDTOResponse.LoanId = customerLoanCreated.Id;
                return customerDTOResponse;
            }
            catch(Exception ex)
            {
                throw new LoanException<CustomerLoanResponseDTO>(_mapper.Map<CustomerLoanDTO, CustomerLoanResponseDTO>(customerLoanDTO), MessageDifinition.CustomerLoanError, ex);
            }
        }

        private async Task<bool> LoanEligible(long customerId)
        {
            Customer customer =  await this._customerService.GetCustomerById(customerId);
            if (customer != null && (customer.Status == Domain.Common.LoanStatus.Completed || customer.Status == Domain.Common.LoanStatus.UnAsigned))
            {
                return true;
            }
            return false;
        }
    }
}
