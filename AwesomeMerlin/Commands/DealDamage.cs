using AwesomeMerlin.Actors;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Commands
{
    public class DealDamage : ICommand
    {
        private int amount;
        private IActor actor;

        public DealDamage(int amount)
        {
            this.amount = amount;
        }

        public void SetActor(IActor actor)
        {
            this.actor = actor;
        }

        public void Execute()
        {

            AbstractCharacter skeleton = (AbstractCharacter)actor.GetWorld().GetActors().Find(a => a.GetName() == "skeleton");
            //AbstractCharacter player = (AbstractCharacter)actor.GetWorld().GetActors().Find(a => a.GetName() == "player");
            //AbstractCharacter skel = (AbstractCharacter)actor.GetWorld().GetActors().Find(a => a.GetName() == "skel");

            if (skeleton.GetWorld().GetActors().Find(a => a.GetName() == "skeleton") == null){

            }
            else 
            {
                if (actor.IntersectsWithActor(skeleton))
                {
                    skeleton.ChangeHealth(-amount);
                }
            }
            
           
            //if (actor.IntersectsWithActor(skel))
            //{
            //    skeleton.ChangeHealth(-amount);
            //}
        }
    }
}
