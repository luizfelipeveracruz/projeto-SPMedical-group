using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacao { get; set; }
        public string Situacao1 { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
