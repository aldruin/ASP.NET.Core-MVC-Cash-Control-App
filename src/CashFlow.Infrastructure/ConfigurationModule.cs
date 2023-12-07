
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using CashFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });


            services.AddScoped(typeof(Repository<>));
            services.AddScoped<ISheetRepository, SheetRepository>();
            services.AddScoped<IFinancialEntryRepository, FinancialEntryRepository>();
            services.AddScoped<IFinancialExpenseRepository, FinancialExpenseRepository>();

            return services;
        }
    }
}
