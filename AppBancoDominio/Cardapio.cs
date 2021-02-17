using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDominio
{
    public class Cardapio
    {
        [DisplayName("Código do produto:")]
        public int cd_prod { get; set; }

        //[DisplayName("Imagem:")]

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "Obrigatório digitar o nome do produto!")]
        public string nm_prod { get; set; }

        [DisplayName("Preço:")]
        [Required(ErrorMessage = "Digite apenas o número, sem vírgula ou ponto!")]
        public decimal preco_prod { get; set; }
    }
}
