using System.ComponentModel.DataAnnotations;

namespace AppBanco.Library.Geral.Annotations
{
    public class PINValidator : ValidationAttribute
    {
        private readonly int _pinLengh;
        private readonly string _msg;
        public PINValidator(int DigitosPin, string ErrorMessage)
        {
            _pinLengh = DigitosPin;
            _msg = ErrorMessage;
        }
        public override bool IsValid(object value) =>
            // se o valor for vazio retorna false
            // se o tryparse der false retorna false
            // se o tryparse retorna true retorna false se nao o tamanho nao for o mesmo que passa no parametro
            string.IsNullOrWhiteSpace(value.ToString())
                ? false
                : int.TryParse(value.ToString(), out var _) && value.ToString().Length == _pinLengh;

    }

}
