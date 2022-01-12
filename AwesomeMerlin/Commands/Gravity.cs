using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace AwesomeMerlin.Commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;
        private Fall<IActor> fall;
        public Gravity()
        {
            fall = new Fall<IActor>();
        }

        public void Execute()
        {
            Func<IActor, bool> func = x => x.IsAffectedByPhysics();
            List<IActor> actors = world.GetActors()
                .Where(func)
                .ToList();
            foreach (IActor actor in actors)
            {

                fall.Execute(actor);


            }


        }

        public void SetWorld(IWorld world)
        {
            this.world = world;
        }
    }
}
