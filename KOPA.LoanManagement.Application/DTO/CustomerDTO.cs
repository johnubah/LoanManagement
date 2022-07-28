using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.DTO
{
    public class CustomerDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public String IdNumber { get; set; }

        public String PhoneNumber { get; set; }
    }
}
