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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _PacienteRepository { get; set; }
        public PacientesController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>uma lista de pacientes</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_PacienteRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Busca um paciente pelo id
        /// </summary>
        /// <param name="IdPaciente">id do paciente a ser procurado</param>
        /// <returns>Um paciente</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int IdPaciente)
        {
            try
            {
                Paciente PacienteBuscado = _PacienteRepository.BuscarPorId(IdPaciente);

                if (PacienteBuscado != null)
                {
                    return Ok(PacienteBuscado);
                }

                return BadRequest("O paciente requisitado não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="NovoPaciente">Objeto paciente com os atributos a serem cadastrados</param>
        /// <returns>Status code 201 created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Paciente NovoPaciente)
        {
            try
            {
                _PacienteRepository.Cadastrar(NovoPaciente);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="IdPaciente">Id do paciente a ser buscado</param>
        /// <param name="PacienteAtualizado">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idPaciente}")]
        public IActionResult Atualizar(int IdPaciente, Paciente PacienteAtualizado)
        {
            try
            {
                _PacienteRepository.Atualizar(IdPaciente, PacienteAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Exclui um paciente
        /// </summary>
        /// <param name="IdPaciente">Id do paciente a ser buscado</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int IdPaciente)
        {
            try
            {
                _PacienteRepository.Deletar(IdPaciente);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
