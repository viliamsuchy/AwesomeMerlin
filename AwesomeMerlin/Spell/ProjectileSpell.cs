using AwesomeMerlin.Actors;
using AwesomeMerlin.Commands;
using AwesomeMerlin.Strategies;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;

namespace AwesomeMerlin.Spell
{
    public class ProjectileSpell : AbstractActor, ISpell, IMovable
    {
        private IActor caster;
        private List<ICommand> effects;
        private Animation animation;
        private ISpeedStrategy sStrat;
        private int cost;
        bool isCasted;

        public ProjectileSpell(IActor actor, Animation anim, int cost)
        {
            effects = new List<ICommand>();
            caster = actor;
            this.animation = anim;
            this.cost = cost;
            isCasted = false;
        }

        public ISpell AddEffect(ICommand effect)
        {
            effects.Add(effect);
            return this;
        }

        public void AddEffects(IEnumerable<ICommand> effects)
        {
            this.effects.AddRange(effects);
        }

        public void Cast()
        {
            this.SetPosition(caster.GetX(), caster.GetY());
            this.SetAnimation(animation);
            caster.GetWorld().AddActor(this);
            isCasted = true;
        }

        public int GetCost()
        {
            return cost;
        }

        public double GetSpeed(double speed)
        {
            return sStrat.GetSpeed(speed);
        }

        public void SetSpeedStrategy(ISpeedStrategy strat)
        {
            sStrat = strat;
        }
        public override void Update()
        {
            if (isCasted)
            {
                //var lala = this.GetWorld();
                IActor skeleton = GetWorld().GetActors().Find(a => a.GetName() == "skeleton");
               // IActor player = GetWorld().GetActors().Find(a => a.GetName() == "player");
                IActor box = GetWorld().GetActors().Find(a => a.GetName() == "box");
                this.animation.Start();
                if (this.GetWorld().IntersectWithWall(this))
                {
                    this.GetWorld().RemoveActor(this);
                }
                if (this.IntersectsWithActor(box))
                {
                    this.GetWorld().RemoveActor(this);
                }
                //if (lala.IntersectsWithActor(skeleton))
                //{
                //    this.GetWorld().RemoveActor(this);
                //}

                foreach (ICommand eff in effects)
                {
                    if (eff is DealDamage)
                    {
                        if (this.IntersectsWithActor(skeleton))
                        {
                            eff.Execute();
                        }



                    }
                    else
                    {
                        eff.Execute();
                    }
                }
            }
        }
    }
}
