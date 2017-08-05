using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaBackEnd_07_17.Models.Noticias
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual IList<NoticiaItem> Itens { get; set; }
    }
}