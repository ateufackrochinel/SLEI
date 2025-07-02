namespace SLEI_Backend.Dtos
{
    public class LogementDto
    {
        public int Id {get; set;}
        public string Descripction { get; set; }
        public string Adresse { get; set; }
        public int NbreAppartement { get; set; }

        public int NbreStudio { get; set; }

        public List<string> ImagePaths { get; set; }

    }
}
