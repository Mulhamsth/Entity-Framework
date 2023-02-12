using System.ComponentModel.DataAnnotations.Schema;

namespace Messages
{
    [Table("MESSAGES_BT")]
    public class MessagesBT
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}