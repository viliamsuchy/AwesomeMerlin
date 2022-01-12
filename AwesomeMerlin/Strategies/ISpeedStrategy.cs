using AwesomeMerlin.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Strategies
{
    public interface ISpeedStrategy
    {
        double GetSpeed(double speed);
    }
}
