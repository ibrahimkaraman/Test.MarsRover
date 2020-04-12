using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MarsRover.Entity;
using Test.MarsRover.Entity.Enums;

namespace Test.MarsRover.Core
{
    class Position : IPosition
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Directions Direction { get; set; }
    }
}
