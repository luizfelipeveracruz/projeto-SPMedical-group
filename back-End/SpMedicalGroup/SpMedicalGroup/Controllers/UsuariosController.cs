using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.Domains;
using SpMedicalGroup.Interfaces;
using SpMedicalGroup.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>uma lista de usuarios</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_UsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="IdUsuario">id da usuario a ser procurada</param>
        /// <returns>Uma usuario</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int IdUsuario)
        {
            try
            {
                Usuario usuarioBuscada = _UsuarioRepository.BuscarPorId(IdUsuario);

                if (usuarioBuscada != null)
                {
                    return Ok(usuarioBuscada);
                }

                return BadRequest("O usuario requisitado não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="NovoUsuario">Objeto usuario com os atributos a serem cadastrados</param>
        /// <returns>Status code 201 created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(NovoUsuario);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <param name="IdUsuario">Id do usuario a ser buscado</param>
        /// <param name="UsuarioAtualizado">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int IdUsuario, Usuario UsuarioAtualizado)
        {
            try
            {
                _UsuarioRepository.Atualizar(IdUsuario, UsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Exclui um usuario
        /// </summary>
        /// <param name="IdUsuario">Id do usuario a ser buscado</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int IdUsuario)
        {
            try
            {
                _UsuarioRepository.Deletar(IdUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
