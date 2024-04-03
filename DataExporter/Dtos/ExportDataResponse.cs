namespace DataExporter.Dtos;

public record ExportDataResponse
{
    public IEnumerable<PolicyWithNotesDto> Data { get; init; } = new List<PolicyWithNotesDto>();
}

public record PolicyWithNotesDto
{
    public string? PolicyNumber { get; init; }
    public decimal Premium { get; init; }
    public DateTime StartDate { get; init; }

    /// <summary> A list of the notes' text. </summary>
    public IEnumerable<string> Notes { get; set; }
}