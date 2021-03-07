namespace AppBanco.Library.Models
{
    public interface ICartao
    {
        int CartaoID { get; set; }

        int PIN { get; set; }

        ContaBancaria Conta { get; set; }

    }
}