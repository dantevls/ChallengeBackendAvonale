using System;

namespace Produtos_Domain.Entities
{
    public class PaymentEntity
    {
        public Guid produto_id { get; set; }

        public CardEntity cartao { get; set; }

        public int qtde_comprada { get; set; }
    }
}
