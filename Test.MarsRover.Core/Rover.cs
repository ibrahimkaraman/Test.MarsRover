using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MarsRover.Entity;
using Test.MarsRover.Entity.Enums;

namespace Test.MarsRover.Core
{
    public class Rover : IRover
    {
        public Rover(IPlateau Plateau)
        {
            this.Plateau = Plateau;
            CommandList = new List<string>();
            CommandLineList = new List<string>();
        }

        public IPosition StartPosition { get; set; }
        public IPosition CurrentPosition { get; set; }
        public List<string> CommandList { get; set; }
        public IPlateau Plateau { get; set; }
        public List<string> CommandLineList { get; set; }

        public bool Init()
        {

            bool initControl = false;
            // Start position datasının beklenen şekilde kullanıcı tarafından girilip girilmediğini kontrol ediyoruz.
            StartPositionControlAndSet(ref initControl);
            // Razorun yapacağı hareketler için girilen komut listesinin beklenen şekilde kullanıcı tarafından girilip girilmediğini kontrol ediyoruz.
            CommandListControlAndSet(ref initControl);

            // Komut satırından verilmiş olan dataların kontrol sonucunu dönüyoruz.
            return initControl;
        }        
        private void StartPositionControlAndSet(ref bool initControl)
        {
            string[] spearator = { " " };
            string[] startPositions = CommandLineList[0].ToUpper().Split(spearator, StringSplitOptions.RemoveEmptyEntries);

            if (startPositions.Length == 3)
            {
                int roverPositionX;
                int roverPositionY;
                Directions roverDirections;

                if (int.TryParse(startPositions[0], out roverPositionX)
                        && int.TryParse(startPositions[1], out roverPositionY)
                        && Enum.TryParse(startPositions[2], out roverDirections)
                    )
                {
                    if (roverPositionX <= Plateau.AreaX && roverPositionY <= Plateau.AreaY)
                    {
                        StartPosition = new Position();
                        StartPosition.PositionX = roverPositionX;
                        StartPosition.PositionY = roverPositionY;
                        StartPosition.Direction = roverDirections;

                        CurrentPosition = new Position();
                        CurrentPosition.PositionX = roverPositionX;
                        CurrentPosition.PositionY = roverPositionY;
                        CurrentPosition.Direction = roverDirections;
                        initControl = true;

                    }
                }
            }
        }
        private bool CommandListControlAndSet(ref bool initControl)
        {
            if (initControl == true)
            {
                char[] commandList = CommandLineList[1].ToUpper().ToCharArray();
                for (int i = 0; i < commandList.Length; i++)
                {
                    if (commandList[i] != 'R' && commandList[i] != 'L' && commandList[i] != 'M')
                    {
                        initControl = false;
                        CommandList = null;
                        break;
                    }
                    else
                    {
                        CommandList.Add(commandList[i].ToString());
                    }
                }
            }

            return initControl;
        }
        public void Move()
        {
            switch (CurrentPosition.Direction)
            {
                case Directions.N:
                    if (CurrentPosition.PositionY + 1 <= Plateau.AreaY)
                        CurrentPosition.PositionY += 1;
                    else
                        Console.WriteLine("Gezgin Y düzleminde ve Kuzey yönüne doğru taşma yapacak bir harekette bulunmak istedi. Dönüş gerçekleşti ancak gitme hareketi engellendi!");
                    break;
                case Directions.E:
                    if (CurrentPosition.PositionX + 1 <= Plateau.AreaX)
                        CurrentPosition.PositionX += 1;
                    else
                        Console.WriteLine("Gezgin X düzleminde ve Doğu yönüne doğru taşma yapacak bir harekette bulunmak istedi. Dönüş gerçekleşti ancak gitme hareketi engellendi!");
                    break;
                case Directions.S:
                    if (CurrentPosition.PositionY - 1 >= 0)
                        CurrentPosition.PositionY -= 1;
                    else
                        Console.WriteLine("Gezgin Y düzleminde ve Güney yönüne doğru taşma yapacak bir harekette bulunmak istedi. Dönüş gerçekleşti ancak gitme hareketi engellendi!");
                    break;
                case Directions.W:
                    if (CurrentPosition.PositionX - 1 >= 0)
                        CurrentPosition.PositionX -= 1;
                    else
                        Console.WriteLine("Gezgin X düzleminde ve Batı yönüne doğru taşma yapacak bir harekette bulunmak istedi. Dönüş gerçekleşti ancak gitme hareketi engellendi!");
                    break;
                default:
                    break;
            }
        }
        public void RotateLeft()
        {
            switch (CurrentPosition.Direction)
            {
                case Directions.N:
                    CurrentPosition.Direction = Directions.W;
                    break;
                case Directions.W:
                    CurrentPosition.Direction = Directions.S;
                    break;
                case Directions.S:
                    CurrentPosition.Direction = Directions.E;
                    break;
                case Directions.E:
                    CurrentPosition.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        public void RotateRight()
        {
            switch (CurrentPosition.Direction)
            {
                case Directions.N:
                    CurrentPosition.Direction = Directions.E;
                    break;
                case Directions.E:
                    CurrentPosition.Direction = Directions.S;
                    break;
                case Directions.S:
                    CurrentPosition.Direction = Directions.W;
                    break;
                case Directions.W:
                    CurrentPosition.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }
        public void StartMove()
        {
            foreach (var command in CommandList)
            {
                switch (command)
                {
                    case "R":
                        RotateRight();
                        break;
                    case "L":
                        RotateLeft();
                        break;
                    case "M":
                        Move();
                        break;
                    default:
                        break;
                }
            }
            //Console.WriteLine($"Rover X - Y - D : {CurrentPosition.PositionX} - {CurrentPosition.PositionY} - {CurrentPosition.Direction}  ----  Plateau X - Y : {Plateau.AreaY} - {Plateau.AreaY}");
        }
    }
}
