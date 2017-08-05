using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaBackEnd_07_17.Models.Noticias
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public virtual IList<Noticia> Noticias { get; set; }
    }
}