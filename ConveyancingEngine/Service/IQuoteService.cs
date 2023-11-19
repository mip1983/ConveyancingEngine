using ConveyancingEngine.Model;

namespace ConveyancingEngine.Service;

public interface IQuoteService
{
    List<ConveyancingFee> GetConveyancingFees(TransactionType transactionType);

    QuoteResponse GetQuote(QuoteRequest quoteRequest);

    List<QuoteAddOn> GetQuoteAddOns();
}