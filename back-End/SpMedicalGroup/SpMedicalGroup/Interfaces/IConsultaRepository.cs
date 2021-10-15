using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Listar todas as cosultas
        /// </summary>
        /// <returns>Lista com todas as consultas</returns>
        List<Consultum> ListarTodas();

        /// <summary>
        /// Buscar uma consulta pelo id
        /// </summary>
        /// <param name="IdConsulta">id da consulta a ser procurado</param>
        /// <returns>Consulta encontrada</returns>
        Consultum BuscarPorId(int IdConsulta);

        /// <summary>
        /// Cria uma nova consulta
        /// </summary>
        /// <param name="NovaConsulta">Objeto consulta com os atributos a serem cadastrados</param>
        void Cadastrar(Consultum NovaConsulta);

        /// <summary>
        /// Atualiza uma Consulta pelo id
        /// </summary>
        /// <param name="IdConsulta">Id da consulta a ser atualizada</param>
        /// <param name="ConsultaAtualizada">objeto com atributos a serem atuzalizados da consulta</param>
        void Atualizar(int IdConsulta, Consultum ConsultaAtualizada);

        /// <summary>
        /// Exclui uma consulta
        /// </summary>
        /// <param name="IdConsulta">id da consulta a ser excluida</param>
        void Deletar(int IdConsulta);

        /// <summary>
        /// Lista todos os eventos de um determinado usuário
        /// </summary>
        /// <param name="IdUsuario">Id do usuário que participa dos eventos</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Consultum> ListarMinhas(int IdUsuario);


        /// <summary>
        /// Adiciona descrição a uma consulta existente
        /// </summary>
        /// <param name="IdConsulta">id da consulta a ter a descrição atualizada</param>
        /// <param name="ConsultaComDescricao">objeto com atributo descrição</param>
        void AdicionarDecrição(int IdConsulta, Consultum ConsultaComDescricao);

        /// <summary>
        /// Cancela uma determinada consulta
        /// </summary>
        /// <param name="IdConsulta">id da consulta a ser cancelada</param>
        /// <param name="status">status da consulta</param>
        void Cancela(int IdConsulta, string status);
    }
}
