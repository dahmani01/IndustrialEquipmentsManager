using System.Text.Json.Serialization;

namespace CPG_Platform.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleClass
    {
        Admin = 1,
        Manager = 2,
        Ouvrier = 3,
    }
}