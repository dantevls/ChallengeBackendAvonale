using System.ComponentModel.DataAnnotations;

namespace Produtos_Domain.Entities
{
    public class ProductEntity : BaseEntity
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Valor_Unitario { get; set; }

        [Required]
        public int Qtde_estoque { get; set; }
    }
}
