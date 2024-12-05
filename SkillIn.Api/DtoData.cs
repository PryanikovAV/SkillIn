using SkillIn.Entities;

namespace SkillIn.Api
{
    public class DtoData
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }

        public DtoData() { }

        public DtoData(User user)
        {
            Login = user.Login;
            Email = user.Email;
            Role = user.Role;
        }
    }

    public record RegisterDto(string Login, string Email, string Password);
}
