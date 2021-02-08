using System;

namespace Paintball1
{
    class Program
    {

        static void Main(string[] args)
        {
            PaintballGun gun = new PaintballGun();
            while (true)
            {
                Console.WriteLine($"{gun.GetBalls()} balls, {gun.GetBallsLoaded()} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("<Space> to shoot, r to reload, + to add ammo, q to quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                //class works fine as written but look at this syntax:
                // If we still had a field we could do += to increase it by the magazine size...
                else if (key == '+') gun.SetBalls(gun.GetBalls() + PaintballGun.MAGAZINE_SIZE);
                else if (key == 'q') return;
            }
        }
    }
}
