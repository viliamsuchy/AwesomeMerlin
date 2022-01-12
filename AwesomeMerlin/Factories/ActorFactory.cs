using AwesomeMerlin.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Factories
{
    public class ActorFactory : IFactory
    {
   
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            AbstractActor actor = null;
            
            if(actorType == "Player")
            {
                actor = new Player();
                actor.SetName(actorName);
                actor.SetPosition(x, y);
                //Console.WriteLine(actor.GetX());
                //Console.WriteLine(actor.GetName());


            }
            //if (actorType == "Skel")
            //{
            //    actor = new Skel();
            //    actor.SetName(actorName);
            //    actor.SetPosition(x, y);
            //    //Console.WriteLine(actor.GetX());
            //    //Console.WriteLine(actor.GetName());


            //}
            if (actorType == "Skeleton")
            {
                actor = new Skeleton();
                actor.SetName(actorName);
                actor.SetPosition(x, y);
                //Console.WriteLine(actor.GetX());
                //Console.WriteLine(actor.GetName());

            }
            if (actorType == "Switch")
            {
                actor = new Switch();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

               
            }
            if (actorType == "Door")
            {
                actor = new Door();
                actor.SetName(actorName);
                actor.SetPosition(x, y);


            }
            if (actorType == "PressurePlate")
            {
                actor = new PressurePlate();
                actor.SetName(actorName);
                actor.SetPosition(x, y);

                
            }
            if (actorType == "Box")
            {
                actor = new Box();
                actor.SetName(actorName);
                actor.SetPosition(x, y);


            }
     
            return actor;
        }
    }
}
