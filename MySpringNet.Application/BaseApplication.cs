using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySpringNet.Application
{
    abstract class BaseApplication
    {
        public virtual void  Init(){}

        public abstract void AbstractInit();
    }
}
