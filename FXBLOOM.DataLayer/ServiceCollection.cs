using FXBLOOM.DataLayer.Implementation;
using FXBLOOM.DataLayer.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FXBLOOM.DataLayer
{
    public static class ServiceCollection
    {
        public static IServiceCollection DataLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            return services;
        }
    }
}
