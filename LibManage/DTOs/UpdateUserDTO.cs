using System.ComponentModel.DataAnnotations;

namespace LibManage.DTOs
{
    public class UpdateUserDTO
    {
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Email com formato inválido")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Telefone com formato inválido")]
        public string? Phone { get; set; }
    }
}
