using System.Threading.Tasks;
using Pagamento_Domain.Entities;
using Pagamentos_Domain.Entities;

namespace Pagamentos_Domain.Interfaces
{
    public interface IPagamentoService
    {
        PaymentRequest PaymentValidation(PaymentEntity payment);
    }
}
