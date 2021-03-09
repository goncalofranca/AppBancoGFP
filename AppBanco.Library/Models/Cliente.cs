using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using AppBanco.Library.Geral;
using AppBanco.Library.Geral.Annotations;

namespace AppBanco.Library.Models
{
    /// <summary>
    ///  Representa todos Clientes
    ///  1 cliente tem uma conta que por sua vez pode ter varios cartoes , credito ou debito
    /// </summary>
    [Table("tblClientes")]
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; } // PK 

        [StringLength(20)]
        [Required]
        public string Nome { get; set; }


        [StringLength(20)]
        [Required]
        public string Apelido { get; set; }

        public string NomeCompleto => $"{Nome} {Apelido}";

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [DataType(DataType.PhoneNumber)]
           
        public string Telemovel { get; set; }

        [StringLength(15)]
        [Required]
        [NIFValidator("NIF Inválido")]
        public string NIF { get; set; } // podemos fazer a validação do NIF

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Relacoes
        public ContaBancaria Conta { get; set; }
        public IList<ContaBancaria> ContasBancarias { get; private set; } = new List<ContaBancaria>();

        /// <summary>
        /// Abre conta consoante o deposito que seja feito
        /// </summary>
        /// <param name="aDeposito">valor a depositar inicialmente</param>
        public void AbrirConta(decimal aDeposito)
        {
            if(ContasBancarias.Count > Helpers.__NR_MAX_CONTAS__)
            {
                throw new NrContasExceptions($"Chegou ao Número Maximo de Contas: {Helpers.__NR_MAX_CONTAS__}");
            }
            else
            {
                ContasBancarias.Add(Conta.AbrirContaBancaria(this, aDeposito));
            }
        }

    }


}
