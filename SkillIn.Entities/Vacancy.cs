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
    public class Vacancy
    {
        [Key]
        public Guid Id { get; set; }

        // Внешний ключ на сущность Employer
        public Guid EmployerID { get; set; }
        [ForeignKey(nameof(EmployerID))]
        public virtual Employer? Employer { get; set; }

        // Название вакансии
        [MaxLength(100)]
        public string Title { get; set; }

        // Описание вакансии
        [MaxLength(500)]
        public string Description { get; set; }

        // Требования к соискателю
        [MaxLength(100)]
        public string Requirements { get; set; }
    }
}
