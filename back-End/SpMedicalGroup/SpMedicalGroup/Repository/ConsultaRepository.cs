using SpMedicalGroup.Context;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        spMedicalContext ctx = new();

        public void AdicionarDecrição(int IdConsulta, Consultum ConsultaComDescricao)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsulta);

            if (ConsultaComDescricao.Descricao != null)
            {
                ConsultaBuscada.Descricao = ConsultaComDescricao.Descricao;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public void Atualizar(int IdConsulta, Consultum ConsultaAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsulta);

            if (ConsultaAtualizada.IdPaciente != null && ConsultaAtualizada.IdMedico != null && ConsultaAtualizada.IdSituacao != null && ConsultaAtualizada.DataConsulta != null)
            {
                ConsultaBuscada.IdPaciente = ConsultaAtualizada.IdPaciente;
                ConsultaBuscada.IdMedico = ConsultaAtualizada.IdMedico;
                ConsultaBuscada.IdSituacao = ConsultaAtualizada.IdSituacao;
                ConsultaBuscada.DataConsulta = ConsultaAtualizada.DataConsulta;
            }

            ctx.Consulta.Update(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int IdConsulta)
        {
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == IdConsulta);
        }

        public void Cadastrar(Consultum NovaConsulta)
        {
            ctx.Consulta.Add(NovaConsulta);

            ctx.SaveChanges();
        }

        public void Cancela(int IdConsulta, string status)
        {

            Consultum ConsultaMudar = BuscarPorId(IdConsulta);

            switch (status)
            {
                case "1":
                    ConsultaMudar.IdSituacao = 1;
                    break;

                case "2":
                    ConsultaMudar.IdSituacao = 2;
                    break;

                case "3":
                    ConsultaMudar.IdSituacao = 3;
                    break;

                default:
                    ConsultaMudar.IdSituacao = ConsultaMudar.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(ConsultaMudar);

            ctx.SaveChanges();
        }

        public void Deletar(int IdConsulta)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsulta);

            ctx.Consulta.Remove(ConsultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarTodas()
        {
            throw new NotImplementedException();
        }
    }
}
