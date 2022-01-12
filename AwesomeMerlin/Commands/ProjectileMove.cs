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
    public class ProjectileMove : ICommand
    {
        IWorld world;
        IActor actor;
        private double steps = 0;
        private int DirX = 0;
        private int DirY = 0;
        private IMovable move;
        private double changinspeed = 0;

        public ProjectileMove(IMovable movable, int dx, int dy)
        {
            this.move = movable;
            this.steps = move.GetSpeed(4);
            this.DirX = dx;
            this.DirY = dy;
            this.actor = (IActor)movable;
            world = actor.GetWorld();




        }

        public void Execute()
        {
            this.steps = move.GetSpeed(steps);
            if (this.steps % 1 != 0)
            {
                this.changinspeed += (steps % 1);

                if (this.changinspeed >= 1)
                {
                    this.changinspeed--;
                    Math.Ceiling(steps);
                }
                else
                {
                    steps = steps - (steps % 1);
                }
            }
            IWorld world = actor.GetWorld();



            actor.SetPosition((int)(actor.GetX() + DirX * steps), (int)(actor.GetY() + DirY * steps));
            if (world.IntersectWithWall(actor))
            {
                world.RemoveActor(actor);
            }
            if (actor.IntersectsWithActor(actor.GetWorld().GetActors().Where(a => a.GetName() == "skeleton").FirstOrDefault()))
            {
               world.RemoveActor(actor);
                
            }
        }
    }
}
