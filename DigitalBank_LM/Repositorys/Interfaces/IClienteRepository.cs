using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Repositorys.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Add (Cliente cliente); 
        Task Update (Cliente cliente);
        Task Delete (int id);

    }
}
