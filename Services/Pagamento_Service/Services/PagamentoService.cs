using System;
using System.Threading.Tasks;
using Pagamentos_Domain.Entities;
using Pagamentos_Domain.Interfaces;
using Pagamentos_Domain.Models;

namespace Pagamentos_Services.Services
{
    public class PagamentoService : IPagamentoService
    {
        public PaymentModel PaymentValidation(PaymentEntity payment)
        {
            var result = new PaymentModel();
            if (payment.Valor > 100)
            {
                result.Valor = payment.Valor;
                result.Estado = "APROVADO";
            }
            else
            {
                result.Estado = "REPROVADO";
            }

            return result;

        }

    }
}
