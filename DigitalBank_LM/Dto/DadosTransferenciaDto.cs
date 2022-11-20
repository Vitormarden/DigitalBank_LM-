using DataAnnotationsExtensions;

namespace DigitalBank_LM.Dto
{
    public class DadosTransferenciaDto
    {
        [Min(1, ErrorMessage = "Valor mínimo da conta é 1")]
        public int Number_Account_Origem { get; set; }

        [Min(1, ErrorMessage = "Valor mínimo da conta é 1")]
        public int Number_Account_Destino { get; set; }

        [Min(1, ErrorMessage = "Valor mínimo da transacão é 1")]
        public int Valor { get; set; }
    }
}
