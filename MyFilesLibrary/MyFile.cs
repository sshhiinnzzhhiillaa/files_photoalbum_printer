using System;
using System.IO;

namespace MyFilesLibrary
{
    public static class MyFile
    {

        public static void SumOfLinesInFile(string inputFileName, string outputFileName)
        {
            using var streamReader = new StreamReader(inputFileName);

            using var outputFileStream = new FileStream(outputFileName, FileMode.Create);
            
            using var binaryWriter = new BinaryWriter(outputFileStream);
            
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                var temp = line.Split(new char[] {'-', ' ', '/', ',', '_', '+', '='});
                if (temp.Length != 3) continue;
                int sum = 0;
                foreach (var item in temp)
                {
                    if (!int.TryParse(item, out var parseItem)) continue;
                    sum += parseItem;
                }
                binaryWriter.Write(sum + "\n");
            }
        }
        
    }
}