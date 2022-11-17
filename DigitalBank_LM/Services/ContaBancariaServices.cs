using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        public async Task<ContaBancaria> GetByCpf(string cpf)
        {
            var contaBancaria = await _contaBancariaRepository.GetByCpf(cpf);
            return contaBancaria;
           
        }
    
        public async Task<bool> Add(ContaBancaria contaBancaria)
        {
            await _contaBancariaRepository.Add(contaBancaria);
            return true;
        }
    }
}
