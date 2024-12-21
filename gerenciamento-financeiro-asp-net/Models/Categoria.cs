using System.ComponentModel.DataAnnotations;

namespace gerenciamento_financeiro_asp_net.Models
{
    public class Categoria
    {
        public string CategoriaId { get; set; }

        [Required(ErrorMessage = "Digite a categoria!")]
        public string Nome { get; set; }
    }
}
