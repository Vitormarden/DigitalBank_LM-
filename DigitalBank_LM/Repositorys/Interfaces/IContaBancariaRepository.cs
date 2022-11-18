using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Dto;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Repositorys.Interfaces
{
    public interface IContaBancariaRepository
    {
        Task<List<ContaBancaria>> GetAll();
        Task<ContaBancariaDto> GetByCpf(string cpf);
        Task Add(ContaBancaria contaBancaria);
        Task<bool> ContaBancariaExisteParaCliente(string cpf);

    }
}
