using System.ComponentModel.DataAnnotations;

namespace ConveyancingEngine.Model;

public class QuoteRequest
{
    public int PropertyValue { get; set; }

    [Required]
    public string? Postcode { get; set; }

    [Required]
    public TransactionType TransactionType { get; set; }

    public List<QuoteAddOn> AddOns { get; set; } = [];
}