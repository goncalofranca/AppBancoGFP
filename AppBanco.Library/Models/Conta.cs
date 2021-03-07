using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBanco.Library.Models
{
    /// <summary>
    /// Represneta as contas
    /// uma conta pode ter varios cartoes 
    /// uma conta pode ter varias contas
    /// </summary>
    [Table("tblContasBancarias")]
    public class ContaBancaria
    {
        [Key]
        public int ContaID { get; set; } // PK

        [Required]
        public Guid Numero { get; set; } = Guid.NewGuid();

        [DataType(DataType.Currency)]
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public CartaoCredito CartaoCredito { get; set; }
        public CartaoDebito CartaoDebito { get; set; }
        public IList<Transacao> Transacoes { get; set; }


    }
}