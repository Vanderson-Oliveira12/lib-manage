using LibManage.Enums;

namespace LibManage.DTOs.User
{
    public class ResponseUserDTO
    {
        public Guid Id {  get; set; }
        public string? Name {  get; set; }
        public string? Email {   get; set; }
        public string? Phone {  get; set; }
        public string Role {  get; set; } = ERole.ALUNO.ToString();
    }
}
