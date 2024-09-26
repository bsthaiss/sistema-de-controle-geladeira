using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstruturaGeladeira
{
    public class Login
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Username é obrigatório!")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]

        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Password é obrigatório!")]
        [PasswordPropertyText]
        [StringLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]

        public string Senha { get; set; } = string.Empty;
    }
}
