using Microsoft.EntityFrameworkCore;

namespace ChartGptAspReactExamen.Models
{
    public class Context:DbContext
    {
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<DataModel> DataModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "Data Source = SQL5103.site4now.net; Initial Catalog = db_a94eb1_mydb; User Id = db_a94eb1_mydb_admin; Password = 2657sgnusmas";
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
