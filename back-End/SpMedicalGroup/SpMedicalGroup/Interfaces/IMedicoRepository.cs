using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os médicos
        /// </summary>
        /// <returns>Uma lista de médico</returns>
        List<Medico> ListarTodos();

        /// <summary>
        /// Busca um médico pelo id
        /// </summary>
        /// <param name="IdMedico">id do médico a ser buscado</param>
        /// <returns>Uma médico</returns>
        Medico BuscarPorId(int IdMedico);

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="NovoMedico">Objeto médico com atributos a serem cadastrados</param>
        void Cadastrar(Medico NovoMedico);

        /// <summary>
        /// Atualiza um médico existente
        /// </summary>
        /// <param name="IdMedico">id do medico a ser buscado</param>
        /// <param name="MedicoAtualizado">Objeto médico com atributos a serem atualizados</param>
        void Atualizar(int IdMedico, Medico MedicoAtualizado);

        /// <summary>
        /// Exclui um médico
        /// </summary>
        /// <param name="IdMedico">id do médico a ser buscado</param>
        void Deletar(int IdMedico);
    }
}
