using AutoMapper;
using KOPA.LoanManagement.Application.DTO;
using KOPA.LoanManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application.DTOTransformDomain
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerLoanDTO,CustomerLoan>().ReverseMap();
            CreateMap<CustomerLoanDTO, CustomerLoanResponseDTO>().ReverseMap();

        }
    }
}
