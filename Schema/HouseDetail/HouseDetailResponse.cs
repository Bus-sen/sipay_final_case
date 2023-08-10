namespace Schema;

public class HouseDetailResponse
{
    public int HouseId { get; set; }

    public int HouseholderNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Floor { get; set; }
    public bool IsEmpty { get; set; }
    public bool IsSmall { get; set; }

    //public virtual List<BillResponse> Bills { get; set; }
}
