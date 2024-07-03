public class TransportationDTO
{
    public string Name { get; set; } = string.Empty;
    public List<string> routes { get; set; } = new();
}


public class TransportationData
{
    public List<Line> Lines { get; set; }
}

public class Line
{
    public string Name { get; set; }
    public List<string> Route { get; set; }
}