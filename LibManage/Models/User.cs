using LibManage.Enums;

namespace LibManage.Models
{
    public class User
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ERole Role { get; set; } = ERole.ALUNO;

    }
}
