using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
