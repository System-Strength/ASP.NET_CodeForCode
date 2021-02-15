using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Parceiro
    {
        [DisplayName("Código da Compra:")]
        public int cd_parc { get; set; }

        [DisplayName("Nome:")]
        public string nm_parc { get; set; }
        
        [DisplayName("Empresa:")]
        public string empresa_parc { get; set; }
        
        [DisplayName("CNPJ:")]
        public string cnpj_parc { get; set; }
        
        [DisplayName("Email:")]
        public string email_parc { get; set; }
        
        [DisplayName("Site:")]
        public string site_parc { get; set; }
        
        [DisplayName("Telefone:")]
        public string tel_parc { get; set; }
        
        [DisplayName("Rede Social:")]
        public string redeSocial_parc { get; set; }

        [DisplayName("Descrição da Empresa:")]
        public string descr_parc { get; set; }
    }
}
