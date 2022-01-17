using System;
using System.Threading.Tasks;
using Pagamento_Domain.Entities;
using Pagamentos_Domain.Entities;
using Pagamentos_Domain.Interfaces;

namespace Pagamentos_Services.Services
{
    public class PagamentoService : IPagamentoService
    {
        public PaymentRequest PaymentValidation(PaymentEntity payment)
        {
            var result = new PaymentRequest();
            if (payment.Valor > 100)
            {
                result.Valor = payment.Valor;
                result.Estado = "APROVADO";
            }
            else
            {
                result.Valor = payment.Valor;
                result.Estado = "REPROVADO";
            }

            return result;

        }

    }
}
