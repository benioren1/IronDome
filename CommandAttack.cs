using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp;
using static System.Net.Mime.MediaTypeNames;



namespace IronDomeServerAttack
{
    internal class CommandAttack
    {


        public static async Task<string> ReadJsonAsync(string path)
        {
            try
            {
                await Task.Delay(5000);
                return await Task.Run(() => File.ReadAllText(path));
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty;
            }
        }
        public static async Task<Missile> LoadingFile(MessageEventArgs json1)
        {
            string newjson =  json1.ToString();
            var json = await Task.Run(
                async () => File.ReadAllText(newjson)
            );
            var missiles = JsonSerializer.Deserialize<Missile>(json);
            return missiles;
        }


        public static float Getdamge(string name)
        {
            Dictionary<string, float> MissileDamage = new Dictionary<string, float>();
            MissileDamage["Kasam"] = 100;
            MissileDamage["zalal"] = 120;
            MissileDamage["grad"] = 80;
            MissileDamage["shiab"] = 20;

            if (MissileDamage.ContainsKey(name))
            {
                var val = MissileDamage[name];
                return val;

            }
            return 0;

        }
        //public static async Task<List<Missile>> PrintJson()
        //{
        //    List<Missile> missiles = await CommandAttack.LoadingFile();
        //    foreach (var item in missiles)
        //    {
        //        await Task.Delay(item.Time * 1000); 

        //        Console.WriteLine($"Name: {item.Name}");
        //        Console.WriteLine($"Speed: {item.Speed}");
        //        Console.WriteLine($"Muss: {item.Muss}");

        //        // הדפסת Origin
        //        Console.WriteLine("Origin:");
        //        foreach (var kvp in item.Origin)
        //        {
        //            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        //        }

        //        Console.WriteLine($"Angle: {item.Angle}");
        //        Console.WriteLine($"Time: {item.Time}");
        //        Console.WriteLine("\n------------------------");
        //    }
        //    return missiles;
        //}

    }


}




