using System.Text.Json.Serialization;

namespace seChat.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore] public string Password { get; set; }
    }
}
