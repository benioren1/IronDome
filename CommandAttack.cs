using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace AttackServer2
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
        public static async Task<List<Missile>> LoadingFile()
        {
            var json = await Task.Run(
                async () => File.ReadAllText("C:\\Users\\benio\\source\\repos\\AttackServer2\\json1.json")
            );
            var missiles = JsonSerializer.Deserialize<List<Missile>>(json);
            return missiles;
        }


        public static double Getdamge(string name)
        {
            Dictionary<string, double> MissileDamage = new Dictionary<string, double>();
            MissileDamage["Kasam"] = 0.1;
            MissileDamage["zalal"] = 0.21;
            MissileDamage["grad"] = 0.2;
            MissileDamage["shiab"] = 0.1;

            if (MissileDamage.ContainsKey(name))
            {
                var val = MissileDamage[name];
                return val;

            }
            return 0;

        }
        public static async Task<List<Missile>> PrintJson()
        {
            List<Missile> missiles = await CommandAttack.LoadingFile();
            foreach (var item in missiles)
            {
                await Task.Delay(item.Time * 1000); // המתנה לפי זמן הטיל

                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Speed: {item.Speed}");
                Console.WriteLine($"Muss: {item.Muss}");

                // הדפסת Origin
                Console.WriteLine("Origin:");
                foreach (var kvp in item.Origin)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }

                Console.WriteLine($"Angle: {item.Angle}");
                Console.WriteLine($"Time: {item.Time}");
                Console.WriteLine("\n------------------------");
            }
            return missiles;
        }

    }


}




