using AwesomeMerlin.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class SelfCastSpellBuilder : ISpellBuilder
    {
        public ISpellBuilder AddEffect(string effectName)
        {
            throw new NotImplementedException();
        }



        public ISpell CreateSpell(IWizard caster)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            throw new NotImplementedException();
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            throw new NotImplementedException();
        }
    }
}
