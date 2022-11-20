using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank_LM.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id_Client { get; set; }

        [StringLength(50)]
        public string ClientNo { get; set; }

        [StringLength(11)]
        public string Cpf { get; set; }
        public int Idade { get; set; }

    }
}
