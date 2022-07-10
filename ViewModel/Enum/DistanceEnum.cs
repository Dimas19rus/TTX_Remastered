using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public enum DistanceEnum
    {
        [Description("мм")]
        Millimeter = 1,
        [Description("см")]
        Centimeter = 10,
        [Description("дм")]
        Decimeter = 100,
        [Description("м")]
        Meter = 1000,
        [Description("км")]
        Kilometer = 10000
    }
}
