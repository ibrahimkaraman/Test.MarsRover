using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MarsRover.Entity.Enums;

namespace Test.MarsRover.Entity
{
    public interface IPosition
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        Directions Direction { get; set; }
    }
}
