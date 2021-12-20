using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.Interfaces;
using SpMedicalGroup.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultaController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_ConsultaRepository.ListarTodas());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpGet("Medico")]
        public IActionResult ListarMinhasMedico()
        {
            try
            {
                int idMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_ConsultaRepository.ListarMinhasMedico(idMedico));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        [HttpGet("/Paciente")]
        public IActionResult ListarMinhasPaciente()
        {
            try
            {
                int idPaciente = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_ConsultaRepository.ListarMinhasPaciente(idPaciente));
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
