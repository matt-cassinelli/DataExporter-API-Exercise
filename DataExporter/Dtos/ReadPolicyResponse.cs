namespace DataExporter.Dtos;

public record ReadPolicyResponse
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }
}
