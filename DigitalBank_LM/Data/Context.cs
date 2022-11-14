using DigitalBank_LM.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank_LM.Data
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> ContaBancarias { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MARDONHA-NOT;Initial Catalog=DigitalBnak;Integrated Security=True");
        }
    }
}
