using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Spell
{
    public interface ISpellDirector
    {
        ISpell Build(string spellName);
    }
}
