using System.Threading.Tasks;
using DigitalBank_LM.Models;
using DigitalBank_LM.Services;
using DigitalBank_LM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank_LM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaServices _contaBancariaServices;
        public ContaBancariaController(IContaBancariaServices contaBancariaServices)
        {
           _contaBancariaServices = contaBancariaServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaContaBancaria = await _contaBancariaServices.GetAll();
            return Ok(listaContaBancaria);
        }

        [HttpGet("{Cpf}")]
        public async Task<IActionResult>GetByCpf(string Cpf)
        {
            var contaByCpf = await _contaBancariaServices.GetByCpf(Cpf);
            return Ok(contaByCpf);
        }

        [HttpPost]

        public async Task<IActionResult> Add(string  cpf)
        {
            try
            {
                var adcionarContaBancaria = await _contaBancariaServices.Add(cpf);
                return Created("Conta criada", adcionarContaBancaria);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao criar conta {e.Message}");
            }
            
        }

    }

       
    
}
