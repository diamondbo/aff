using Microsoft.AspNetCore.Mvc;

public class AlpacaController : ControllerBase
{
    private readonly IAlpacaService _alpacaService;

    public AlpacaController(IAlpacaService alpacaService)
    {
        _alpacaService = alpacaService;
    }

    [HttpGet]
    [Route("alpaca/buyingpower")]
    public async Task<IActionResult> Getbuyingpower()
    {
        var buyPow = await _alpacaService.GetBuyingPower();
        var cash = await _alpacaService.GetCash();
        return Ok(new
        {
            BuyingPower = buyPow?.ToString("C") ?? "0",
            Cash = cash?.ToString("C") ?? "0"
        });
    }
    
    [HttpGet]
    [Route("alpaca/m-order")]
    public async Task<IActionResult> BuyAlpaca([FromQuery] string symbol, [FromQuery] int qty, [FromQuery] bool isBuy)
    {
        var buyPow = await _alpacaService.MakeMarketOrder(symbol, qty, isBuy);
        return Ok(buyPow);
    }
}