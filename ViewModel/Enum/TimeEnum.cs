using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public enum TimeEnum
    {
        [Description("мc")]
        Millisecond = 1,
        [Description("c")]
        Second = 1000,
        [Description("мин")]
        Minute = 60000,
        [Description("ч")]
        Hour = 3600000
        
    }
}
