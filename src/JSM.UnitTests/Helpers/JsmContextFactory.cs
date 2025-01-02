using JSM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JSM.UnitTests.Helpers
{
    internal static class JsmContextFactory
    {
        internal static JsmContext CreateInMemory(Action<JsmContext>? populateMethod = null)
        {
            var options = new DbContextOptionsBuilder<JsmContext>()
                .UseInMemoryDatabase("InMemoryTest")
                .Options;

            var ontimeContext = new JsmContext(options);

            if (populateMethod is not null)
                populateMethod(ontimeContext);

            return ontimeContext;
        }
    }
}
