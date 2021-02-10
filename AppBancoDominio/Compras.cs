using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Compras
    {
        [DisplayName("Código da Compra:")]
        public int cd_compra { get; set; }

        [DisplayName("CPF do Usuário")]
        public string cpf_usu { get; set; }
        
        [DisplayName("Endereço do Usuário")]
        public string end_usu { get; set; }

        [DisplayName("Nº")]
        public int numCasa_usu { get; set; }

        [DisplayName("Bloco")]
        public string blocoApa_usu { get; set; }

        [DisplayName("Forma de Pagamento")]
        public string formaPag_usu { get; set; }
    }
}
