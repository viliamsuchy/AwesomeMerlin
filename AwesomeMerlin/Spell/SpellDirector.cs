using AwesomeMerlin.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class SpellDirector : ISpellDirector
    {
        private ISpellDataProvider Spellinfos;
        private Dictionary<string, SpellInfo> spells;
        private Dictionary<string, int> effects;
        private IWizard wizard;
        public SpellDirector(IWizard wizard)
        {
            Spellinfos = SpellDataProvider.GetInstance();
            spells = Spellinfos.GetSpellInfo();
            effects = Spellinfos.GetSpellEffects();
            this.wizard = wizard;
        }


        public ISpell Build(string spellName)
        {

            SpellInfo spellos = spells[spellName];

            int spellCost = 0;

            foreach(string eff in spellos.EffectNames)
            {
                spellCost += effects[eff];
            }
            AbstractCharacter character = ((AbstractCharacter)wizard);
            IWorld world = character.GetWorld();
           

            ISpellBuilder spellBuilder;

            if (spellos.SpellType == SpellType.Projectile)
            {
                spellBuilder = new ProjectileSpellBuilder();

                foreach (string eff in spellos.EffectNames)
                {
                    spellBuilder.AddEffect(eff);
                }

                ProjectileSpell spell = (ProjectileSpell)spellBuilder
                    .SetAnimation(new Animation(spellos.AnimationPath,spellos.AnimationWidth, spellos.AnimationHeight))
                    .SetSpellCost(spellCost)
                    .CreateSpell(wizard);

                return spell;
            }
            else
            {
                spellBuilder = new SelfCastSpellBuilder();

                foreach (string eff in spellos.EffectNames)
                {
                    spellBuilder.AddEffect(eff);
                }

                return spellBuilder
                    .SetAnimation(new Animation(spellos.AnimationPath, spellos.AnimationWidth, spellos.AnimationHeight))
                    .SetSpellCost(spellCost)
                    .CreateSpell(wizard);
            }
        }
    }

}
