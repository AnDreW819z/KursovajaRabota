using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kurs.Models;

namespace Kurs.Data
{
    public class KursContext : DbContext
    {
        public KursContext (DbContextOptions<KursContext> options)
            : base(options)
        {
        }

        public DbSet<Kurs.Models.Article> Article { get; set; } = default!;
    }
}
