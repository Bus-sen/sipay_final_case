namespace Schema;

public class HouseholderResponse
{
    public int HouseholderNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool HaveCar { get; set; }

    public virtual List<HouseDetailResponse> HouseDetails { get; set; }
}
