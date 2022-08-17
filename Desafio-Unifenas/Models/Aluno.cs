using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Desafio_Unifenas.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Display(Name = "Aluno")]
        [Required]
        public string Nome { get; set; }
        [Display(Name ="Mãe")]
        [Required]
        public string NomedaMae { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataNasc { get; set; }
        [Display(Name = "CPF")]
        [Required]
        public String Cpf { get; set; }
        [Display(Name = "Endereço")]
        [Required]
        public string Endereco { get; set; }
    }
}
