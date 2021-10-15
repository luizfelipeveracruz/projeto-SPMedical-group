using Microsoft.AspNetCore.Http;
using SpMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário 
        /// </summary>
        /// <param name="Email">E-mail do usuário</param>
        /// <param name="Senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi encontrado</returns>
        Usuario Login(string Email, string Senha);

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="IdUsuario">id do usuario a ser buscado</param>
        /// <returns>Um usuario</returns>
        Usuario BuscarPorId(int IdUsuario);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto usuario com atributos a serem cadastrados</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="IdUsuario">id da usuario a ser buscado</param>
        /// <param name="UsuarioAtualizado">Objeto usuario com atributos a serem atualizados</param>
        void Atualizar(int IdUsuario, Usuario UsuarioAtualizado);

        /// <summary>
        /// Exclui um usuario
        /// </summary>
        /// <param name="IdUsuario">id da usuario a ser buscada</param>
        void Deletar(int IdUsuario);

        void SalvarPerfilDir(IFormFile foto, int IdUsuario);

        string ConsultarPerfilDir(int IdUsuario);
    }
}
