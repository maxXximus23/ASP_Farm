using Microsoft.EntityFrameworkCore;
using MinecraftFarm.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftFarm.DataAccessLayer.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<PlayerResource> PlayerResources { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
