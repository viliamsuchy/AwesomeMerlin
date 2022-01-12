using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    
    public class DyingState
    {
        private bool die = false;
        public bool Dying
        {
            get                 // https://www.dotnetperls.com/bool-return
            {
                return die;
            }
        }
    }
}
