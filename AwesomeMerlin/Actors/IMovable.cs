using AwesomeMerlin.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AwesomeMerlin.Actors
{
    public interface IMovable
    {
        double GetSpeed(double speed);
        void SetSpeedStrategy(ISpeedStrategy strat);
    }
    
}
