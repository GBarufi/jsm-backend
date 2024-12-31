using JSM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JSM.UnitTests.Configurations
{
    public static class JsmContextFactory
    {
        public static JsmContext CreateInMemory()
        {
            var options = new DbContextOptionsBuilder<JsmContext>()
                .UseInMemoryDatabase("InMemoryTest")
                .Options;

            var ontimeContext = new JsmContext(options);

            return ontimeContext;
        }
    }
}
