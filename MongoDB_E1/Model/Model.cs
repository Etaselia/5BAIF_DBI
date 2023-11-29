namespace MongoDB_E1.Model; 

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Bogus;

public class Lehrer
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Vorname { get; set; }
    public string Zuname { get; set; }
    public string Email { get; set; }
    public double Gehalt { get; set; }
    public bool Lehrbefaehigung { get; set; }
}

public class Klasse
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Abteilung { get; set; }
    
    public Lehrer KV { get; set; }
}

public class Schueler
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Vorname { get; set; }
    public string Zuname { get; set; }
    public DateTime Gebdat { get; set; }
    
    public Klasse SKlasse { get; set; }
}

public class Pruefung
{
    [BsonId]
    public ObjectId Id { get; set; }
    public DateTime Datum { get; set; }
    public string Fach { get; set; }
    public double Note { get; set; }
    
    public Lehrer Pruefer { get; set; }
}