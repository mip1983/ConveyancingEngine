using ConveyancingEngine.Model;

namespace ConveyancingEngine.Service;

public class QuoteService : IQuoteService
{
    /// <summary>
    /// Function that takes a quote request and calculates the quote response by applying the fees and adding a percentage of the
    //  property value.
    /// </summary>
    /// <param name="quoteRequest">The quote requested.</param>
    /// <returns>A quote response.</returns>
    public QuoteResponse GetQuote(QuoteRequest quoteRequest)
    {
        var fees = GetConveyancingFees(quoteRequest.TransactionType);
        var quoteResponse = new QuoteResponse();
        var total = 0f;

        foreach (var fee in fees)
        {
            if (fee.TransactionTypes.Contains(quoteRequest.TransactionType))
            {
                total += fee.Cost;
                quoteResponse.Fees.Add(fee);
            }
        }

        foreach (var addOn in quoteRequest.AddOns)
        {
            total += addOn.Cost;
            quoteResponse.Fees.Add(new ConveyancingFee
            {
                Name = addOn.Name,
                Cost = addOn.Cost
            });
        }

        total += quoteRequest.PropertyValue * 0.01f;
        quoteResponse.Fees.Add(new ConveyancingFee
        {
            Name = "Property Value Percentage",
            Cost = quoteRequest.PropertyValue * 0.01f
        });

        quoteResponse.Total = total;

        return quoteResponse;
    }


    /// <summary>
    /// Function to return a fixed list of conveyancing fees by transaction type.
    /// </summary>
    /// <param name="transactionType">Type of transaction.</param>
    /// <returns>List of fees</returns>
    public List<ConveyancingFee> GetConveyancingFees(TransactionType transactionType)
    {
        var fees = new List<ConveyancingFee>()
        {
            new() {
                Name = "Legal Fee",
                TransactionTypes = [
                    TransactionType.Sale,
                    TransactionType.Purchase
                ],
                Cost = 500
            },
            new() {
                Name = "Search Fee",
                TransactionTypes = [
                    TransactionType.Sale,
                    TransactionType.Purchase
                ],
                Cost = 250
            },
            new() {
                Name = "Bank Transfer Fee",
                TransactionTypes = [
                    TransactionType.Sale,
                    TransactionType.Purchase
                ],
                Cost = 50
            },
            new() {
                Name = "Land Registry Fee",
                TransactionTypes = [
                    TransactionType.Sale,
                    TransactionType.Purchase
                ],
                Cost = 250
            },
            new() {
                Name = "Stamp Duty",
                TransactionTypes = [
                    TransactionType.Purchase
                ],
                Cost = 1000
            }
        };

        return fees.Where(f => f.TransactionTypes.Contains(transactionType)).ToList();
    }

    public List<QuoteAddOn> GetQuoteAddOns()
    {
        return
        [
            new() {
                Name = "Priority response",
                Cost = 100
            },
            new() {
                Name = "Portal access with online support",
                Cost = 100
            }
        ];
    }
}
