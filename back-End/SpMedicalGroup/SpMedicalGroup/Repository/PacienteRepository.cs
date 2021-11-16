using SpMedicalGroup.Context;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Repository
{
    public class PacienteRepository : IPacienteRepository

    {
        spMedicalContext ctx = new spMedicalContext();

        public void Atualizar(int IdPaciente, Paciente PacienteAtualizado)
        {
            Paciente pacienteBuscado = BuscarPorId(IdPaciente);

            if (PacienteAtualizado.IdUsuario != null && PacienteAtualizado.Endereco != null && PacienteAtualizado.NomePaciente != null && PacienteAtualizado.DataNascimento != null && PacienteAtualizado.Telefone != null && PacienteAtualizado.Rg != null && PacienteAtualizado.Cpf != null)
            {
                pacienteBuscado.IdUsuario = PacienteAtualizado.IdUsuario;
                pacienteBuscado.Endereco = PacienteAtualizado.Endereco;
                pacienteBuscado.NomePaciente = PacienteAtualizado.NomePaciente;
                pacienteBuscado.DataNascimento = PacienteAtualizado.DataNascimento;
                pacienteBuscado.Telefone = PacienteAtualizado.Telefone;
                pacienteBuscado.Rg = PacienteAtualizado.Rg;
                pacienteBuscado.Cpf = PacienteAtualizado.Cpf;
            }

            ctx.Update(pacienteBuscado);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int IdPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == IdPaciente);
        }

        public void Cadastrar(Paciente NovoPaciente)
        {
            ctx.Add(NovoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int IdPaciente)
        {
            Paciente PacienteBuscado = BuscarPorId(IdPaciente);

            ctx.Pacientes.Remove(PacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
