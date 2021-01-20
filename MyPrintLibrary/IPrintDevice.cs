using System;

namespace ClassLibrary1
{
    public interface IPrintDevice
    {
        uint SerialNumber { get; }
        
        public string Manufacturer { get; }
        
        public string Model { get; }

        bool Await { get; }

        void Print(string text);

        void Wait();
    }
}