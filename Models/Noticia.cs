using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class Noticia
    {
        public Noticia()
        {
            AutorEscribeNots = new HashSet<AutorEscribeNot>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Urlnoticia { get; set; }
        public int? Idcat { get; set; }
        public int? Idpais { get; set; }
        public int? Idfuente { get; set; }

        public virtual Categorium IdcatNavigation { get; set; }
        public virtual Fuente IdfuenteNavigation { get; set; }
        public virtual Pai IdpaisNavigation { get; set; }
        public virtual ICollection<AutorEscribeNot> AutorEscribeNots { get; set; }
    }
}
