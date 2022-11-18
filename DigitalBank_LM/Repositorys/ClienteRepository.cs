using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBank_LM.Data;
using DigitalBank_LM.Models;
using DigitalBank_LM.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank_LM.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Context _context;
        public ClienteRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Cliente>> GetAll() => await _context.Clientes.ToListAsync();
        public async Task<Cliente> GetById(int id) => await _context.Clientes.FirstOrDefaultAsync(c => c.Id_Client == id);
        public async Task Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _context.Clientes.Remove(await GetById(id));
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ClienteExiste(string cpf) => await _context.Clientes.AnyAsync(c => c.Cpf == cpf);

        public async Task<int> ClientId(string cpf) => await _context.Clientes.Select(c => c.Id_Client).FirstOrDefaultAsync();

        public async Task<Cliente> Cliente(string cpf) => await _context.Clientes.FirstOrDefaultAsync();
    }
}
