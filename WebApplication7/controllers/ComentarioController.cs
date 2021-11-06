using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;
using WebApplication7.repo;

namespace WebApplication7.controllers
{
    public class ComentarioController : Controller
    {
        private CategoriaRepo categoriaRepo = new CategoriaRepo();
        private ComentarioRepo comentarioRepo = new ComentarioRepo();

        // localhost/comentar
        public IActionResult Index()
        {
            return Listar("");
        }

        // localhost/comentar/listar

        public IActionResult Listar(string id)
        {
            string idusuario = HttpContext.Session.GetString("idusuario");
            if(idusuario==null)
            {
                return Redirect("/login");
            }

            ViewBag.usuario = HttpContext.Session.GetString("nombrecompleto");
            ViewBag.titulo=Request.Query["titulo"];
            ViewBag.comentarios = comentarioRepo.ListarTodo();
            ViewBag.id=id;
            return View("Index");
        }
        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult Leer(string id) // // localhost/Comentario/Leer/5
        {
            string idusuario = HttpContext.Session.GetString("idusuario");

            if (id==null)
            {
                id=Request.Query["id"]; // localhost/Comentario/Leer/?id=5
            }
            Comentario modelo=null;
            try { 

                modelo=comentarioRepo.ObtenerPorId(Int32.Parse(id));
                if(modelo==null)
                {
                    ViewBag.error="Comentario no encontrado";
                }
            } catch(Exception ex)
            {
                ViewBag.error=ex.Message;
            }
            if(modelo!=null && modelo.IdUsuario!=idusuario)
            {
                modelo=null;
                ViewBag.error="No tiene permiso para hacer la operacion";
            }
            
            if(modelo==null) {
                modelo=new Comentario();
            }
            ViewBag.categorias = categoriaRepo.ListarTodo();
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Insertar()
        {           
            Comentario modelo=new Comentario();
            ViewBag.categorias= categoriaRepo.ListarTodo();

            return View(modelo);
        }
        [HttpPost]
        public IActionResult Insertar(Comentario modelo)
        {
            try
            {
                string idusuario = HttpContext.Session.GetString("idusuario");
                modelo.IdUsuario=idusuario;

                modelo = comentarioRepo.Insertar(modelo);

                //return Redirect("comentario/?id="+modelo.Id);
                return Redirect("/Comentario/Listar/" + modelo.Id+"?titulo="+modelo.Titulo);

            } catch(Exception ex)
            {
                ViewBag.error=ex.Message;
                ViewBag.categorias = categoriaRepo.ListarTodo();
                return View(modelo);
            }

            
        }

    }
}
