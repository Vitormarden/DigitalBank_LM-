using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys.Interfaces;
using DigitalBank_LM.Services.Interfaces;

namespace DigitalBank_LM.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }
        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }
        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);                            
        }
        public async Task <bool>Add(Cliente cliente)
        {
            if (cliente.Idade >= 18)
            {
               await _clienteRepository.Add(cliente);
                return true; 
            }
            return false;
        }
        
         
        public async Task<bool> Update(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _clienteRepository.Delete(id);
            return true;
        }
    }
}
