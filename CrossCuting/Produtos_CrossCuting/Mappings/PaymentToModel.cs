using AutoMapper;
using Produtos_Domain.Entities;
using Produtos_Domain.Models;

namespace Produtos_CrossCuting.Mappings
{
    public class PaymentToModel : Profile
    {
        public PaymentToModel()
        {
            CreateMap<PaymentModel, PaymentResponse>().ReverseMap();
        }
    }
}
