using SkillIn.Entities;


namespace SkillIn.API
{
    public class UserDto
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }

        public UserDto() { }

        public UserDto(User user)
        {
            Login = user.Login;
            Email = user.Email;
            Role = user.Role;
        }
    }
}
