namespace Produtos_Domain.Entities
{
    public class PaymentRequest
    {
        public decimal valor { get; set; }
        public CardEntity cartao { get; set; }
    }
}
