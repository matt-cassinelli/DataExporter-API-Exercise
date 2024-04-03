namespace DataExporter.Dtos;

/// <remarks>
/// Rather than returning a list of policies directly, this DTO allows us to add additional properties in the
/// future, without breaking the API contract and needing a new API version. (Open/closed principle)
/// </remarks>
public record ReadPoliciesResponse
{
    public IEnumerable<ReadPolicyDto> Policies { get; init; } = new List<ReadPolicyDto>();
}
