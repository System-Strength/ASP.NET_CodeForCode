using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppBancoDominio
{
    public class Cardapio
    {
        [DisplayName("Código do produto:")]
        public int cd_prod { get; set; }

        [DisplayName("Imagem:")]
        [DataType(DataType.Upload)]
        public byte[] img_prod { get; set; }

        [DisplayName("Nome:")]
        [Required(ErrorMessage = "Obrigatório digitar o nome do produto!")]
        public string nm_prod { get; set; }

        [DisplayName("Preço:")]
        [Required(ErrorMessage = "Digite apenas o número, sem vírgula ou ponto!")]
        public decimal preco_prod { get; set; }

        [DisplayName("Quantidade:")]
        public int qntd_prod { get; set; }

        [DisplayName("Categoria:")]
        [Required(ErrorMessage = "Obrigatório informar a categoria do produto!")]
        public string cat_prod { get; set; }
    }
}
