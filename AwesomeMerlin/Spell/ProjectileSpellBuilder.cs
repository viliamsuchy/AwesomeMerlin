using AwesomeMerlin.Actors;
using AwesomeMerlin.Commands;
using AwesomeMerlin.Enum;
using AwesomeMerlin.Strategies;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public class ProjectileSpellBuilder : ISpellBuilder
    {
        private Animation animation;
        private int cost;
        private List<ICommand> spellEffects;

        public ProjectileSpellBuilder()
        {
            spellEffects = new List<ICommand>();
        }

        public ISpellBuilder AddEffect(string effectName)
        {
            if(effectName.StartsWith("damage"))
            {
                spellEffects.Add(new DealDamage(int.Parse(effectName.Split('-')[1])));
            }


            return this;
        }

        public ISpell CreateSpell(IWizard caster)
        {
            AbstractCharacter character = (AbstractCharacter)caster;
            ProjectileSpell projectile = new ProjectileSpell(caster, animation, cost);

            projectile.SetSpeedStrategy(new NormalSpeedStrategy());

            if (character.Direction == ActorOrientation.FacingRight)
            {

                projectile.AddEffect(new ProjectileMove(projectile, 1, 0));
            }
            else
            {
                animation.FlipAnimation();
                projectile.AddEffect(new ProjectileMove(projectile, -1, 0));
            }

            foreach(ICommand spell in spellEffects)
            {
                if(spell is DealDamage)
                {
                    ((DealDamage)spell).SetActor(projectile);
                }
            }

            projectile.AddEffects(spellEffects);
            
            return projectile;
        }

        public ISpellBuilder SetAnimation(Animation animation)
        {
            this.animation = animation;
            return this;
        }

        public ISpellBuilder SetSpellCost(int cost)
        {
            this.cost = cost;
            return this;
        }
    }
}
