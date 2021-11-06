using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.repo
{
    public class ComentarioRepo
    {
        public List<Comentario> ListarTodo()
        {
            var resultado=new List<Comentario>();
            using(var contexto=new DbChatContext())
            {
                resultado=contexto.Comentarios
                    .Include(c=>c.IdCategoriaNavigation)
                    .Include(c => c.IdUsuarioNavigation)
                    .ToList();
            }
            return resultado;
        }
        public Comentario ObtenerPorId(int id)
        {
            var resultado=new Comentario();
            using (var contexto = new DbChatContext())
            {
                resultado = contexto.Comentarios.Find(id);
            }
            return resultado;
        }
        public Comentario Insertar(Comentario com)
        {
            using (var contexto = new DbChatContext())
            {
                contexto.Comentarios.Add(com);
                contexto.SaveChanges();
            }
            return com;
        }
    }
}
