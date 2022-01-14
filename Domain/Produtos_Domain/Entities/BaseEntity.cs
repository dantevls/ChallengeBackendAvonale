using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos_Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public decimal? Valor_Ultima_Venda { get; set; }

        public DateTime? Data_Compra { get; set; }
    }
}
