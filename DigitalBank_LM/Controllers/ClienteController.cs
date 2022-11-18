using System.Net.NetworkInformation;
using System.Threading.Tasks;
using DigitalBank_LM.Models;
using DigitalBank_LM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBank_LM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            this._clienteServices = clienteServices;
        }
        /// <summary>
        /// Buscar todos os clientes cadastrados
        /// </summary>
        /// <returns> Retorna lista de cliente, se não tiver cliente cadastrado retorna uma lista vazia</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listCliente = await _clienteServices.GetAll();
            return Ok(listCliente);
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var clienteById = await _clienteServices.GetById(id);
            if (clienteById != null)
            {
                return Ok(clienteById);

            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            var clienteAdcionar = await _clienteServices.Add(cliente);
            return Created("Cliente cadastado", clienteAdcionar);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            var clienteAtualizar =  await _clienteServices.Update(cliente);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0){
                return BadRequest("id passado é invalido");
            }
            var clienteDeletar = await _clienteServices.Delete( id);
            return Ok(clienteDeletar);
        }
    }
}
