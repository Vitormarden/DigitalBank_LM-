using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBank_LM.Data;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank_LM.Repositorys
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly Context _context;
        
        public TransacaoRepository(Context context) => _context = context;
        
        public async Task Add(Transacao transacao)
        {
            await _context.Transacaos.AddAsync(transacao);
            await _context.SaveChangesAsync();
        }

        //public async Task<List<Transacao>> TodasTransacoesDaConta() => await _context.Transacaos.ToListAsync();
        public async Task<List<Transacao>> GetExtratoByNumeroConta(int numeroContaBancaria)
        {
            var listaTransacoes = await _context.Transacaos.Where(t => t.Number_Account == numeroContaBancaria).ToListAsync();
            return listaTransacoes;
        }


    }
}
