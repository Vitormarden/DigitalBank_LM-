using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace DigitalBank_LM.Dto
{
    public class DadosTransacaoSimplesDto
    {
        [Min(1, ErrorMessage = "Valor mínimo da conta é 1") ]
        public int Number_Account { get; set; }

        [Min(1, ErrorMessage = "Valor mínimo da transacão é 1")]
        public int Valor { get; set; }
    }
}
