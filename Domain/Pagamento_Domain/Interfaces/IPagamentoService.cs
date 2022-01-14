using System.Threading.Tasks;
using Pagamentos_Domain.Entities;
using Pagamentos_Domain.Models;

namespace Pagamentos_Domain.Interfaces
{
    public interface IPagamentoService
    {
        PaymentModel PaymentValidation(PaymentEntity payment);
    }
}
