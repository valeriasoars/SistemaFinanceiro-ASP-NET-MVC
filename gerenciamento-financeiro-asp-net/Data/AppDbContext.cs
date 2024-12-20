using Microsoft.EntityFrameworkCore;

namespace gerenciamento_financeiro_asp_net.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }


    }
}
