using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonDemo
{
    // TODO: Schreiben Sie Ihre Modelklassen, die das Dokument stundenplan.json abbilden können.
// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
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
        public List<Gegenstaende> Gegenstaende { get; set; }
    }

    public class Klasse
    {
        public string Id { get; set; }
        public Kv Kv { get; set; }
        public List<Lehrer> Lehrer { get; set; }
    }

    public class Zeiten
    {
        public string Wochentag { get; set; }
        public int Stunde { get; set; }
    }




    class Program
    {
        static async Task Main() {
            // Wichtig: Bei Copy to Output Directory muss im Solution Explorer bei stundenplan.json
            //          die Option Copy Always gesetzt werden-
            // Note that this is using an absolute path since rider has some weird definition of file structure, just enter your file correctly her
            using var filestream = new FileStream("/home/eta/RiderProjects/E2/E2/stundenplan.json", FileMode.Open, FileAccess.Read);

            // Liest das Dokument in die Variable stdplan ein. Da es ein Array ist, wird hier auch
            // ein Array erstellt.
            Klasse[]? stdplan = await JsonSerializer.DeserializeAsync<Klasse[]>(filestream);
            Console.WriteLine($"Es wurden {stdplan?.Length} Klassen geladen.");

            // TODO: Geben Sie alle Lehrer (ID, Vorname, Zuname) der Schule aus.
            foreach (var VARIABLE in stdplan) {
                foreach (var item in VARIABLE.Lehrer) {
                    Console.WriteLine("---");
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Vorname);
                    Console.WriteLine(item.Zuname);
                }
                
            }
            
            // TODO: Geben Sie alle Gegenstände (ID, Name) der Schule aus.
            Dictionary<String, String> outputDict = new();
            foreach (var klasse in stdplan) {
                foreach (var Lehrer in klasse.Lehrer) {
                    foreach (var gegenstaende in Lehrer.Gegenstaende) {
                        // lul
                        try {
                            outputDict.Add(gegenstaende.Id,gegenstaende.Name);
                            Console.WriteLine("---");
                            Console.WriteLine(gegenstaende.Id);
                            Console.WriteLine(gegenstaende.Name);
                        }
                        catch (Exception e){
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
        }
    }
}