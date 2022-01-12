using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class Door : AbstractActor, IObserver
    {
        private int isON = 0;
        private Animation animationOn;
        private Animation animationOff;
        private int x_p;
        private int y_p;
        private bool first = false;
        
        public Door()
        {
            animationOn = new Animation("resources/doorO.png", 30, 60);
            animationOff = new Animation("resources/door.png", 30, 60);
            x_p = 235;
            y_p = 910;
           
            SetAnimation(animationOff);
        }
        public void Notify(IObservable observable)
        {
           
           

            if (isON == 0)
            {
                for (int pretty = x_p; pretty <= x_p + this.GetWidth(); pretty++)
                {
                    for (int pretty2 = y_p; pretty2 <= y_p + this.GetHeight(); pretty2++)
                    {
                        GetWorld().SetWall(pretty/16, pretty2/16, false);
                    }
                }

                SetAnimation(animationOn);
                isON = 1;
            }
            else
            {
                for (int pretty = x_p; pretty <= x_p + this.GetWidth(); pretty++)
                {
                    for (int pretty2 = y_p; pretty2 <= y_p + this.GetHeight(); pretty2++)
                    {
                        GetWorld().SetWall(pretty / 16, pretty2 / 16, true);
                    }
                }
                SetAnimation(animationOff);
                isON = 0;
            }
        }
        public override void Update()
        {
            if (first == false)
            {
                for (int pretty = x_p; pretty <= x_p + this.GetWidth(); pretty++)
                {
                    for (int pretty2 = y_p; pretty2 <= y_p + this.GetHeight(); pretty2++)
                    {
                        GetWorld().SetWall(pretty / 16, pretty2 / 16, true);
                    }
                }
                first = true;
            }

        }
    }
}
