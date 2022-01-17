using AutoMapper;
using Produtos_Domain.Entities;
using Produtos_Domain.Models;

namespace Produtos_CrossCuting.Mappings
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<ProductModel, ProductEntity>().ReverseMap();

        }
    }
}
