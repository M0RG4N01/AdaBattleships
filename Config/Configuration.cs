using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using AdaBattleships.Models;

namespace AdaBattleships.Config;

public class Configuration
{
    private static Configuration _instancedConfig;
    public GeneralConfig GeneralConfig { get; set; } = new();
    public BoardConfig BoardConfig { get; set; } = new();
    public ShipsConfig ShipsConfig { get; set; } = new();
    public static Configuration GetConfig()
    {
        if (!File.Exists("config.json"))
        {
            var configuration = new Configuration();
            _instancedConfig = configuration;
            File.WriteAllText("config.json", JsonSerializer.Serialize(configuration, new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
            return _instancedConfig;
        }
        _instancedConfig = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("config.json"));
        return _instancedConfig;
    }
}
public class GeneralConfig
{
    public int Debug { get; set;}
}
public class BoardConfig
{
    public int BoardY { get; set; } = 10;
    public int BoardX { get; set; } = 10;
}
public class ShipsConfig
{
    public List<Ship> Ships { get; set; } = new()
    {
        new Ship
        {
            Name = "Carrier",
            Size = 1
        },
        new Ship
        {
            Name = "Patrol Boat",
            Size = 2
        },
        new Ship
        {
            Name = "Destroyer",
            Size = 3
        },
        new Ship
        {
            Name = "Battleship",
            Size = 4
        },
        new Ship
        {
            Name = "Submarine",
            Size = 5
        }
    };
}