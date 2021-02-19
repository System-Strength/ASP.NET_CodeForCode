using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Conta
    {
        [DisplayName("ID do Usuário:")]
        public int id_usu { get; set; }

        [DisplayName("Nome de Usúario")]
        [Required(ErrorMessage = "Obrigatório digitar o Nome de Usuário!")]
        public string user_login { get; set; }


        [DisplayName("RG")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Esse campo deve ter 9 caracteres!")]
        public string rg_usu { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Obrigatório digitar a Senha!")]
        public string senha_login { get; set; }

        [Compare("senha_login", ErrorMessage = "As senhas são diferentes!")]
        public string confirmaSenha { get; set; }
    }
}
