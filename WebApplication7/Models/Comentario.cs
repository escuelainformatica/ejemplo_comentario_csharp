using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication7.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string IdUsuario { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
