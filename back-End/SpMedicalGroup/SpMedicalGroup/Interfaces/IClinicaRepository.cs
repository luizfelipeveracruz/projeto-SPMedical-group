using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IClinicaRepository
    {

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>Uma lista de clinicas</returns>
        List<Clinica> ListarTodos();

        /// <summary>
        /// Busca uma clinica pelo id
        /// </summary>
        /// <param name="IdClinica">id da clinica a ser buscada</param>
        /// <returns>Uma clinica</returns>
        Clinica BuscarPorId(int IdClinica);

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="NovaClinica">Objeto clinica com atributos a serem cadastrados</param>
        void Cadastrar(Clinica NovaClinica);

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="IdClinica">id da clinica a ser buscada</param>
        /// <param name="ClinicaAtualizada">Objeto clinica com atributos a serem atualizados</param>
        void Atualizar(int IdClinica, Clinica ClinicaAtualizada);

        /// <summary>
        /// Exclui uma clinica
        /// </summary>
        /// <param name="IdClinica">id da clinica a ser buscada</param>
        void Deletar(int IdClinica);
    }
}
