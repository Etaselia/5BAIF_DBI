// See https://aka.ms/new-console-template for more information

using MongoDB_E1.Model;
using MongoDB.Bson;

namespace MongoDB_E1;

using System;
using System.Collections.Generic;
using Bogus;

class Program
{
    static void Main(string[] args)
    {
        var context = new SchoolContext("mongodb://localhost:27017", "MongoDB_E1");
        
        var lehrerTestData = GenerateLehrerTestData(10);
        context.Lehrer.InsertMany(lehrerTestData);

        var klassenTestData = GenerateKlasseTestData(5, lehrerTestData);
        context.Klassen.InsertMany(klassenTestData);

        var schuelerTestData = GenerateSchuelerTestData(20, klassenTestData);
        context.Schueler.InsertMany(schuelerTestData);

        var pruefungTestData = GeneratePruefungTestData(15, lehrerTestData);
        context.Pruefungen.InsertMany(pruefungTestData);
    }
    public static List<Lehrer> GenerateLehrerTestData(int count)
    {
        var lehrerFaker = new Faker<Lehrer>()
            .RuleFor(l => l.Id, f => ObjectId.GenerateNewId())
            .RuleFor(l => l.Vorname, f => f.Name.FirstName())
            .RuleFor(l => l.Zuname, f => f.Name.LastName())
            .RuleFor(l => l.Email, (f, l) => f.Internet.Email(l.Vorname, l.Zuname))
            .RuleFor(l => l.Gehalt, f => f.Random.Int(3000, 5000))
            .RuleFor(l => l.Lehrbefaehigung, f => f.Random.Bool());

        return lehrerFaker.Generate(count);
    }

    public static List<Klasse> GenerateKlasseTestData(int count, List<Lehrer> lehrerList)
    {
        var klasseFaker = new Faker<Klasse>()
            .RuleFor(k => k.Id, f => ObjectId.GenerateNewId())
            .RuleFor(k => k.Abteilung, f => f.Commerce.Department())
            .RuleFor(k => k.KV, f => f.PickRandom(lehrerList));

        return klasseFaker.Generate(count); // Assuming one class per teacher for simplicity
    }

    public static List<Schueler> GenerateSchuelerTestData(int studentsPerClass,List<Klasse> klassenList)
    {
        var schuelerFaker = new Faker<Schueler>()
            .RuleFor(s => s.Id, f => ObjectId.GenerateNewId())
            .RuleFor(s => s.Vorname, f => f.Name.FirstName())
            .RuleFor(s => s.Zuname, f => f.Name.LastName())
            .RuleFor(s => s.Gebdat, f => f.Date.Past(18))
            .RuleFor(s => s.SKlasse, f => f.PickRandom(klassenList));

        return schuelerFaker.Generate(studentsPerClass);
    }

    public static List<Pruefung> GeneratePruefungTestData(int examsPerTeacher,List<Lehrer> lehrerList)
    {
        var pruefungFaker = new Faker<Pruefung>()
            .RuleFor(p => p.Id, f => ObjectId.GenerateNewId())
            .RuleFor(p => p.Datum, f => f.Date.Recent())
            .RuleFor(p => p.Fach, f => f.Random.Word())
            .RuleFor(p => p.Note, f => f.Random.Double(1, 6))
            .RuleFor(p => p.Pruefer, f => f.PickRandom(lehrerList));

        return pruefungFaker.Generate(examsPerTeacher);
    }
}