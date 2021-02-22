using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppBancoDominio
{
    public class Funcionario
    {
        [DisplayName("ID do Funcionário:")]
        public int id_func { get; set; }

        [DisplayName("Nome do Funcionário:")]
        [Required(ErrorMessage = "Obrigatório digitar o Nome do Funcionário!")]
        public string nm_func { get; set; }

        [DisplayName("Cargo do Funcionário:")]
        [Required(ErrorMessage = "Obrigatório informar o Cargo do Funcionário!")]
        public string cg_func { get; set; }

        [DisplayName("E-mail:")]
        [Required(ErrorMessage = "Obrigatório informar algum e-mail!")]
        public string email_func { get; set; }

        [DisplayName("CPF do Funcionário:")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Esse campo deve ter 11 caracteres!")]
        public string cpf_func { get; set; }
        
        [DisplayName("Endereço do Funcionário:")]
        [Required(ErrorMessage = "Obrigatório informar algum endereço do Funcionário!")]
        public string end_func { get; set; }
        
        [DisplayName("Telefone do Funcionário:")]
        [Required(ErrorMessage = "Obrigatório informar um número de Telefone!")]
        public string tel_func { get; set; }
    }
}