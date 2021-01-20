using System;

namespace ClassLibrary1
{
    public abstract class Printer : IPrintDevice
    {
        public uint SerialNumber { get; }
        public bool Await { get; private set; }
        public string Manufacturer { get; }
        public string Model { get; }

        protected Printer(uint serialNumber, string manufacturer, string model)
        {
            SerialNumber = serialNumber;
            Manufacturer = manufacturer;
            Model = model;
        }

        public virtual void Print(string text)
        {
            if (CanPrint())
                Console.WriteLine(text);
            else
                Console.WriteLine("Cartridge is empty or printer is waiting");
        }

        public virtual bool CanPrint()
        {
            return !Await;
        }

        public virtual void Wait()
        {
            Await = true;
        }

        public void FillUp()
        {
            if (Await)
                Await = false;
        }
    }
}