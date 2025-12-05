using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SisDoBem.Models
{
    public class Doador
    {
        
        public int Id { get; set; } 
        [Required]
        [MaxLength(100)]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário informar o E-mail")] 
        public string Telefone { get; set; }
        public string Endereco { get; set; }

    }
}
