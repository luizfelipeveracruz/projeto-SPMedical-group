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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _ClinicaRepository { get; set; }

        public ClinicasController()
        {
            _ClinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as clinicas
        /// </summary>
        /// <returns>uma lista de clinicas</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodas()
        {
            try
            {
                return Ok(_ClinicaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca uma clinica pelo id
        /// </summary>
        /// <param name="IdClinica">id da clinica a ser procurada</param>
        /// <returns>Uma clinica</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId(int IdClinica)
        {
            try
            {
                Clinica clinicaBuscada = _ClinicaRepository.BuscarPorId(IdClinica);

                if (clinicaBuscada != null)
                {
                    return Ok(clinicaBuscada);
                }

                return BadRequest("A clinica requisitada não existe");

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="NovaClinica">Objeto clinica com os atributos a serem cadastrados</param>
        /// <returns>Status code 201 created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica NovaClinica)
        {
            try
            {
                _ClinicaRepository.Cadastrar(NovaClinica);

                return StatusCode(201);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza uma clinica
        /// </summary>
        /// <param name="IdClinica">Id da clinica a ser buscada</param>
        /// <param name="ClinicaAtualizada">Objeto com atributos a serem inseridos</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idClinica}")]
        public IActionResult Atualizar(int IdClinica, Clinica ClinicaAtualizada)
        {
            try
            {
                _ClinicaRepository.Atualizar(IdClinica, ClinicaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Exclui uma clinica
        /// </summary>
        /// <param name="IdClinica">Id da clinica a ser buscada</param>
        /// <returns>Status code 204 no content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int IdClinica)
        {
            try
            {
                _ClinicaRepository.Deletar(IdClinica);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
