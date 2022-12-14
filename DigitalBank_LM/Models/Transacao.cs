using System;
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

        [StringLength(30)]
        public string Type_Transaction { get; set; }

        public decimal Value_Transaction { get; set; }

        public DateTime Date_Transaction { get; set; }

        public Transacao(int number_Account, string type_Transaction, decimal value_Transaction)
        {
            Number_Account = number_Account;
            Type_Transaction = type_Transaction;
            Value_Transaction = value_Transaction;
            Date_Transaction =  DateTime.Now;
        }
    }
}
