using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    [Table("DIRECT_USER_MESSAGES")]
    public class DirectMessages : MessagesBT
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
