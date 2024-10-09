using System.ComponentModel.DataAnnotations;

namespace LibManage.DTOs.User
{
    public class UpdateUserDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
