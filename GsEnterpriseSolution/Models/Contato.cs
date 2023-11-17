using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GsEnterpriseSolution.Models
{
    [Table("TABLE_GS_SOLUTION_CONTATO")]
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        public string? Telefone { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}
