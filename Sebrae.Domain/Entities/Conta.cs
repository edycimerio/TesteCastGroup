using System.ComponentModel.DataAnnotations;

namespace Sebrae.Domain.Entities
{
    public class Conta
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Descricao { get; set; }
    }
}
