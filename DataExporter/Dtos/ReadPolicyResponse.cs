namespace DataExporter.Dtos;

public record ReadPolicyResponse
{
    public int Id { get; init; }
    public string PolicyNumber { get; init; }
    public decimal Premium { get; init; }
    public DateTime StartDate { get; init; }
}
