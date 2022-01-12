using AwesomeMerlin.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Enums;

namespace AwesomeMerlin.Commands
{
    public class Move : ICommand
    {
        IWorld world;
        IActor actor;
        IActor enem;
        private double steps = 0;
        private int DirX = 0;
        private int DirY = 0;
        private IMovable move;
        private double  changinspeed = 0;

        public Move(IMovable movable, int dx, int dy)
        {
            this.move = movable;
            this.steps = move.GetSpeed(2);
            this.DirX = dx;
            this.DirY = dy;
            this.actor = (IActor)movable;
            world = actor.GetWorld();
            //world = enem.GetWorld();
            this.enem = (IActor)movable;
            


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
                actor.SetPosition((int)(actor.GetX() - DirX * steps), (int)(actor.GetY() - DirY * steps));
            }
        }
    }
}
