using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Uma lista de paciente</returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um paciente pelo id
        /// </summary>
        /// <param name="IdPaciente">id do paciente a ser buscado</param>
        /// <returns>Um paciente</returns>
        Paciente BuscarPorId(int IdPaciente);

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="NovoPaciente">Objeto paciente com atributos a serem cadastrados</param>
        void Cadastrar(Paciente NovoPaciente);

        /// <summary>
        /// Atualiza um paciente existente
        /// </summary>
        /// <param name="IdPaciente">id do paciente a ser buscado</param>
        /// <param name="PacienteAtualizado">Objeto paciente com atributos a serem atualizados</param>
        void Atualizar(int IdPaciente, Paciente PacienteAtualizado);

        /// <summary>
        /// Exclui um paciente
        /// </summary>
        /// <param name="IdPaciente">id do paciente a ser buscado</param>
        void Deletar(int IdPaciente);
    }
}
