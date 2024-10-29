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
    public class Employer : User
    {
        // Конструктор класса
        public Employer()
        {
            Vacancies = new List<Vacancy>();
        }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(500)]
        public string CompanyInfo { get; set; }

        // Список вакансий работодателя
        public virtual ICollection<Vacancy> Vacancies { get; set; }
    }
}