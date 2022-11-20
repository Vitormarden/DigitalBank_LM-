using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DigitalBank_LM.Models
{
    [Table("ContaBancaria")]
    public class ContaBancaria
    {
        [Key]
        public int Number_Account { get; set; }

        [ForeignKey("Cliente")]
        public int Id_Client { get; set; }

        public Cliente Cliente { get; set; }

        public int Saldo { get; set; }
    }
}
