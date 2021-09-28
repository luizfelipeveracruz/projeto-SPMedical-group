using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }
        public int? IdClinica { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecializacao { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especializacao IdEspecializacaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
