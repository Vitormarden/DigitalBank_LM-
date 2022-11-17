using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Services.Interfaces
{
    public interface IContaBancariaServices
    {
        Task<ContaBancaria> GetByCpf(string cpf);
        Task<List<ContaBancaria>> GetAll();
        Task<bool> Add(ContaBancaria contaBancaria);
    }
}
