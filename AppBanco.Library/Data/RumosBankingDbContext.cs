
using AppBanco.Library.Models;

using Microsoft.EntityFrameworkCore;

namespace AppBanco.Library.Data
{
    public class RumosBankingDbContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<ContaBancaria> Contas { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _ctxConnectionString = @"SERVER=(localdb)\MSSQLLocalDB; DATABASE=RumosBankingDB; TRUSTED_CONNECTION=True;";
            _ = optionsBuilder.UseSqlServer(_ctxConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*
            
            var cliente = new Cliente() {
                ClienteID = 1,
                Nome = "Gonçalo",
                Apelido = "Pereira",
                DataNascimento = new DateTime(1994, 09, 28),
                NIF = "249884933"
            };

            var cartao = new Cartao() {
                CartaoID = 1,
                PIN = 1234,
                TipoCartao = Geral.ETipoCartao.Crédito
            };
            var conta = new Conta() {
                ContaID = 1,
                Saldo = 0,                
            };
            //adciono cartoes a conta
            conta.Cartoes.Add(cartao);

            //adiciono conta ao cliente
            cliente.Contas.Add(conta);

            //adiciono cliente (titular) a Conta
            conta.Titulares.Add(cliente);
           
          

           */

            /*
            //Seed cartao
            modelBuilder.Entity<Cartao>().HasData(cartao);
            
            //Seed conta
            modelBuilder.Entity<Conta>().HasData(conta);
            */
            /*
            //Seed Cliente
            modelBuilder.Entity<Cliente>().HasData(cliente);
            */

        }
    }
}
