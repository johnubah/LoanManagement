using FluentValidation;
using KOPA.LoanManagement.Application.DTO;
using KOPA.LoanManagement.Application.DTO.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IValidator<CustomerLoanDTO>, CustomerLoanValidator>();
            return services;
        }
    }
}
