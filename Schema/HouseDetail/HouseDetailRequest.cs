namespace Schema;

public class HouseDetailRequest
{
    public int HouseId { get; set; }

    public int HouseholderNumber { get; set; }
    public int Floor { get; set; }
    public bool IsEmpty { get; set; }
    public bool IsSmall { get; set; }
}
