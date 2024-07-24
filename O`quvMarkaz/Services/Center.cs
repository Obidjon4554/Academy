namespace O_quvMarkaz.Services
{
    public partial class Center
    {
        public Center()
        {
            EnsureFileExists();
            arizalar = JsonReadAriza();
            kurslar = JsonReadKurs();
            mentorlar = JsonReadMentor();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(jsonPathAriza))
            {
                File.WriteAllText(jsonPathAriza, "[]");
            }
            if (!File.Exists(jsonPathKurs))
            {
                File.WriteAllText(jsonPathKurs, "[]");
            }
            if (!File.Exists(jsonPathMentor))
            {
                File.WriteAllText(jsonPathMentor, "[]");
            }
        }
    }
}
