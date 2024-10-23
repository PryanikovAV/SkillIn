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
    public class Olympiad
    {
        [Key]
        public Guid Id { get; set; }

        // Название олимпиады
        [Required]
        [MaxLength(100)]
        public string OlympiadName { get; set; }

        // Внешний ключ на сущность Student
        public Guid StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public virtual Student? Student { get; set; }

        // Результат олимпиады
        [Required]
        [MaxLength(100)]
        public string OlympiadResult { get; set; }
    }
}