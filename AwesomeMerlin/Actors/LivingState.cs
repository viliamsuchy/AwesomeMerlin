using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public class LivingState
    {
        private bool live = true;
        public bool Living
        {
            get                 // https://www.dotnetperls.com/bool-return
            {
                return live;
            }
        }
    }
}
