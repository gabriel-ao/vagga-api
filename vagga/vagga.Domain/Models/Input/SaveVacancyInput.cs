namespace Vagga.Domain.Models.Input
{
    public class SaveVacancyInput
    {
        public Guid? Id { get; set; }
        public List<Url> UrlImages { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public string DimensionX { get; set; }
        public string DimensionY { get; set; }
        public string DimensionZ { get; set; }
        public double price { get; set; }
    }

 
    public class Url
    {
        public string? UrlMedia { get; set; }
    }
}
