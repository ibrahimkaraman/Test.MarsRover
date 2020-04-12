using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MarsRover.Entity
{
    public interface IRover
    {
        bool Init();
        IPosition StartPosition { get; set; }
        IPosition CurrentPosition { get; set; }
        IPlateau Plateau { get; set; }
        void StartMove();
        List<string> CommandLineList { get; set; }
        List<string> CommandList { get; set; }
        void RotateLeft();
        void RotateRight();
        void Move();

    }
}
