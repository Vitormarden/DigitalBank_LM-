using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalBank_LM.Models;

namespace DigitalBank_LM.Repositorys.Interfaces
{
    public interface ITransacaoRepository
    {
        Task Add(Transacao transacao);
        Task<List<Transacao>> GetExtratoByNumeroConta(int numeroContaBancaria);
        //Task<List<Transacao>> TodasTransacoesDaConta();
    }
}
