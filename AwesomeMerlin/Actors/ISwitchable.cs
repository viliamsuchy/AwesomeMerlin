﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Actors
{
    public interface ISwitchable
    {
        void Toggle();
        void TurnOn();
        void TurnOff();
        bool IsOn();
    }
}
