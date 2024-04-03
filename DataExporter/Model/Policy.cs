using DataExporter.Dtos;

namespace DataExporter.Model;

public class Policy
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }

    public ReadPolicyDto ToDto()
    {
        return new ReadPolicyDto
        {
            Id = Id,
            PolicyNumber = PolicyNumber,
            Premium = Premium,
            StartDate = StartDate
        };
    }
}
