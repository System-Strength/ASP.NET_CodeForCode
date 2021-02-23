using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppBancoDominio
{
    public class Funcionario
    {
        [DisplayName("ID")]
        public int id_func { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Obrigatório digitar o Nome do Funcionário!")]
        public string nm_func { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Obrigatório informar o Cargo do Funcionário!")]
        public string cg_func { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Obrigatório informar algum e-mail!")]
        public string email_func { get; set; }

        [DisplayName("CPF")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Esse campo deve ter 11 caracteres!")]
        [Required(ErrorMessage = "Obrigatório digitar CPF do Funcionário!")]
        public string cpf_func { get; set; }
        
        [DisplayName("Endereço")]
        [Required(ErrorMessage = "Obrigatório informar algum endereço do Funcionário!")]
        public string end_func { get; set; }
        
        [DisplayName("Telefone")]
        [Required(ErrorMessage = "Obrigatório informar um número de Telefone!")]
        public string tel_func { get; set; }
    }
}