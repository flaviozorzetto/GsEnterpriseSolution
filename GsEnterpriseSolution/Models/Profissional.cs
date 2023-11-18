using System.ComponentModel.DataAnnotations;

namespace GsEnterpriseSolution.Models
{
    public class Profissional
    {
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Sobrenome { get; set; }

        [Required]
        public Especialidade? Especialidade { get; set; }

        [Required]
        public string? Crm { get; set; }

        [Required]
        public string? Cpf { get; set; }

        [Required]
        public Login? Login { get; set; }
    }

    public enum Especialidade
    {
        ORTOPEDIA, PEDIATRIA, CLINICO_GERAL, GINECOLOGIA, GERIATRIA, CARDIOLOGIA, OTORRINOLARINGOLOGIA, DEMARTOLOGIA, GASTROENTEROLOGIA, OFTAMOLOGIA, NAO_DEFINIDO
    }
}
