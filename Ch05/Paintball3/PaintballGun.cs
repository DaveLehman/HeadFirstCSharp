using System;
using System.Collections.Generic;
using System.Text;

namespace Paintball3
{
    class PaintballGun
    {
        public const int MAGAZINE_SIZE = 16;    // will be used in Main() so public

        private int balls = 0;
        public int Balls
        {
            get { return balls; }
            set
            {
                if (value > 0)
                    balls = value;
                Reload();
            }
        }

        // automatic property DOES have a private backing field that VS made for you
        // type the word prop then two TABs (have to manually make the set private)
        public int BallsLoaded { get; private set; }

        public bool IsEmpty() { return BallsLoaded == 0; }


        public void Reload()
        {
            // The only way to reload the gun is by calling Reload(), which loads the gun
            // with a ful magazine if possible or the remaining number of balls if not
            // This keeps balls and ballsLoaded from getting out of sync
            if (balls > MAGAZINE_SIZE)
                BallsLoaded = MAGAZINE_SIZE;
            else
                BallsLoaded = balls;
        }

        public bool Shoot()
        {
            // returns true and decrements balls if loaded
            // return false if the gun is empty
            // keeps balls and ballsLoaded from getting out of sync
            if (BallsLoaded == 0) return false;
            BallsLoaded--;
            balls--;
            return true;
        }
    }
}
