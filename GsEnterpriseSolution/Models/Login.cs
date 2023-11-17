using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GsEnterpriseSolution.Models
{
    [Table("TABLE_GS_SOLUTION_LOGIN")]
    public class Login
    {
        public int Id { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Senha { get; set; }
    }
}
