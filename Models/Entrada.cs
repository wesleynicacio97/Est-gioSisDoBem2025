namespace SisDoBem.Models
{
    public class Entrada
    {
        public int Id { get; set; }
        public DateTime DataDaEntrada { get; set; } = DateTime.Now;
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
    }
}
