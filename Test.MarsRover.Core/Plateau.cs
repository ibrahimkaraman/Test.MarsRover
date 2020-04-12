using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MarsRover.Entity;

namespace Test.MarsRover.Core
{
    class Plateau : IPlateau
    {
        public Plateau()
        {
            RoverList = new List<IRover>();
        }
        public int AreaX { get; set; }
        public int AreaY { get; set; }
        public List<IRover> RoverList { get; set; }
        public string CommandLine { get; set; }

        public bool Init()
        {
            bool initControl = false;
            string[] spearator = { " " };
            string[] commandList = CommandLine.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

            if (commandList.Length == 2)
            {
                int areaX;
                int areaY;

                if (int.TryParse(commandList[0], out areaX) && int.TryParse(commandList[1], out areaY) && areaX > 0 && areaY > 0)
                {
                    AreaX = areaX;
                    AreaY = areaY;
                    initControl = true;
                }
            }

            if (!initControl)
            {
                Console.WriteLine("Taranacak alan bilgileri yanlış girildi!");
            }

            return initControl;
        }
    }
}
