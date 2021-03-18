using System;

namespace ImpHunter
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ImpHunter())
                game.Run();
        }
    }
}
