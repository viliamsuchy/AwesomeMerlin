using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeMerlin.Actors
{
    public interface ICharacter : IMovable
    {
        void ChangeHealth(int delta);
        int GetHealth();
        void Die();
        void AddEffect(ICommand effect);
        void RemoveEffect(ICommand effect);

    }
}
