using AwesomeMerlin.Commands;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class SelfCastSpell : ISpell
    {
        private string caster;
        private List<ICommand> effects; 
        public SelfCastSpell(IActor actor, IEnumerable<ICommand> commands)
        {
            caster = actor.GetName();
            effects = commands.ToList();
        }

        public ISpell AddEffect(ICommand effect)
        {
            effects.Add(effect);
            return (ISpell)effects;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            throw new NotImplementedException();
        }

        public void Cast()
        {
            throw new NotImplementedException();
        }

        public int GetCost()
        {
            throw new NotImplementedException();
        }
    }
}
