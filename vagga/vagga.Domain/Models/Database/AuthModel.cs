namespace Vagga.Domain.Models.Database
{
    public class AuthModel
    {

        public Guid? Id { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? active { get; set; }

    }
}
