using SpMedicalGroup.Context;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        spMedicalContext ctx = new spMedicalContext();

        public void Atualizar(int IdClinica, Clinica ClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPorId(IdClinica);

            if (ClinicaAtualizada.Endereco != null && ClinicaAtualizada.NomeFantasia != null && ClinicaAtualizada.Cnpj != null && ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.Endereco = ClinicaAtualizada.Endereco;
                ClinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int IdClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == IdClinica);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            ctx.Clinicas.Add(NovaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int IdClinica)
        {
            Clinica ClinicaBuscada = BuscarPorId(IdClinica);

            ctx.Clinicas.Remove(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
