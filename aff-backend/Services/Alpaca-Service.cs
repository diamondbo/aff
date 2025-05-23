using Alpaca.Markets;
using Microsoft.Extensions.Options;

public class AlpacaSettings
{
    public string AlpacaKey { get; set; } = string.Empty;
    public string AlpacaSecret { get; set; } = string.Empty;
    public string AlpacaEndpoint { get; set; } = string.Empty;
}
public interface IAlpacaService
{
    Task<Decimal?> GetBuyingPower();
    Task<Decimal?> GetCash();
    Task<OrderResult?> MakeMarketOrder(string symbol, int quantity, bool isBuy);

}

public class AlpacaService : IAlpacaService
{
    private readonly AlpacaSettings _settings;
    public AlpacaService(IOptions<AlpacaSettings> settings)
    {
        _settings = settings.Value;
    }
    private IAlpacaTradingClient CreateClient()
    {
        return Alpaca.Markets.Environments.Paper
            .GetAlpacaTradingClient(new SecretKey(_settings.AlpacaKey, _settings.AlpacaSecret));
    }
    public async Task<decimal?> GetBuyingPower()
    {
        try
        {
            var client = CreateClient();
            var account = await client.GetAccountAsync();
            return account.BuyingPower;
        }
        catch (RestClientErrorException ex)
        {
            Console.WriteLine($"Alpaca API error: {ex.Message}");
            throw;
        }
    }
    public async Task<decimal?> GetCash()
    {
        try
        {
            var client = CreateClient();
            var account = await client.GetAccountAsync();
            return account.TradableCash;
        }
        catch (RestClientErrorException ex)
        {
            Console.WriteLine($"Alpaca API error: {ex.Message}");
            throw;
        }
    }
    public async Task<OrderResult?> MakeMarketOrder(string symbol, int quantity, bool isBuy)
    {
        try
        {
            var client = Alpaca.Markets.Environments.Paper
            .GetAlpacaTradingClient(new SecretKey(_settings.AlpacaKey, _settings.AlpacaSecret));

            var orderRequest = isBuy
                ? MarketOrder.Buy(symbol, quantity)
                : MarketOrder.Sell(symbol, quantity);

            var order = await client.PostOrderAsync(orderRequest);
            return new OrderResult
            {
                Success = true,
                Symbol = symbol,
                Qty = quantity,
                OrderId = order.OrderId.ToString(),
                Message = $"Order submitted successfully: {order.OrderId}"
            };
        }
        catch (RestClientErrorException ex)
        {
            Console.WriteLine($"Alpaca API error: {ex.Message}");
            throw;
        }
    }
}