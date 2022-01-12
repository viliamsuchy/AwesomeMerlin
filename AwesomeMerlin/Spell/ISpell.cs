using AwesomeMerlin.Commands;
using Merlin2d.Game.Actors;
using System.Collections.Generic;

namespace AwesomeMerlin.Spell
{
    public interface ISpell
    {
        ISpell AddEffect(ICommand effect);
        void AddEffects(IEnumerable<ICommand> effects);
        int GetCost();
        void Cast();
        
    }
}
