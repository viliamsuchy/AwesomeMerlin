using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeMerlin.Commands;
using AwesomeMerlin.Enum;
using AwesomeMerlin.Spell;
using AwesomeMerlin.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;

namespace AwesomeMerlin.Actors
{
    public class Skeleton : AbstractCharacter, IMovable
    {
        Animation animation;       
        private Move moveLeft;
        private Move moveRight;
        private Player player;
        private int hp;        
        private string shp;
        private bool flip = false;
        
       
        private IWorld world;
        public Skeleton()
        {
            animation = new Animation("resources/enemy.png", 33, 47);
            this.SetAnimation(animation);
            moveLeft = new Move(this, -1, 0);
            moveRight = new Move(this, 1, 0);
            SetPhysics(true);
        }

      

        public override void Update()
        {
            
            hp = GetHealth();
            shp = hp.ToString();
            
            Message message = new Message(shp, GetX() + 10, GetY() - 15, 11, Color.Red, (MessageDuration)2);
            
            GetWorld().AddMessage(message);
            

            AbstractCharacter player = (AbstractCharacter)GetWorld().GetActors().Find(a => a.GetName() == "merlin");
            if (this.GetHealth() == 0)
            {
                this.Die();
            }
            if (state == false)
            {
                animation.Stop();
                
                RemoveFromWorld();
         
            }

            if (GetWorld().GetActors().Find(a => a.GetName() == "skeleton") == null) // ak sa nenachádza v mape žiaden skeleton
            {
                world = GetWorld(); // znova si musim zavolať svet
                world.SetEndCondition(world => MapStatus.Finished);
            }
            if (player.GetY() == this.GetY() || player.GetY() + 30 <= this.GetY() && player.GetY() > this.GetY())
            {
                if (player.GetX() + 30 <= this.GetX())
                {
                    if (flip == false)
                    {
                        animation.FlipAnimation();
                        flip = true;
                    }
                    animation.Start();
                    moveLeft.Execute();

                    
                }
                
                if (player.GetX() - 30 >= this.GetX())
                {
                    if (flip == true)
                    {
                        animation.FlipAnimation();
                        flip = false;
                    }
                    moveRight.Execute();
                    animation.Start();

                    
                }
               
            }
            else
            {
                animation.Stop();
            }
        }
    }
}
