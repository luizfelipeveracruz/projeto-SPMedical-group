using SpMedicalGroup.Context;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        spMedicalContext ctx = new();
        public void Atualizar(int IdMedico, Medico MedicoAtualizado)
        {
            Medico MedicoBuscado = BuscarPorId(IdMedico);

            if (MedicoAtualizado.IdUsuario != null && MedicoAtualizado.IdEspecializacao != null && MedicoAtualizado.IdClinica != null && MedicoAtualizado.NomeMedico != null && MedicoAtualizado.Crm != null)
            {
                MedicoBuscado.IdUsuario = MedicoAtualizado.IdUsuario;
                MedicoBuscado.IdEspecializacao = MedicoAtualizado.IdEspecializacao;
                MedicoBuscado.IdClinica = MedicoAtualizado.IdClinica;
                MedicoBuscado.NomeMedico = MedicoAtualizado.NomeMedico;
                MedicoBuscado.Crm = MedicoAtualizado.Crm;
            }

            ctx.Medicos.Update(MedicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int IdMedico)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == IdMedico);
        }

        public void Cadastrar(Medico NovoMedico)
        {
            ctx.Medicos.Add(NovoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int IdMedico)
        {
            Medico MedicoBuscado = BuscarPorId(IdMedico);

            ctx.Medicos.Remove(MedicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
