using AutoMapper;
using Produtos_Domain.Entities;
using Produtos_Domain.ViewModels;

namespace Produtos_CrossCuting.Mappings
{
    public class ProductViewModelToEntity : Profile
    {
        public ProductViewModelToEntity()
        {
            CreateMap<ProductViewModel, ProductEntity>().ReverseMap();
        }
    }
}
