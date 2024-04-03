using DataExporter.Model;

namespace DataExporter.Dtos;

public record CreatePolicyRequest
{
    public string PolicyNumber { get; init; }
    public decimal Premium { get; init; }
    public DateTime StartDate { get; init; }

    public Policy ToModel()
    {
        return new Policy
        {
            PolicyNumber = PolicyNumber,
            Premium = Premium,
            StartDate = StartDate
        };
    }
}
