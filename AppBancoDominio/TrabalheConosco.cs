using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class TrabalheConosco
    {
        [DisplayName("Código do Usuário:")]
        public int cd_usu { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "Obrigatório digitar o Nome!")]
        public string nm_usu { get; set; }

        [DisplayName("Telefone:")]
        [Required(ErrorMessage = "Obrigatório digitar um Número de Telefone!")]
        public string tel_usu { get; set; }

        [DisplayName("E-mail:")]
        [Required(ErrorMessage = "Obrigatório digitar seu e-mail!")]
        public string email_usu { get; set; }
    }
}
