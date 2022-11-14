using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Services.Interfaces
{
    public interface IClienteServices
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task <bool> Add(Cliente cliente);
        Task <bool>Update(Cliente cliente);
        Task <bool>Delete(int id);

    }
}
