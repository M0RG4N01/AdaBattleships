using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdaBattleships.Models;

public class Ship
{
    public string Name { get; set;}
    public int Size { get; set;}
    
    [JsonIgnore]
    public int X { get; set;}
    [JsonIgnore]
    public int Y { get; set;}
    [JsonIgnore]
    public bool IsHorizontal { get; set;}
    [JsonIgnore]
    public List<(int, int)> Hits { get; set;} = new();
}