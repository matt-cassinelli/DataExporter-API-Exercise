using DataExporter.Dtos;

namespace DataExporter.Model;

public class Policy
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; }
    public decimal Premium { get; set; }
    public DateTime StartDate { get; set; }

    public ICollection<Note> Notes { get; } = new List<Note>();

    public ReadPolicyResponse ToDto()
    {
        return new ReadPolicyResponse
        {
            Id = Id,
            PolicyNumber = PolicyNumber,
            Premium = Premium,
            StartDate = StartDate
        };
    }

    public PolicyWithNotesDto ToNotesDto()
    {
        return new PolicyWithNotesDto
        {
            PolicyNumber = PolicyNumber,
            Premium = Premium,
            StartDate = StartDate,
            Notes = Notes.Select(x => x.Text)
        };
    }
}
