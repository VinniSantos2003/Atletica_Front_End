using Microsoft.EntityFrameworkCore;
using Atletica_BD;
using Microsoft.Extensions.Options;
namespace Atletica_Back_End.Data

{
    public class ApplicationContext : DbContext
    {
        
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        //public DbSet<BaseEntity> BaseEntities { get; set; }
        public  DbSet<Champion> Champions { get; set; }
        public  DbSet<Match> Matchs { get; set; } 
        public  DbSet<Player> Players { get; set; } 
        public  DbSet<Team> Teams { get; set; } 
        public  DbSet<UsedChampion> UsedChampions { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            optionsBuilder.UseSqlite($"Data Source=AtleticaApp.db");
        }
    }
}
