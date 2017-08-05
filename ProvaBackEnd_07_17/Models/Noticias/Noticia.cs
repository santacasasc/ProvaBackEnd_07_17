using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaBackEnd_07_17.Models.Noticias
{
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "URL")]
        public string URL { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        public IList<NoticiaItem> Itens { get; set; }

        public virtual Categoria Categoria { get; set; }

    }
}