﻿using System.Data.Common;
using System.Data.Entity;

namespace YellowDrawer.Data.Simple
{
    public class EFContext : DbContext
    {
        public DbSet<ExampleTabel> Example { get; set; }

        public EFContext() : base("DefaultConnection")
        {}

        public EFContext(string connectionString) : base(connectionString) { }

        public static EFContext Create()
        {
            return new EFContext();
        }
    }
}
