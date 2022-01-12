using AwesomeMerlin.Spell;
using Merlin2d.Game.Actors;

namespace AwesomeMerlin.Actors
{
    public interface IWizard : IActor
    {
        void ChangeMana(int delta);
        int GetMana();
        void Cast(ISpell spell);
    }
}
