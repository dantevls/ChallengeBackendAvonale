namespace Pagamentos_Domain.Entities
{
    public class PaymentEntity
    {
        public decimal Valor { get; set; }

        public CardEntity Cartao { get; set; }

    }
}
