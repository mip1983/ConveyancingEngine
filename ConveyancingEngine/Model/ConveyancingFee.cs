namespace ConveyancingEngine.Model;

public class ConveyancingFee
{
    public required string Name { get; set; }

    public List<TransactionType> TransactionTypes { get; set; } = [];

    public float Cost { get; set; }
}
