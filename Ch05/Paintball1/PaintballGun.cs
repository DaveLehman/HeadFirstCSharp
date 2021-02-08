using System;
using System.Collections.Generic;
using System.Text;

namespace Paintball1
{
    class PaintballGun
    {
        public const int MAGAZINE_SIZE = 16;    // will be used in Main() so public

        // Rest of game can call GetBalls or GetBallsLoaded to access these privates
        private int balls = 0;
        private int ballsLoaded = 0;

        
        public int GetBallsLoaded() { return ballsLoaded; } //exposes ballsLoaded without touching
        public int GetBalls() { return balls; }
        public bool IsEmpty() { return ballsLoaded == 0; }

        public void SetBalls(int numberOfBalls)
        {
            // The game needs to be able to set the number of balls. SetBalls protects the
            // balls field by only allowing the game to set a positive number of balls.
            //Then it calls Reload() to automatically reload the gun
            if (numberOfBalls > 0)
            {
                balls = numberOfBalls;
            }
            Reload();
        }

        public void Reload()
        {
            // The only way to reload the gun is by calling Reload(), which loads the gun
            // with a ful magazine if possible or the remaining number of balls if not
            // This keeps balls and ballsLoaded from getting out of sync
            if (balls > MAGAZINE_SIZE)
                ballsLoaded = MAGAZINE_SIZE;
            else
                ballsLoaded = balls;
        }

        public bool Shoot()
        {
            // returns true and decrements balls if loaded
            // return false if the gun is empty
            // keeps balls and ballsLoaded from getting out of sync
            if (ballsLoaded == 0) return false;
            ballsLoaded--;
            balls--;
            return true;
        }
    }
}
