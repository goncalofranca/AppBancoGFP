using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AppBanco.Library.Geral;

namespace AppBanco.Library.Models
{
  

    [Table("tblTransacoes")]
    public class Transacao
    {

        [Required]
        public Guid Hash = Guid.NewGuid();

        [Key]
        public int TransacaoID { get; set; } // PK
        public ESignal Sinal { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataTransacao { get; } = DateTime.UtcNow;

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        //Relação
        public ContaBancaria Conta { get; set; }
        public int ContaID { get; set; } // FK 

    }
}