using System;

namespace Produtos_Domain.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public decimal Valor_Unitario { get; set; }

        public int qtde_estoque { get; set; }

    }
}
