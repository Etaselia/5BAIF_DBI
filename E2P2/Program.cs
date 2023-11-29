using System.Text.Json;


public class Klasse
{
    public string Id { get; set; }
    public Kv Kv { get; set; }
    public List<Lehrer> Lehrer { get; set; }
    public List<Gegenstaende> GegenstaendeList { get; set; } // List of Gegenstaende instances
}

public class Gegenstaende
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<Zeiten> Zeiten { get; set; }
}

public class Kv
{
    public string Id { get; set; }
    public string Zuname { get; set; }
    public string Vorname { get; set; }
}

public class Lehrer
{
    public string Id { get; set; }
    public string Zuname { get; set; }
    public string Vorname { get; set; }
}

public class Zeiten
{
    public string Wochentag { get; set; }
    public int Stunde { get; set; }
}    


class Program {
    static async Task Main() {
        Klasse k = new Klasse();
        File.WriteAllTextAsync("/home/eta/RiderProjects/E2/E2P2/stundenplan_output.json",JsonSerializer.Serialize(k));
        
    }
}