using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication7.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public string IdUsuario { get; set; }
        public string Clave { get; set; }
        public string NombreCompleto { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
