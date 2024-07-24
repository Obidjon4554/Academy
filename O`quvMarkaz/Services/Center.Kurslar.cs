using System.Text.Json;
using Models;
namespace O_quvMarkaz.Services;

public partial class Center
{
    private List<Kurslar> kurslar = new List<Kurslar>();
    private string jsonPathKurs = Path.Combine(Directory.GetCurrentDirectory(), "kurslar.json");


    public bool AddKurs(string name)
    {
        if (name != "")
        {
            int id = kurslar.Count > 0 ? kurslar.Max(k => k.Id) + 1 : 1;
            kurslar.Add(new Kurslar() { Id = id, Name = name });
            string serialized = JsonSerializer.Serialize(kurslar);
            using (StreamWriter writer = new StreamWriter(jsonPathKurs))
            {
                writer.WriteLine(serialized);
            }
            return true;
        }
        else
        {
            Console.WriteLine("Error, please try again!");
            return false;
        }
    }
    public void UpdateKurs(int id, string name)
    {
        
        var kurs = kurslar.FirstOrDefault(k => k.Id == id);
        if (kurs != null)
        {
            kurs.Name = name;
            Console.WriteLine("Successfuly updated");

        }
        else
        {
            Console.WriteLine("Course not found");
        }

        string serialized = JsonSerializer.Serialize<List<Kurslar>>(kurslar);
        using (StreamWriter sw = new StreamWriter(jsonPathKurs))
        {
            sw.WriteLine(serialized);
        }
    }
    public void DeleteKurs(int id)
    {
        var kurs = kurslar.FirstOrDefault(x => x.Id == id);
        if (kurs != null)
        {
            kurslar.Remove(kurs);
            Console.WriteLine("Successfuly deleted");
        }
        else
            Console.WriteLine("Course not found");
        string serialized = JsonSerializer.Serialize<List<Kurslar>>(kurslar);
        using (StreamWriter sw = new StreamWriter(jsonPathKurs))
        {
            sw.WriteLine(serialized);
        }
    }
    public bool ListKurslar()
    {
        kurslar = JsonReadKurs();
        if (kurslar.Count > 0)
        {
            foreach (var kurs in kurslar)
            {
                Console.WriteLine($"Course: {kurs.Id}, Name: {kurs.Name}");
            }
            return true;
        }
        else
        {
            Console.WriteLine("Courses not found!");
            return false;
        }
    }
    public List<Kurslar> JsonReadKurs()
    {
        using (StreamReader reader = new StreamReader(jsonPathKurs))
        {
            string json = reader.ReadToEnd();
            kurslar = JsonSerializer.Deserialize<List<Kurslar>>(json);
        }
        return kurslar;
    }
}
