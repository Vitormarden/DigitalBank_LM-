using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank_LM.Models
{
    [Table("ContaBancaria")]
    public class ContaBancaria
    {
        public int Number_Account { get; set; }
        public int Id_Client { get; set; }
        public int Saldo { get; set; }
    }
}
