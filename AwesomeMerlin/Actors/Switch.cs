using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class Switch : AbstractCharacter, IObservable
    {
        private Animation animationOn;
        private Animation animationOff;
        private Player player;
        private int isON = 0;

        private List<IObserver> Liobserver = new List<IObserver>();
       
        public Switch()
        {

            animationOn = new Animation("resources/myswitch.png", 38, 71);
            animationOff = new Animation("resources/myswitchoff.png", 38, 71);
            SetAnimation(animationOff);       

        }

        

        public void Subscribe(IObserver observer)
        {
            if (this.Liobserver.Contains(observer) == false)
            {
                this.Liobserver.Add(observer);
            }
        }
        

        public void Unsubscribe(IObserver observer)
        {
            if (this.Liobserver.Contains(observer) == true)
            {
                this.Liobserver.Remove(observer);
            }
        }

        public override void Update()
        {
            player = (Player)GetWorld().GetActors().Find(a => a is Player);
            
            
            if (this.GetX() + 40 >= player.GetX() && Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                
                if (isON == 0)
                {
                    SetAnimation(animationOn);
                    isON = 1;
                  
                    
                }
                else
                {
                    
                    SetAnimation(animationOff);
                    isON = 0;
                }
                foreach (IObserver observer in Liobserver)
                {
                    observer.Notify(this);
                }


            }
        }
       
    }
   
}
