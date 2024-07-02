using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.ExternalService.Diamond;
using JewelrySalesSystem.Infrastructure.ExternalService.GoldBtmc;
using JewelrySalesSystem.Infrastructure.ExternalService.VnPay;
using JewelrySalesSystem.Infrastructure.Persistence;
using JewelrySalesSystem.Infrastructure.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("ServerDocker"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IVnPayService, VnPayService>();
            services.AddHttpClient<IGoldService, GoldService>();
            services.AddHttpClient<IDiamondService, DiamondService>();
            
            //inject repo ở đây
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IPromotionRepository, PromotionRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IDiamondRepository, DiamondRepository>();
            services.AddTransient<IGoldRepository, GoldRepository>();

            return services;
        }
    }
}
