using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBank_LM.Data;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys.Interfaces;
using DigitalBank_LM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank_LM.Repositorys
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly Context _context;
        public ContaBancariaRepository(Context context) => _context = context;

        public async Task<List<ContaBancaria>> GetAll() => await _context.ContaBancarias.ToListAsync();

        public async Task<ContaBancaria> GetByCpf(string cpf) => await
            (from conta in _context.ContaBancarias
             join cliente in _context.Clientes.Where(a => a.Cpf == cpf) on conta.Id_Client equals cliente.Id_Client
             select conta).FirstOrDefaultAsync();

        public async Task Add(ContaBancaria contaBancaria)
        {
            await _context.ContaBancarias.AddAsync(contaBancaria);
            await _context.SaveChangesAsync();
        }
    }
}
