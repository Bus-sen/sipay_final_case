namespace Schema;

public class BillRequest
{

    public int HouseId { get; set; }
    public int Dues { get; set; }
    public decimal ElectricBill { get; set; }
    public decimal WaterBill { get; set; }
    public decimal GasBill { get; set; }
}
