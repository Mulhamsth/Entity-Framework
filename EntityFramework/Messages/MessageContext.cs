using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalMessages>().ToTable("GlobalMessages");
            modelBuilder.Entity<DirectMessages>().ToTable("DirectMessages");
        }

        public DbSet<MessagesBT> MessagesBT { get; set; }
        public DbSet<GlobalMessages> GlobalMessages { get; set; }
        public DbSet<DirectMessages> DirectMessages { get; set; }
    }
}
