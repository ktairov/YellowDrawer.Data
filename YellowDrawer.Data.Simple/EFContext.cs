using System.Data.Entity;

namespace YellowDrawer.Data.Simple
{
    public class EFContext : DbContext
    {
        public DbSet<ExampleTabel> Example { get; set; }

        public EFContext() : base("DefaultConnection")
        {}

        public static EFContext Create()
        {
            return new EFContext();
        }
    }
}
