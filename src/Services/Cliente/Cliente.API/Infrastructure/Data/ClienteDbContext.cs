using Microsoft.EntityFrameworkCore;

namespace Cliente.API.Infrastructure.Data
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options)
        {
            
        }
    }
}