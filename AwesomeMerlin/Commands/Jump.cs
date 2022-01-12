using AwesomeMerlin.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Commands
{
    public class Jump : IPhysics
    {
        private IWorld world;
        private IActor actor;
        int steps = 0;
        int DirX = 0;
        int DirY = 0;
        int actualY = 0;
        private bool ground = false;
        int hight = 150;
        //private int milliseconds = 50;

        public Jump(IMovable movable, int step, int dx, int dy)
        {

            this.steps = step;
            this.DirX = dx;
            this.DirY = dy;
            this.actor = (IActor)movable;





        }

        public void Execute()
        {
            //actualY = actor.GetY();
            //IWorld world = actor.GetWorld();
            this.world = actor.GetWorld();
            IActor box = (Box)actor.GetWorld().GetActors().Find(a => a is Box);
            //actor.SetPosition(actor.GetX() + DirX * steps, actor.GetY() + DirY * steps);
            actor.SetPosition(actor.GetX(), actor.GetY() + 1);
            if (actor.GetWorld().IntersectWithWall(actor) || (actor.IntersectsWithActor(box) && actor.GetY() + actor.GetHeight() >= box.GetY() && (actor.GetY() + actor.GetHeight() <= box.GetY() + 6)))
            {
                actor.SetPosition(actor.GetX(), actor.GetY() - 1);
                this.ground = true;
                actualY = actor.GetY();
                //actor.SetPosition(actor.GetX() + DirX * steps, actor.GetY() + DirY * steps);
            }

            if ((this.ground == true) && (this.actualY <= actor.GetY() + this.hight))
            {

                actor.SetPosition(actor.GetX(), actor.GetY() - 10);
                if (actor.GetWorld().IntersectWithWall(actor))
                {
                    actor.SetPosition(actor.GetX(), actor.GetY() + 10);
                    this.ground = false;

                }
                if (this.actualY > actor.GetY() + this.hight)
                {
                    this.ground = false;
                }


                //actualY =- 2;
            }

        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}

