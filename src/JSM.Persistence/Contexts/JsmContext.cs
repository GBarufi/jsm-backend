using Microsoft.EntityFrameworkCore;

namespace JSM.Persistence.Contexts
{
    public class JsmContext : DbContext
    {
        public JsmContext(DbContextOptions options) : base(options) { }
    }
}
