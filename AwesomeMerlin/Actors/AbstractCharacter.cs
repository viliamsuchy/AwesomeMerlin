using AwesomeMerlin.Enum;
using AwesomeMerlin.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeMerlin.Actors
{

    public class AbstractCharacter : AbstractActor, IMovable, ICharacter
    {
        private int health = 100;
        private int maxHP = 100;
        private ISpeedStrategy sStrat;
        public ActorOrientation Direction { get; set;}
        public bool state = new LivingState().Living;
        public AbstractCharacter()
        {
            sStrat = new NormalSpeedStrategy();
            Direction = ActorOrientation.FacingRight;
        }
        public void AddEffect(ICommand effect)
        {
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {  
            if((health + delta) >= maxHP)
            {
                health = maxHP;
            }
            else 
            {
                health += delta;
                if(health <= 0)
                {
                    health = 0;
                }
            }
            
            
        }

        public void Die()
        {
            state = new DyingState().Dying;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public double GetSpeed(double speed)
        {
            return sStrat.GetSpeed(speed);
        }

        public void RemoveEffect(ICommand effect)
        {
            //throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.sStrat = strategy;
        }
        
    }
}
