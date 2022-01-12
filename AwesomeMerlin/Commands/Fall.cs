using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Commands
{
    public class Fall<T> : IAction<T> where T : IActor
    {
        private IActor actor;
        private IWorld world;

        //public Fall()
        //{

        //}
        public void Execute(T value)
        {
            this.actor = value;
            this.world = actor.GetWorld();
            //this.actor = value;
            actor.SetPosition(actor.GetX(), actor.GetY() + 1); // bude padať dokym nebude v stene jednym pixelom
            if (actor.GetWorld().IntersectWithWall(actor))
            {
                actor.SetPosition(actor.GetX(), actor.GetY() - 1); // ak bude tak ho vrati nahor aby stal na stene 
            }
            //actor.GetWorld().IntersectWithWall(actor);
            //throw new NotImplementedException();
        }
    }
}
