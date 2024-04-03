using DataExporter.Model;

namespace DataExporter.Dtos;

public record CreatePolicyRequest
{
    public string PolicyNumber { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }

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
