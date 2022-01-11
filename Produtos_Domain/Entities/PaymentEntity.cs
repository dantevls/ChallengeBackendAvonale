using System;

namespace Produtos_Domain.Entities
{
    public class PaymentEntity
    {
        public Guid id_produto { get; set; }
        public CardEntity cartao { get; set; }

        public int qtde_comprada { get; set; }
    }
}
