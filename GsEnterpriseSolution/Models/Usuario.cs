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
        public string? Sobrenome { get; set;}

        [Required, Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Required]
        public double? Peso { get; set; }

        [Required]
        public double? Altura { get; set; }

        [Required]
        public Sexo? Sexo { get; set; }

        // 1:1
        public Login? Login { get; set; }

        // 1:1
        public Endereco? Endereco { get; set; }

        // 1:N
        public IList<Contato>? Contatos { get; set; }

        [Required]
        public Tipo? Tipo { get; set; }

        // Vai haver especialidade somente se o tipo = medico
        public Especialidade? Especialidade { get; set; }
    }

    public enum Sexo
    {
        MASCULINO, FEMININO, OUTRO
    }

    public enum Tipo
    {
        MEDICO, PACIENTE
    }

    public enum Especialidade
    { 
        ORTOPEDIA, PEDIATRIA, CLINICO_GERAL, GINECOLOGIA, GERIATRIA, CARDIOLOGIA, OTORRINOLARINGOLOGIA, DEMARTOLOGIA, GASTROENTEROLOGIA, OFTAMOLOGIA, NAO_DEFINIDO
    }
}
