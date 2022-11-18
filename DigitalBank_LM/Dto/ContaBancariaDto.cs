using DigitalBank_LM.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalBank_LM.Dto
{
    public class ContaBancariaDto
    {
        
        public int Number_Account { get; set; }

        public int Id_Client { get; set; }
       
        public int Saldo { get; set; }
    }
}
