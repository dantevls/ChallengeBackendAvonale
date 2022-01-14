using Microsoft.Extensions.DependencyInjection;
using Pagamentos_Domain.Interfaces;
using Pagamentos_Services.Services;

namespace Pagamentos_CrossCuting.Dependency
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IPagamentoService, PagamentoService>();
        }
    }
}
