using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.repo
{
    public class UsuarioRepo
    {
        public Usuario ObtenerPorId(string id)
        {
            var resultado = new Usuario();
            using (var contexto = new DbChatContext())
            {
                resultado = contexto.Usuarios.Find(id);
            }
            return resultado;
        }
    }
}
