using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class PressurePlate : AbstractCharacter
    {
        private Player player;
        private Animation animationOn;
        private Animation animationOff;
        public PressurePlate()
        {
            animationOn = new Animation("resources/plateOn.png", 50, 15);
            animationOff = new Animation("resources/plateOff.png", 50, 15);
            SetAnimation(animationOff);
            SetPhysics(true);         
        }
        public override void Update()
        {
            player = (Player)GetWorld().GetActors().Find(a => a is Player);
            int x_p = this.GetX();
            int y_p = this.GetY();
            int x_e = player.GetX();
            int y_e = player.GetY();      
            //Console.WriteLine("newPosition");
            //Console.WriteLine(x_p);
            //Console.WriteLine(y_p);
            //Console.WriteLine(x_e);
            //Console.WriteLine(y_e);
            //Console.WriteLine(rozdiel);
            //Console.WriteLine(rozdiel2);
            if (y_e + player.GetHeight() == y_p + this.GetHeight() && x_p + this.GetWidth() > x_e && x_p < x_e + player.GetWidth() ) 
            {
                //if (this.IntersectsWithActor(player))
                //{
                player.ChangeMana(1);
                SetAnimation(animationOn);
            }
            else
            {
                SetAnimation(animationOff);
                
            }

        }
    }
}
