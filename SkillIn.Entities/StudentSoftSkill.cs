using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkillIn.Entities
{
    public class StudentSoftSkill
    {
        public Guid StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        public Guid SoftSkillId { get; set; }

        [ForeignKey(nameof(SoftSkillId))]
        public virtual SoftSkill SoftSkill { get; set; }

        // Составной ключ, т.к. "многие ко многим"
        public class StudentSoftSkillConfiguration : IEntityTypeConfiguration<StudentSoftSkill>
        {
            public void Configure(EntityTypeBuilder<StudentSoftSkill> builder)
            {
                builder.HasKey(shs => new { shs.StudentId, shs.SoftSkillId });
            }
        }
    }
}
