using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyKeyMapper
{
    public enum ActionStatus
    {
        stopping,
        stoppingError,
        starting,
        startingError,
        running,
        stopped,
        Error
    }
}
