using SisDoBem.Models.Enums;

namespace SisDoBem.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public List<ItemCategoria> categoria { get; set; }
        public string descricao { get; set; }
        public int quantidade { get; set; }
        

    }
}
