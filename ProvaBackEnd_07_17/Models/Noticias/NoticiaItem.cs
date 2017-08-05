using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaBackEnd_07_17.Models.Noticias
{
    public class NoticiaItem
    {
        [Key]
        public int Id { get; set; }

        public int TipoId { get; set; }

        public int NoticiaId { get; set; }

        [Display(Name = "Valor")]
        public string Valor { get; set; }

        public virtual Tipo Tipo { get; set; }

        public virtual Noticia Noticia { get; set; }

    }
}