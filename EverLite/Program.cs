using System;

namespace EverLite
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new EverLite())
                game.Run();
        }
    }
}
