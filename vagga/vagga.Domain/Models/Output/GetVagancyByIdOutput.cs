using Vagga.Domain.Models.Base;

namespace Vagga.Domain.Models.Output
{
    public class GetVagancyByIdOutput : BaseOutput
    {
        public Guid? Id { get; set; }
        public List<UrlVagancyById> UrlImages { get; set; }
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public string DimensionX { get; set; }
        public string DimensionY { get; set; }
        public string DimensionZ { get; set; }
        public double price { get; set; }
        public bool Pending { get; set; }
    }

    public class UrlVagancyById
    {
        public string? UrlMedia { get; set; }
    }
}
