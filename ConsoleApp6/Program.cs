using System;
using System.Collections.Generic;
using ClassLibrary1;

//interface Устройство Печати -> abstract class Принтер -> class Лазерный Принтер.

namespace ConsoleApp6
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var printerList = new List<IPrintDevice>()
            {
                new LaserPrinter(1, "OOO Lugovichka", "URAN-007", 500),
                new LaserPrinter(2, "OOO Lugovichka", "URAN-1337", 500),
                new LaserPrinter(1, "OOO ARASAKA", "TOKIO-1", 700),
                new LaserPrinter(2, "OOO ARASAKA", "TOKIO-2", 900),
                new LaserPrinter(3, "OOO ARASAKA", "TOKIO-2", 1000)
            };

            while (true)
            {
                if (!ChoosePrinter(printerList, out var printer)) 
                {
                    continue;
                }

                if (!ChooseAction(out var action))
                {
                    continue;
                }

                switch (action)
                {
                    case 0:
                    {
                        Console.WriteLine("Enter text");
                        var text = Console.ReadLine();
                        printer.Print(text);
                        break;   
                    }
                    case 1:
                    {
                        if (!ChooseColor(out var color)) 
                        {
                            continue;        
                        }
                        if(printer is LaserPrinter laserPrinter)
                        laserPrinter.PrintColor = color;
                        break;
                    }
                    case 2:
                    {
                        if (printer is LaserPrinter laserPrinter)
                        laserPrinter.FillUpСartridge();
                        Console.WriteLine("The cartridge is full");
                        break;
                    }
                    case 3:
                    {
                        if (printer is LaserPrinter laserPrinter)
                        laserPrinter.Wait();
                        Console.WriteLine("Printer is waiting");
                        break;
                    }
                    case 4:
                    {
                        if (printer is LaserPrinter laserPrinter)
                        laserPrinter.FillUp();
                        Console.WriteLine("Printer fill up");
                        break;
                    }
                }
            }
        }

        private static bool ChoosePrinter(List<IPrintDevice> printerList, out IPrintDevice printer) 
        {
            Console.WriteLine("Choose the printer");

            for (var i = 0; i < printerList.Count; i++)
            {
                Console.WriteLine($"{i} {printerList[i].Manufacturer} {printerList[i].Model}");
            }

            var printerParsed = int.TryParse(Console.ReadLine(), out var selectedPrinter);

            if (!printerParsed)
            {
                Console.WriteLine("Wrong, please try again");
                printer = null;
                return false;
            }

            printer = printerList[selectedPrinter];

            return true; 
        }

        private static bool ChooseAction(out int action)
        {
            Console.WriteLine("Choose the action");

            Console.WriteLine("0 - print text");
            Console.WriteLine("1 - choose color");
            Console.WriteLine("2 - fill up cartridge");
            Console.WriteLine("3 - wait");
            Console.WriteLine("4 - fill up printer");

            var parsed = int.TryParse(Console.ReadLine(), out var selectedAction);

            if (!parsed)
            {
                Console.WriteLine("Wrong, please try again");
                action = -1;
                return false;
            }

            action = selectedAction;

            return true;
        }

        private static bool ChooseColor(out ConsoleColor color)
        {
            Console.WriteLine("Choose the color");

            Console.WriteLine("0 - white");
            Console.WriteLine("1 - red");
            Console.WriteLine("2 - green");
            Console.WriteLine("3 - blue");

            var parsed = int.TryParse(Console.ReadLine(), out var selectedNumber);

            if (!parsed)
            {
                Console.WriteLine("Wrong, please try again");
                color = ConsoleColor.White;
                return false;
            }

            switch (selectedNumber) 
            {
                case 1:
                    color = ConsoleColor.Red;
                    break;
                case 2:
                    color = ConsoleColor.Green;
                    break;
                case 3:
                    color = ConsoleColor.Blue;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }

            return true;
        }
    }
}