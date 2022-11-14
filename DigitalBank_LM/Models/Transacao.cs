using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank_LM.Models
{
    [Table("Transaca")]
    public class Transacao
    {
        public int Id_Transaction { get; set; }
        public int Number_Account { get; set; }
        public  string Type_Transaction {  get; set; }
        public int Value_Transaction { get; set; }
        public int Date_Transaction { get; set; }

    }
}
