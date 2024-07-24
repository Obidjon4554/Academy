using System.Text.Json;
using Models;

namespace O_quvMarkaz.Services;

public partial class Center
{
    private List<Mentorlar> mentorlar = new List<Mentorlar>();
    private string jsonPathMentor = Path.Combine(Directory.GetCurrentDirectory(), "mentorlar.json");

    public bool AddMentor(string name)
    {
        if (name != null)
        {
            int id = mentorlar.Count > 0 ? mentorlar.Max(m => m.Id) + 1 : 1;
            mentorlar.Add(new Mentorlar() { Id = id, Name = name });
            string serialized = JsonSerializer.Serialize(mentorlar);
            using (StreamWriter writer = new StreamWriter(jsonPathMentor))
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
    public bool UpdateMentor(int id, string name)
    {
        if (mentorlar.Count > 0)
        {
            var mentor = mentorlar.FirstOrDefault(m => m.Id == id);
            if (mentor != null)
            {
                mentor.Name = name;
                Console.WriteLine("Successfuly updated");
            }
            else
            {
                Console.WriteLine("Mentor not found");
            }
            string serialized = JsonSerializer.Serialize<List<Mentorlar>>(mentorlar);
            using (StreamWriter sw = new StreamWriter(jsonPathMentor))
            {
                sw.WriteLine(serialized);
            }
            return true;
        }
        else
        {
            Console.WriteLine("Mentors not found");
            return false;
        }
    }
    public bool DeleteMentor(int id)
    {
        if (mentorlar.Count > 0)
        {
            var mentor = mentorlar.FirstOrDefault(x => x.Id == id);
            if (mentor != null)
            {
                mentorlar.Remove(mentor);
                Console.WriteLine("Successfuly deleted");
            }
            else
                Console.WriteLine("Course not found");
            string serialized = JsonSerializer.Serialize<List<Mentorlar>>(mentorlar);
            using (StreamWriter sw = new StreamWriter(jsonPathMentor))
            {
                sw.WriteLine(serialized);
            }
            return true;
        }
        else
            return false;
    }
    public bool ListMentorlar()
    {
        mentorlar = JsonReadMentor();
        if (mentorlar.Count > 0)
        {
            foreach (var mentor in mentorlar)
            {
                Console.WriteLine($"Mentor: {mentor.Id}, Name: {mentor.Name}");
            }
            return true;
        }
        else
        {
            Console.WriteLine("Mentors not found!");
            return false;
        }
    }
    public List<Mentorlar> JsonReadMentor()
    {
        using (StreamReader reader = new StreamReader(jsonPathMentor))
        {
            string json = reader.ReadToEnd();
            mentorlar = JsonSerializer.Deserialize<List<Mentorlar>>(json);
        }
        return mentorlar;
    }
}
