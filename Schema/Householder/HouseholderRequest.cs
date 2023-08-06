using System.Text.Json.Serialization;

namespace Schema;

public class HouseholderRequest
{
    [JsonIgnore]
    public int HouseholderNumber { get; set; }
    public string HouseholderTc { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool HaveCar { get; set; }

}
