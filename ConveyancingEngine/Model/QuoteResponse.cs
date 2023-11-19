namespace ConveyancingEngine.Model;

public class QuoteResponse
{
    public List<ConveyancingFee> Fees { get; set; } = [];

    public float Total { get; set; }
}
