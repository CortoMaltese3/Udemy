using HushApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HushApi.Data
{
    public class HushDbContext : DbContext
    {
        public HushDbContext(DbContextOptions<HushDbContext>options) : base(options)
        {

        }


        public DbSet<Menu> Menus { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
