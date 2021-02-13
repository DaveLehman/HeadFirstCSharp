using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveINotifyPropertyChanged
{
    interface IWorker
    {
        string Job { get; }
        void WorkTheNextShift();
    }
}
