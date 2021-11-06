using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication7.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
