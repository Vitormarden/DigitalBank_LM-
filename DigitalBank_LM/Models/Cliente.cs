using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank_LM.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id_Client { get; set; }
        public string ClientNo { get; set; }   
        public string Cpf { get; set; }
        public int Idade { get; set; }

    }
}
