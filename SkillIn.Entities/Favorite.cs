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
    public class Favorite
    {
        [Key]
        public Guid Id { get; set; }

        // Внешний ключ на сущность User
        public Guid UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; }

        // Внешний ключ на сущность User
        public Guid FavoriteUserID { get; set; }
        [ForeignKey(nameof(FavoriteUserID))]
        public virtual User FavoriteUser { get; set; }
    }
}
