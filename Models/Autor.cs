using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class Autor
    {
        public Autor()
        {
            AutorEscribeNots = new HashSet<AutorEscribeNot>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<AutorEscribeNot> AutorEscribeNots { get; set; }
    }
}
