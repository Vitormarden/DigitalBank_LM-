using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DigitalBank_LM.Dto;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys;
using DigitalBank_LM.Repositorys.Interfaces;
using DigitalBank_LM.Services.Interfaces;

namespace DigitalBank_LM.Services
{
    public class ContaBancariaServices : IContaBancariaServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        public ContaBancariaServices(IContaBancariaRepository contaBancariaRepository, IClienteRepository clienteRepository, ITransacaoRepository transacaoRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _clienteRepository = clienteRepository;
            _transacaoRepository = transacaoRepository;
        }
        public async Task<List<ContaBancaria>> GetAll() => await _contaBancariaRepository.GetAll();

        public async Task<ContaBancariaDto> GetByCpf(string cpf)
        {
            var contaBancaria = await _contaBancariaRepository.GetByCpf(cpf);
            return contaBancaria;
        }

        public async Task<bool> Add(string cpf)
        {
            var contaBancariaExiste = await _contaBancariaRepository.ContaBancariaExisteParaCliente(cpf);
            var cpfUso = await _clienteRepository.ClienteExiste(cpf);

            if (!cpfUso)
                throw new System.Exception("Para criar conta bancaria primeiro é preciso cadastrar cliente");

            if (contaBancariaExiste)
                throw new System.Exception("Cada cliente poderá ter apenas uma conta cadastrada");

            int id = _clienteRepository.ClientId(cpf).Result;
            try
            {
                await _contaBancariaRepository.Add(new ContaBancaria()
                {

                    Id_Client = id,

                });
                return true;
            }
            catch (System.Exception e)
            {

                throw e;
            }


        }
        public async Task Depositar(DadosTransacaoSimplesDto dadosTransacaoSimplesDto)
        {

            if (!_contaBancariaRepository.NumeroDaContaBancariaExiste(dadosTransacaoSimplesDto.Number_Account).Result)
                throw new Exception("Conta bancaria não localizada");

            var contaBancaria = await _contaBancariaRepository.GetByNumeroConta(dadosTransacaoSimplesDto.Number_Account);
            contaBancaria.Saldo += dadosTransacaoSimplesDto.Valor;
            await _contaBancariaRepository.Depositar(contaBancaria);

            var transacao = new Transacao(contaBancaria.Number_Account, "Deposito", dadosTransacaoSimplesDto.Valor);
            await _transacaoRepository.Add(transacao);
        }

        public async Task Debitar(DadosTransacaoSimplesDto dadosTransacaoSimplesDto)
        {
            // contaBancaria.Saldo <= dadosTransacaoSimplesDto.Valor;
            if (!_contaBancariaRepository.NumeroDaContaBancariaExiste(dadosTransacaoSimplesDto.Number_Account).Result)
                throw new Exception("Conta bancaria não localizada");

            if (_contaBancariaRepository.RetornarSaldo(dadosTransacaoSimplesDto.Number_Account).Result < dadosTransacaoSimplesDto.Valor)
                throw new Exception("Cliente não possui saldo suficiente");

            var contaBancaria = await _contaBancariaRepository.GetByNumeroConta(dadosTransacaoSimplesDto.Number_Account);
            

            contaBancaria.Saldo -= dadosTransacaoSimplesDto.Valor;
          
            await _contaBancariaRepository.Debitar(contaBancaria);

            var transacao = new Transacao(contaBancaria.Number_Account, "Debito", dadosTransacaoSimplesDto.Valor);
            await _transacaoRepository.Add(transacao);
           
        }

        public async Task Transferencia(DadosTransferenciaDto dadosTransferenciasDto)
        {

            if (_contaBancariaRepository.NumeroDaContaBancariaExiste(dadosTransferenciasDto.Number_Account_Destino).Result)
                throw new Exception("Número da conta de destinonão localizada");

            if (_contaBancariaRepository.NumeroDaContaBancariaExiste(dadosTransferenciasDto.Number_Account_Origem).Result)
                throw new Exception("Número da conta de origem não localizada");

            var contaOrigem = await _contaBancariaRepository.GetByNumeroConta(dadosTransferenciasDto.Number_Account_Origem);
            var contaDestino = await _contaBancariaRepository.GetByNumeroConta(dadosTransferenciasDto.Number_Account_Destino);

            if (contaOrigem.Saldo < dadosTransferenciasDto.Valor)
                throw new Exception("Saldo insuficiente");

            contaOrigem.Saldo -= dadosTransferenciasDto.Valor;
            contaDestino.Saldo += dadosTransferenciasDto.Valor;

            await _contaBancariaRepository.Transferencia(contaOrigem);
            var transacaoOrigem = new Transacao(contaOrigem.Number_Account, "Transferencia_enviada", dadosTransferenciasDto.Valor);
            await _transacaoRepository.Add(transacaoOrigem);

            await _contaBancariaRepository.Transferencia(contaDestino);
            var transacaoDestino = new Transacao(contaDestino.Number_Account, "Transferencia_recebida", dadosTransferenciasDto.Valor);
            await _transacaoRepository.Add(transacaoDestino);

        }

        public async Task GetByExtratoNumeroDaConta(int numeroContaBancaria)
        {
            if (_contaBancariaRepository.NumeroDaContaBancariaExiste(numeroContaBancaria).Result)
                throw new Exception("Número da conta de destinonão localizada");

             await _transacaoRepository.GetExtratoByNumeroConta(numeroContaBancaria);
        }
       
    }
}
