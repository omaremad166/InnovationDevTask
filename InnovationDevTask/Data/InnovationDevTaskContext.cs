#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InnovationDevTask.Models;

namespace InnovationDevTask.Data
{
    public class InnovationDevTaskContext : DbContext
    {
        public InnovationDevTaskContext (DbContextOptions<InnovationDevTaskContext> options)
            : base(options)
        {
        }

        public DbSet<InnovationDevTask.Models.Order> Order { get; set; }
    }
}
