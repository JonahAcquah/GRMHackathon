namespace GRM
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            SimpleResolver.Init();

            var program = SimpleResolver.GetInstance<Program>();
            program.Start(args);
        }
    }
}