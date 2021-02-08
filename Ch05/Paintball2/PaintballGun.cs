using System;
using System.Collections.Generic;
using System.Text;

namespace Paintball2
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

        // traditionally implemented property with a private backing field
        // see next version for tab-created automatic fields
        private int ballsLoaded = 0;
        public int BallsLoaded
        {
            get { return BallsLoaded; }
            set { ballsLoaded = value; }
        }

        public bool IsEmpty() { return ballsLoaded == 0; }


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
