using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjChoc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjChoc.Domain.Interfaces;
using ProjChoc.Application.Interfaces;
using ProjChoc.Application.Services;
using ProjChoc.Infra.Data.Repositories;

namespace ProjChoc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtenha a string de conexão do arquivo de configuração.
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Adicione o contexto do banco de dados à injeção de dependência.
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            // Adicione a identidade padrão com o usuário IdentityUser.
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            // Retorna o IServiceCollection para suportar a encadeamento de chamadas.
            return services;
        }
    }
}
