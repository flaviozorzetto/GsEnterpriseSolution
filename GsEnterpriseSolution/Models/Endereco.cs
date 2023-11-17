using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GsEnterpriseSolution.Models
{
    [Table("TABLE_GS_SOLUTION_ENDERECO")]
    public class Endereco
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string? Bairro { get; set; }

        [Required]
        public string? Cidade { get; set; }

        [Required]
        public string? Estado { get; set; }

        [Required]
        public string? Cep { get; set; }

    }
}
