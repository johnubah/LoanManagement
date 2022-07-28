using KOPA.LoanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Domain.Entity
{
    public class Customer : BaseEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public String NationalIdNumber { get; set; }

        public String PhoneNumber { get; set; }

        public String KOPAAccoutNumber;
        public String CreatedBy { get; set; }   
        public LoanStatus Status { get; set; } 



    }
}
