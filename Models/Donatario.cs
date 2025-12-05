using System.ComponentModel.DataAnnotations;

namespace SisDoBem.Models
{
    public class Donatario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o endereço.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o telefone.")]
        public string Telefone { get; set; }

        public Enums.TipoDeUsuario TipoUsuario { get; set; } = Enums.TipoDeUsuario.Donatario;
    }
}
