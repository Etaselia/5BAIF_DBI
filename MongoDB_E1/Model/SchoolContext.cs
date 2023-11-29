namespace MongoDB_E1.Model; 

using MongoDB.Driver;

public class SchoolContext
{
    private readonly IMongoDatabase _database;

    public SchoolContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        client.DropDatabase(databaseName);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Lehrer> Lehrer => _database.GetCollection<Lehrer>("Lehrer");
    public IMongoCollection<Klasse> Klassen => _database.GetCollection<Klasse>("Klassen");
    public IMongoCollection<Schueler> Schueler => _database.GetCollection<Schueler>("Schueler");
    public IMongoCollection<Pruefung> Pruefungen => _database.GetCollection<Pruefung>("Pruefungen");
}
