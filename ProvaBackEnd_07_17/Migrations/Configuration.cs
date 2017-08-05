namespace ProvaBackEnd_07_17.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProvaBackEnd_07_17.Models;
    using ProvaBackEnd_07_17.Models.Noticias;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProvaBackEnd_07_17.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProvaBackEnd_07_17.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            IList<string> Roles = new List<string>();

            Roles.Add("Administrador");

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            for (int i = 0; i < Roles.Count; i++)
            {
                if (RoleManager.RoleExists(Roles[i]) == false)
                {
                    RoleManager.Create(new IdentityRole(Roles[i]));
                }
            }

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(u => u.UserName == "adm@santacasasaocarlos.com.br"))
            {
                var user = new ApplicationUser
                {
                    UserName = "adm@santacasasaocarlos.com.br",
                    Email = "adm@santacasasaocarlos.com.br",
                    PasswordHash = PasswordHash.HashPassword("123456")
                };

                UserManager.Create(user);
                UserManager.AddToRole(user.Id, Roles[0]);
            }



            Categoria CatGeral = new Categoria { Descricao = "Geral" };
            Categoria CatInovacao = new Categoria { Descricao = "Inovação" };
            Categoria CatAtualidades = new Categoria { Descricao = "Atualidades" };

            IList<Categoria> Categorias = new List<Categoria> { CatGeral,
                CatInovacao,
                CatAtualidades };

            Tipo TipoImagem = new Tipo { Descricao = "Imagem" };
            Tipo TipoTexto = new Tipo { Descricao = "Texto" };

            IList<Tipo> Tipos = new List<Tipo> { TipoImagem,
                TipoTexto };

            Noticia Noticia1 = new Noticia { Titulo = "Notícia 1", URL = "noticia_1", Categoria = CatGeral };
            NoticiaItem Item1 = new NoticiaItem { Noticia = Noticia1, Tipo = TipoTexto, Valor = "Texto 1" };
            NoticiaItem Item2 = new NoticiaItem { Noticia = Noticia1, Tipo = TipoTexto, Valor = "Texto 2" };


            Noticia Noticia2 = new Noticia { Titulo = "Notícia 2", URL = "noticia_2", Categoria = CatInovacao };
            NoticiaItem Item3 = new NoticiaItem { Noticia = Noticia2, Tipo = TipoTexto, Valor = "Texto 3" };
            NoticiaItem Item4 = new NoticiaItem { Noticia = Noticia2, Tipo = TipoImagem, Valor = "img_1.jpg" };

            Noticia Noticia3 = new Noticia { Titulo = "Notícia 3", URL = "noticia_3", Categoria = CatAtualidades };
            NoticiaItem Item5 = new NoticiaItem { Noticia = Noticia3, Tipo = TipoImagem, Valor = "img_2.jpg" };
            NoticiaItem Item6 = new NoticiaItem { Noticia = Noticia3, Tipo = TipoImagem, Valor = "img_3.jpg" };

            IList<Noticia> Noticas = new List<Noticia> { Noticia1,
                Noticia2,
                Noticia3 };

            IList<NoticiaItem> Itens = new List<NoticiaItem> {
                Item1,
                Item2,
                Item3,
                Item4,
                Item5,
                Item6};


            foreach (var c in Categorias)
            {
                if (context.Categorias.Where(m => m.Descricao == c.Descricao).FirstOrDefault() == null)
                {
                    context.Categorias.Add(c);
                }
            }

            foreach (var t in Tipos)
            {
                if (context.Tipos.Where(m => m.Descricao == t.Descricao).FirstOrDefault() == null)
                {
                    context.Tipos.Add(t);
                }
            }

            foreach (var i in Itens)
            {
                if (context.NoticiaItens.Where(m => m.Valor == i.Valor).FirstOrDefault() == null)
                {
                    context.NoticiaItens.Add(i);
                }
            }

            foreach (var n in Noticas)
            {
                if (context.Noticias.Where(m => m.Titulo == n.Titulo).FirstOrDefault() == null)
                {
                    context.Noticias.Add(n);
                }
            }

        }
    }
}
