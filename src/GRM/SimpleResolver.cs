using StructureMap;

namespace GRM
{
    public static class SimpleResolver
    {
        public static IContainer Container;

        public static void Init()
        {
            Container = new Container(c =>
            {
                c.Scan(scanner =>
                {
                    scanner.TheCallingAssembly();
                    scanner.WithDefaultConventions();
                });
            });
        }

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}