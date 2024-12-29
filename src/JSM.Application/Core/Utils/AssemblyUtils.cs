using System.Reflection;

namespace JSM.Application.Core.Utils
{
    public static class AssemblyUtils
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
