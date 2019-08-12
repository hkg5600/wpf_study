using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _0709study.Model
{
    public class TimeModel
    {
        public DateTime dueTime { get; set; }
        public DispatcherTimer modelTimer { get; set; }
    }
}
