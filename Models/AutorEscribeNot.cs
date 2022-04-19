using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class AutorEscribeNot
    {
        public int Idautor { get; set; }
        public int Idnot2 { get; set; }

        public virtual Autor IdautorNavigation { get; set; }
        public virtual Noticia Idnot2Navigation { get; set; }
    }
}
