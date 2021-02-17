using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Compras
    {

        [DisplayName("Código da Compra:")]
        public int cd_compra { get; set; }

        [DisplayName("Nome do Produto:")]
        public string nm_prod { get; set; }

        [DisplayName("Preço do Produto:")]
        [Required(ErrorMessage = "Digite apenas o número, sem vírgula ou ponto!")]
        public decimal preco_prod { get; set; }

        [DisplayName("CPF do Usuário")]
        public string cpf_usu { get; set; }
        
        [DisplayName("Endereço do Usuário")]
        public string end_usu { get; set; }

        [DisplayName("Nº")]
        public string numCasa_usu { get; set; }

        [DisplayName("Bloco")]
        public string blocoApa_usu { get; set; }

        [DisplayName("Forma de Pagamento")]
        [Required(ErrorMessage = "Obrigatório informar a forma de pagamento!")]
        public string formaPag_usu { get; set; }
    }
}
