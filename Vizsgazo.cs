using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace vizsgazok_console
{
    public class Vizsgazo
    {
        public string? name { get; set; }
        public string? subject { get; set; }
        public int score { get; set; }

        public static List<Vizsgazo> LoadFromJSON(string vizsgazok)
        {
            try
            {
                string json = File.ReadAllText(vizsgazok);
                return JsonSerializer.Deserialize<List<Vizsgazo>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt a fájl beolvasása közben: {ex.Message}");
                return new List<Vizsgazo>();
            }
        }
    }
}
