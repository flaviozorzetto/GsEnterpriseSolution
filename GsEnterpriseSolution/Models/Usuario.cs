using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GsEnterpriseSolution.Models
{
    [Table("TABLE_GS_SOLUTION_USUARIO")]
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Sobrenome { get; set; }

        [Required, Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public double? Peso { get; set; }

        [Required]
        public double? Altura { get; set; }

        [Required]
        public Sexo? Sexo { get; set; }

        // 1:1
        [Required]
        public Login? Login { get; set; }

        // 1:1
        public Endereco? Endereco { get; set; }

        // 1:N
        public IList<Contato>? Contatos { get; set; }
    }

    public enum Sexo
    {
        MASCULINO, FEMININO, OUTRO
    }
}
