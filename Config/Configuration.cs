using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using AdaBattleships.Models;

namespace AdaBattleships.Config
{
    public class Configuration
    {
        public GeneralConfig GeneralConfig { get; set; } = new GeneralConfig();
        public BoardConfig BoardConfig { get; set; } = new BoardConfig();
        public ShipsConfig ShipsConfig { get; set; } = new ShipsConfig();
        public static Configuration GetConfig()
        {
            if (!File.Exists("config.json"))
            {
               File.WriteAllText("config.json", JsonSerializer.Serialize(new Configuration()));
            }
            return JsonSerializer.Deserialize<Configuration>(File.ReadAllText("config.json"));
        }
    }
    public class GeneralConfig
    {
        public int Debug { get; set;}
    }
    public class BoardConfig
    {
        public int BoardY { get; set;}
        public int BoardX { get; set;}
    }
    public class ShipsConfig
    {
        public List<Ship> Ships { get; set; } = new()
        {
            new Ship()
            {
                Name = "Carrier",
                Size = 1
            }
        };
    }
}