using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AppBanco.Library.Geral;
using AppBanco.Library.Geral.Annotations;

namespace AppBanco.Library.Models
{
    /// <summary>
    /// Representa os Cartoes
    /// 1 cartao tem um aconta associada e um conta pode ter varios cartoes
    ///
    /// </summary>
    [Table("tblCartoes")]
    public class Cartao : ICartao
    {
        [Key]
        public int CartaoID { get; set; }
        [PINValidator(4, "PIN deve conter apenas 4 digitos")]
        public int PIN { get; set; }
        public ETipoCartao TipoCartao { get; internal set; }
        public ContaBancaria Conta { get; set; }

    }
}