using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace EP1
{
    class Program
    {
        static void Serialize(ANL analys, string serializepath)
        {
            var json = JsonConvert.SerializeObject(analys, Formatting.Indented);
            Console.WriteLine(json);
            File.WriteAllText(serializepath, json);
        }
        static void Main(string[] args)
        {
            string ex = @"C:\Users\37525\Desktop\123.txt";
            Console.WriteLine("Enter path to the file. Expml: "+ex );
            string FileP =  Console.ReadLine() ;
            string result = Path.GetFileNameWithoutExtension(FileP);
           
            ANL analys = new ANL();
            analys.QQQ(FileP);
            if(analys.k==0)
                Serialize(analys, result+".json");

        }
    }
}
