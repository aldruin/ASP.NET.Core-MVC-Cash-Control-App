using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CashFlow.Application.Interfaces;
using CashFlow.Application.Services;

namespace CashFlow.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services,
                    IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            services.AddScoped<ISheetService, SheetService>();
            services.AddScoped<IFinancialEntryService, FinancialEntryService>();
            services.AddScoped<IFinancialExpenseService, FinancialExpenseService>();

            services.AddHttpClient();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

            return services;
        }
    }
}
