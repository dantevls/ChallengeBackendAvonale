using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Produtos_Data.Context;
using Produtos_Data.Repository;
using Produtos_Domain.Intefaces;

namespace Produtos_CrossCuting.Depency
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            servicesCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=localhost;Port=3306;Database=dbAvonale;Uid=root;Pwd=root"));
        }
    }
}
