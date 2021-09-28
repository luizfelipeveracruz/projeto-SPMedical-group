using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.Domains
{
    public partial class Especializacao
    {
        public Especializacao()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecializacao { get; set; }
        public string TipoEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
