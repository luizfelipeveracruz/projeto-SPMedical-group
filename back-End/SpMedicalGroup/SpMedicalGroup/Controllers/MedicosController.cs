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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>uma lista de medicos</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_MedicoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um medico pelo id
        /// </summary>
        /// <param name="IdMedico">id do medico a ser procurado</param>
        /// <returns>Um medico</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int IdMedico)
        {
            try
            {
                Medico medicoBuscado = _MedicoRepository.BuscarPorId(IdMedico);

                if (medicoBuscado != null)
                {
                    return Ok(medicoBuscado);
                }

                return BadRequest("O medico requisitado não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="NovoMedico">Objeto medico com os atributos a serem cadastrados</param>
        /// <returns>Status code 201 created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Medico NovoMedico)
        {
            try
            {
                _MedicoRepository.Cadastrar(NovoMedico);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um medico
        /// </summary>
        /// <param name="IdMedico">Id do medico a ser buscado</param>
        /// <param name="MedicoAtualizado">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int IdMedico, Medico MedicoAtualizado)
        {
            try
            {
                _MedicoRepository.Atualizar(IdMedico, MedicoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Exclui um medico
        /// </summary>
        /// <param name="IdMedico">Id do medico a ser buscado</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int IdMedico)
        {
            try
            {
                _MedicoRepository.Deletar(IdMedico);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



    }
}
