using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank_LM.Models
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int Id_Transaction { get; set; }

        [ForeignKey("ContaBancaria")]
        public int Number_Account { get; set; }

        public ContaBancaria ContaBancaria { get; set; }

        [StringLength(20)]
        public  string Type_Transaction {  get; set; }

        public int Value_Transaction { get; set; }

        public int Date_Transaction { get; set; }

    }
}
