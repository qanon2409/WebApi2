using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotiController : ControllerBase
    {
        PROYECTO2TIContext ctx = new PROYECTO2TIContext();

        [HttpPost]
        public string Post(Noticia noticias)
        {
            ctx.Noticias.Add(noticias);
            ctx.SaveChanges();
            return "Noticia Agregada!";
        }

        [HttpGet]
        public IEnumerable<Noticia> Get()
        {
            return ctx.Noticias.ToList();
        }

        [HttpPut]
        public string Put(int id, Noticia noticia)
        {
            var noticia_= ctx.Noticias.Find(id);
            noticia_.Titulo = noticia.Titulo;
            noticia_.Descripcion= noticia.Descripcion;
            noticia_.Urlnoticia=noticia.Urlnoticia;
            noticia_.IdcatNavigation=noticia.IdcatNavigation;
            noticia_.IdfuenteNavigation=noticia.IdfuenteNavigation;
            noticia_.Idpais=noticia.Idpais;

            ctx.Entry(noticia_).State= EntityState.Modified;
            ctx.SaveChanges();

            return "Noticia Modificada!";

        }

        [HttpDelete]
        public string Delete(int id)
        {
            Noticia noticia= ctx.Noticias.Find(id);
            ctx.Noticias.Remove(noticia);
            return "Noticia Eliminada!";

        }

    }
}
