using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors.Items
{
    public class ManaPotion : AbstractActor, IItem, IUsable
    {
        private Player player;
        private bool used = false;
        public ManaPotion()
        {
            SetAnimation(new Animation("resources/manapotion.png", 16, 16));
        }
       

        public void Use(IActor actor)
        {
            player = (Player)actor;
            if (used == false)
            {
                used = true;
                player.ChangeMana(30);
                SetAnimation(new Animation("resources/healingpotion_empty.png", 16, 16));
            }
        }
    }
}
