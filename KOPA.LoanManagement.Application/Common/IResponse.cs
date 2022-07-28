using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.Common
{
    public interface IResponse
    {
        bool Successful { get; set; }
        String Message { get; set; }
    }
}
