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
    public class Chat
    {
        [Key]
        public Guid ChatID { get; set; }

        // Список участников чата
        public virtual ICollection<User> Participants { get; set; } = new List<User>();
    }

    public class Message
    {
        [Key]
        public Guid MessageID { get; set; }

        // Внешний ключ на сущность Chat
        [Required]
        public Guid ChatID { get; set; }
        [ForeignKey(nameof(ChatID))]
        public virtual Chat Chat { get; set; }

        // Внешний ключ на пользователя, который отправил сообщение
        [Required]
        public Guid SenderID { get; set; }
        [ForeignKey(nameof(SenderID))]
        public virtual User Sender { get; set; }

        // Внешний ключ на пользователя, который получил сообщение
        [Required]
        public Guid ReceiverID { get; set; }
        [ForeignKey(nameof(ReceiverID))]
        public virtual User Receiver { get; set; }

        // Содержимое сообщения
        [Required]
        public string Content { get; set; }

        // Время отправки сообщения
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
