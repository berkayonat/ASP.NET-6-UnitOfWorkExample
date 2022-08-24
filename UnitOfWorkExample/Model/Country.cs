using System.Text.Json.Serialization;

namespace UnitOfWorkExample.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public List<Hotel>? Hotel { get; set; }
    }
}
