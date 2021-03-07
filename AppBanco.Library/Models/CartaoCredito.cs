
using AppBanco.Library.Geral;

namespace AppBanco.Library.Models
{
    public class CartaoCredito : Cartao
    {
        public CartaoCredito() => TipoCartao = ETipoCartao.Crédito;
    }
}
