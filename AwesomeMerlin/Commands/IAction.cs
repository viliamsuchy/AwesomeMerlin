﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeMerlin.Commands
{
    public interface IAction<T>
    {
        public void Execute(T value);
    }
}
