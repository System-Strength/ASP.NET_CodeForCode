using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string nm_usu { get; set; }

        [DisplayName("Telefone:")]
        public string tel_usu { get; set; }

        [DisplayName("E-mail:")]
        public string email_usu { get; set; }
    }
}
