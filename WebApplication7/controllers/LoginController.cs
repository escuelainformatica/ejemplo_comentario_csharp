using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using WebApplication7.repo;

namespace WebApplication7.Controllers
{
    public class LoginController : Controller
    {
        private CategoriaRepo categoriaRepo = new CategoriaRepo();
        private ComentarioRepo comentarioRepo = new ComentarioRepo();
        private UsuarioRepo usuarioRepo=new UsuarioRepo();

        [HttpGet]
        public IActionResult Index()
        {
            Usuario modelo=new Usuario();
            return View(modelo);
        }
        [HttpPost]
        public IActionResult Index(Usuario modelo)
        {

            Usuario usuarioAntiguo= usuarioRepo.ObtenerPorId(modelo.IdUsuario);
            if(usuarioAntiguo==null)
            {
                ViewBag.error="Usuario no encontrado";
            } else
            {
                if(modelo.Clave!=usuarioAntiguo.Clave)
                {
                    ViewBag.error="Clave no correcta";
                }
            }
            if( ViewBag.error==null)
            {                
                HttpContext.Session.SetString("idusuario", usuarioAntiguo.IdUsuario);
                HttpContext.Session.SetString("nombrecompleto", usuarioAntiguo.NombreCompleto);
                
                return Redirect("/comentario/listar");
            }


            return View(modelo);
        }
    }
}
