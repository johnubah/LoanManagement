using KOPA.LoanManagement.Application.Common;
using KOPA.LoanManagement.Application.Contract.Infrastructure;
using KOPA.LoanManagement.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KOPA.LoanManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        public readonly ICustomerLoanService _customerLoanService;
        public LoanController(ICustomerLoanService customerLoanService)
        {
            this._customerLoanService = customerLoanService;

        }
        [HttpPost(Name ="bookedLoan")]
      
        public async Task<IActionResult> BookLoan([FromBody] CustomerLoanDTO customerLoan)
        {
            try
            {
                var customer =await this._customerLoanService.Create(customerLoan);
                return Ok(customerLoan);
            }
            catch(LoanException<CustomerLoanDTO> ex)
            {
                return BadRequest(ex.RequestData);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
