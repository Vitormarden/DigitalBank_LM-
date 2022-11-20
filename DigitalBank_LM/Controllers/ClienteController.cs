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
        public ClienteController(IClienteServices clienteServices) => _clienteServices = clienteServices;
        /// <summary>
        /// Buscar todos os clientes cadastrados
        /// </summary>
        /// <returns> Retorna lista de cliente, se não tiver cliente cadastrado retorna uma lista vazia</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listCliente = await _clienteServices.GetAll();
                return Ok(listCliente);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao buscar clientes {e.Message}");
            }
        }
        /// <summary>
        /// Busca cliente por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna cliente do id escolhido</returns>
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            var clienteById = await _clienteServices.GetById(id);
            if (clienteById != null)
                return Ok(clienteById);
            return NotFound();
        }
        /// <summary>
        /// Cadastra cliente no banco de dados
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns> Sem retorno</returns>
        [HttpPost]
        public async Task<IActionResult> Add(Cliente cliente)
        {
            try
            {
                var clienteAdcionar = await _clienteServices.Add(cliente);
                return Created("Cliente cadastado", clienteAdcionar);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao criar conta{e.Message}");
            }

        }
        /// <summary>
        /// Atualiza os dados de um cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Sem retorno</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            try
            {
                await _clienteServices.Update(cliente);
                return NoContent();
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao tentar atualizaar dados do cliente {e.Message}");
            }
        }
        /// <summary>
        /// Apaga um cliente pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>não tem retorno</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clienteDeletar = await _clienteServices.Delete(id);
                return Ok(clienteDeletar);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao Deletar, Id inserido não pe válido {e.Message}");
            }
        }
    }
}
