using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Dto;
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
            try
            {
                var listaContaBancaria = await _contaBancariaServices.GetAll();
                return Ok(listaContaBancaria);
            }
            catch (System.Exception e)
            {

                return BadRequest($"Erro ao buscar contas {e.Message}");
            }

        }

        [HttpGet("{Cpf}")]
        public async Task<IActionResult> GetByCpf(string Cpf)
        {
            try
            {
                var contaByCpf = await _contaBancariaServices.GetByCpf(Cpf);
                return Ok(contaByCpf);
            }
            catch (System.Exception e)
            {

                return BadRequest($"Erro ao buscar conta por Cpf {e.Message}");
            }

        }

        [HttpGet("Extrato")]
        public async Task<IActionResult> GetByExtratoNumeroDaConta([FromBody] int numeroContaBancaria)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var listTransacoes = await _contaBancariaServices.GetByExtratoNumeroDaConta(numeroContaBancaria);
                if (listTransacoes == null)
                    return BadRequest("esta conta não existe");
                return Ok(listTransacoes);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao tentar solicitar extraro {e.Message}");
            }
        }

        [HttpPost]

        public async Task<IActionResult> Add(string cpf)
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

        [HttpPut("Debitar")]
        public async Task<IActionResult> Debitar([FromBody] DadosTransacaoSimplesDto dadosTransacaoSimplesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("é preciso ser pelo menos 01");

                await _contaBancariaServices.Debitar(dadosTransacaoSimplesDto);
                return Created("Debito realizado", null);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao tentar debitar {e.Message}");
            }
        }

        [HttpPost("Depositar")]
        public async Task<IActionResult> Depositar([FromBody] DadosTransacaoSimplesDto dadosTransacaoSimplesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _contaBancariaServices.Depositar(dadosTransacaoSimplesDto);
                return Created("Deposito realizado com sucesso", null);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao tentar depositar {e.Message}");
            }
        }

        [HttpPut("Transferencia")]
        public async Task<IActionResult> Transferencia([FromBody] DadosTransferenciaDto dadosTransferenciasDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _contaBancariaServices.Transferencia(dadosTransferenciasDto);
                return Created("Transfência enviada", null);
            }
            catch (System.Exception e)
            {
                return BadRequest($"Erro ao tentar transferir dinheiro {e.Message}");
            }
        }
    }
}
