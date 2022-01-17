using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos_Domain.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo valor é obrigatório")]
        public decimal Valor_Unitario { get; set; }

        [Required(ErrorMessage = "O campo estoque é obrigatório")]
        public int Qtde_estoque { get; set; }

        [Required]
        public Guid Id { get; set; }

        public decimal? Valor_Ultima_Venda { get; set; }

        public DateTime? Data_Compra { get; set; }
    }
}
