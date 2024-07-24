using System.Text.Json;
using Models;

namespace O_quvMarkaz.Services
{
    public partial class Center
    {
        private List<Arizalar> arizalar = new List<Arizalar>();
        private string jsonPathAriza = Path.Combine(Directory.GetCurrentDirectory(), "arizalar.json");

        public void AddAriza(string name, string surname, string phoneNumber)
        {
            int id = arizalar.Count > 0 ? arizalar.Max(a => a.Id) + 1 : 1;
            arizalar.Add(new Arizalar() { Id = id, Name = name, SurName = surname, PhoneNumber = phoneNumber });
            SaveToJson();
        }

        public void UpdateAriza(int id, string name, string surname, string phoneNumber)
        {
            var ariza = arizalar.FirstOrDefault(a => a.Id == id);
            if (ariza != null)
            {
                ariza.Name = name;
                ariza.SurName = surname;
                ariza.PhoneNumber = phoneNumber;
                SaveToJson();
                Console.WriteLine("Successfuly updated");

            }
            else
            {
                Console.WriteLine("Petition Not Found");
            }
        }

        public void DeleteAriza(int id)
        {
            var ariza = arizalar.FirstOrDefault(x => x.Id == id);
            if (ariza != null)
            {
                arizalar.Remove(ariza);
                SaveToJson();
                Console.WriteLine("Successfuly deleted");
            }
            else
            {
                Console.WriteLine("Petition Not Found");
            }
        }

        public bool ListArizalar()
        {
            arizalar = JsonReadAriza();
            if (arizalar.Count < 1)
            {
                Console.WriteLine("Petitions Not Found.");
                return false;
            }
            else
            {
                foreach (var ariza in arizalar)
                {
                    Console.WriteLine($"Petition: {ariza.Id}  , Name: {ariza.Name}, Surname: {ariza.SurName}, PhoneNumber: {ariza.PhoneNumber}");
                }
                return true;
            }
        }

        public List<Arizalar> JsonReadAriza()
        {
            string json = File.ReadAllText(jsonPathAriza);
            return string.IsNullOrWhiteSpace(json) ? new List<Arizalar>() : JsonSerializer.Deserialize<List<Arizalar>>(json);
        }

        private void SaveToJson()
        {
            string serialized = JsonSerializer.Serialize(arizalar);
            File.WriteAllText(jsonPathAriza, serialized);
        }
    }
}
