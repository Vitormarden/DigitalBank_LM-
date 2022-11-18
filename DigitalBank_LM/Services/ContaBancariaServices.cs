using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DigitalBank_LM.Dto;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys.Interfaces;
using DigitalBank_LM.Services.Interfaces;

namespace DigitalBank_LM.Services
{
    public class ContaBancariaServices : IContaBancariaServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IClienteRepository _clienteRepository;
        public ContaBancariaServices(IContaBancariaRepository contaBancariaRepository, IClienteRepository clienteRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _clienteRepository = clienteRepository;
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

    }

}
