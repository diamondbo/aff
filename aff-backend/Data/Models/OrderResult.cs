public class OrderResult
{
    public string? OrderId { get; set; }
    public bool Success { get; set; }
    public float? Qty { get; set; }
    public string? Message { get; set; }
    public string? Symbol { get; set; }
}