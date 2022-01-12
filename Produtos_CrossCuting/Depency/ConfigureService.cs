using Microsoft.Extensions.DependencyInjection;
using Produtos_Domain.Intefaces.Services.Products;
using Produtos_Service.Services;

namespace Produtos_CrossCuting.Depency
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IProductService, ProductService>();
        }
    }
}
