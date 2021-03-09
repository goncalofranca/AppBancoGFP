using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AppBanco.Library.Geral;


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
        public Guid Numero { get; } = Guid.NewGuid();

        [DataType(DataType.Currency)]
        public decimal Saldo { get; private set; }
        public Cliente Cliente { get; set; }
        public CartaoCredito CartaoCredito { get; set; }
        public CartaoDebito CartaoDebito { get; set; }
        private IList<Transacao> Transacoes { get; } = new List<Transacao>();

        /// <summary>
        ///  Faz a Abertura de Conta caso tenha no minimo o valor na constante
        /// </summary>
        /// <param name="aCliente"> Cliente onde vai ficar a conta</param>
        /// <param name="aDeposito"> valor a depositar na abertura</param>
        /// <returns>Conta Bancaria Aberta</returns>
        public ContaBancaria AbrirContaBancaria(Cliente aCliente, decimal aDeposito)
        {
            if(aDeposito < Helpers._MINIMUM_ABERTURA_CONTA_)
            {
                return null;
            }
            else
            {

                var cb = new ContaBancaria() {
                    Cliente = aCliente
                };

                cb.AdicionarTransacao(aDeposito, ESignal.In, this);
                return cb;
            }
        }

        /// <summary>
        ///  Efetua um levantamento
        /// </summary>
        /// deve registar uma transação
        /// <param name="aValue"> valor a levantar</param>
        public void Levantar(decimal aValue)
        {
            if(aValue <= 0)
            {
                return;
            }

            if(aValue <= Saldo)
            {
                Saldo -= aValue;
                AdicionarTransacao(aValue, ESignal.Out, this);
            }

        }

        /// <summary>
        /// Efetua um deposito
        /// </summary>
        /// deve registar uma transação
        /// <param name="aValue">montante a depositar</param>
        public void Depositar(decimal aValue)
        {

            if(aValue <= 0)
            {
                return;
            }
            else
            {
                Saldo += aValue;
                AdicionarTransacao(aValue, ESignal.Out, this);
            }
        }

        public IList<Transacao> ObtemTransacoes() => Transacoes;


        public void AdicionarTransacao(decimal aValor, ESignal aSignal, ContaBancaria aConta)
        {
            Transacoes.Add(new Transacao() {
                Valor = aValor,
                Sinal = aSignal,
                Conta = aConta
            });

        }
    }
}