
using AppBanco.Library.Geral;

namespace AppBanco.Library.Models
{
    public class CartaoDebito : Cartao
    {
        public CartaoDebito() => TipoCartao = ETipoCartao.Débito;
    }
}