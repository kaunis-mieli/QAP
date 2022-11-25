using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAP.Core.Constants
{
    public static class State
    {
        public static readonly int Init = 1;
        public static readonly int Queued = 2;
        public static readonly int Running = 3;
        public static readonly int Paused = 4;
        public static readonly int Crashed = 5;
        public static readonly int Canceled = 6;
        public static readonly int Finished = 7;
    }
}
