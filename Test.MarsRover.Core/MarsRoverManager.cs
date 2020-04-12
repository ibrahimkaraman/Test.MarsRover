using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.MarsRover.Entity;

namespace Test.MarsRover.Core
{
    public class MarsRoverManager : IMarsRoverManager
    {
        Plateau plateau;
        public void Start()
        {
            bool initControl;
            Console.WriteLine("Mars'da yeni alanlar keşfetmeye hoş geldiniz!");
            do
            {
                Console.Write("Keşfetmek istediğiniz alanın boyutlarını giriniz... (X Y) => ");

                plateau = new Plateau();
                plateau.CommandLine = Console.ReadLine();
                Console.WriteLine("");
                initControl = plateau.Init();
                if (initControl)
                {
                    do
                    {
                        Rover rover = new Rover(plateau);
                        Console.Write("Gezgin aracına ait başlangıç konumunu giriniz... (X Y D) => ");
                        rover.CommandLineList.Add(Console.ReadLine());
                        //Console.WriteLine("");
                        Console.Write("Gezgin aracının nasıl bir keşif yapmasını istediğiniz komut dizesini giriniz... (LMRM) => ");
                        rover.CommandLineList.Add(Console.ReadLine());
                        //Console.WriteLine("");

                        if (rover.Init())
                        {
                            plateau.RoverList.Add(rover);
                            rover.StartMove();
                        }
                        else
                        {
                            Console.WriteLine("Gezgin aracının giriş bilgileri tutarlı değil bu yüzden gezgin işlemi iptal edildi! ");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Yeni bir gezgin aracı ile keşif yapmak istiyor musunuz? E");

                    } while (Console.ReadKey().Key == ConsoleKey.E);
                }

                Console.WriteLine("");
                Console.WriteLine("");
            } while (!initControl);
        }

        public void WriteOutput()
        {
            Console.WriteLine("-------------------------- OUTPUT ----------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            if (plateau.RoverList.Count > 0)
            {
                foreach (var rover in plateau.RoverList)
                {
                    Console.WriteLine("Başlangıc konumu '" + rover.StartPosition.PositionX + " " + rover.StartPosition.PositionY + " " + rover.StartPosition.Direction + "' olan gezgin aracının şuanki konumu => '" + rover.CurrentPosition.PositionX + " " + rover.CurrentPosition.PositionY + " " + rover.CurrentPosition.Direction + "'");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Sonuç gösterilecek bir gezgin aracı tanımlanmadı!");
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------- OUTPUT ----------------------------");
        }
    }
}
