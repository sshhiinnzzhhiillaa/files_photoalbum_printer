using System;
using System.Drawing;

namespace ClassLibrary1
{
    public class LaserPrinter : Printer
    {
        private int MaxCartridgeSize { get; set; }
        private int СartridgeSize { get; set; }
        public ConsoleColor PrintColor { get; set; }

        public LaserPrinter(uint serialNumber, string manufacturer, string model, int cartridge)
            : base(serialNumber, manufacturer, model)
        {
            СartridgeSize = cartridge;
            MaxCartridgeSize = cartridge;
            PrintColor = ConsoleColor.White;
        }

        public void FillUpСartridge()
        {
            СartridgeSize = MaxCartridgeSize;
        }

        public override void Print(string text)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = PrintColor;
            base.Print(text);
            СartridgeSize--;
            Console.ForegroundColor = color;
        }

        public override bool CanPrint()
        {
            return base.CanPrint() && (СartridgeSize > 0);
        }
    }
}