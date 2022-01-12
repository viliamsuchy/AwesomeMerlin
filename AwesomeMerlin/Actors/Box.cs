using AwesomeMerlin.Commands;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class Box : AbstractCharacter
    {
        private Player player;
        private Animation animation;
        private int previousX;
        private int previousY;
        private int PpreviousX;
        private int PpreviousY;
        private Move moveLeft;
        private Move moveRight;

        public Box()
        {
            animation = new Animation("resources/box2.png", 102, 102);
            SetAnimation(animation);
            SetPhysics(true);

            moveLeft = new Move(this, -1, 0);
            moveRight = new Move(this, 1, 0);
            
        }
        public override void Update()
        {
            player = (Player)GetWorld().GetActors().Find(a => a is Player);
            if (player.IntersectsWithActor(this))
            {
                int x_p = this.GetX();
                int y_p = this.GetY();
                int x_e = player.GetX();
                int y_e = player.GetY();


                //Intersect from side 
                int diff = y_e - y_p;

                if (diff > -(player.GetHeight() - 1) && diff < this.GetHeight() - 1)
                {
                    if (player.GetX() < this.GetX())
                    {
                        moveRight.Execute();

                        
                    }
                    else
                    {
                        moveLeft.Execute();

                        
                    }
                }

                //Intersect from top 
                if(y_e + player.GetHeight() >= y_p && (y_e + player.GetHeight() <= y_p + 6))
                {
                    player.SetPosition(player.GetX(), player.GetY() - 2);
                }
            }

            previousX = this.GetX();
            previousY = this.GetY();
            PpreviousX = player.GetX();
            PpreviousY = player.GetY();
        }
    }
}
