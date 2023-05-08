using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MV_DosTablas.Models;

namespace MV_DosTablas.Data
{
    public class MV_DosTablasContext : DbContext
    {
        public MV_DosTablasContext (DbContextOptions<MV_DosTablasContext> options)
            : base(options)
        {
        }

        public DbSet<MV_DosTablas.Models.MV_Burger> MV_Burger { get; set; } = default!;

        public DbSet<MV_DosTablas.Models.MV_Promo>? MV_Promo { get; set; }
    }
}
