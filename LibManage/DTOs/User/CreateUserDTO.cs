using LibManage.Enums;
using System.ComponentModel.DataAnnotations;

namespace LibManage.DTOs.User
{
    public class CreateUserDTO
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        [MaxLength(100, ErrorMessage = "Informe até no máximo 100 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Phone(ErrorMessage = "Fomato de telefone inválido")]
        public string? Phone { get; set; }
    }
}
