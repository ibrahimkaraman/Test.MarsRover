using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MarsRover.Entity
{
    public interface IPlateau
    {
        int AreaX { get; set; }
        int AreaY { get; set; }
        bool Init();
        string CommandLine { get; set; }
        List<IRover> RoverList { get; set; }
    }
}
