using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkillIn.Entities
{
    public enum UserRole
    {
        Student,
        Employer
    }

    public class User
    {
        // ID пользователя
        [Key]
        public Guid Id { get; set; }  // { get; } ?

        // UserName Логин пользователя
        [Required]
        [MaxLength(32)]
        public string Login { get; set; }

        // Email электронная почта
        [MaxLength(64)]
        public string Email { get; set; }

        // Students or Employers
        [Required]
        public UserRole Role { get; set; }

        // PasswordHash
        [InverseProperty(nameof(UserPassword.User))]
        public virtual UserPassword? Password { get; set; }
    }
}