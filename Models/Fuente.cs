using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class Fuente
    {
        public Fuente()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Idpais { get; set; }

        public virtual Pai IdpaisNavigation { get; set; }
        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
