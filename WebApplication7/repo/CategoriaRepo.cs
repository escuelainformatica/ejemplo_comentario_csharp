using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.repo
{
    public class CategoriaRepo
    {
        public List<Categoria> ListarTodo()
        {
            var resultado = new List<Categoria>();
            using (var contexto = new DbChatContext())
            {
                resultado = contexto.Categorias.ToList();
            }
            return resultado;
        }
    }
}
