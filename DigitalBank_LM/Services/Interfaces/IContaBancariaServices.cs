using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Dto;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Services.Interfaces
{
    public interface IContaBancariaServices
    {
        Task<ContaBancariaDto> GetByCpf(string cpf);
        Task<List<ContaBancaria>> GetAll();
        Task<bool> Add(string cpf);
        
    }
}
