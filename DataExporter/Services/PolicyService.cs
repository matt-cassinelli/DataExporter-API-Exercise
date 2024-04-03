using DataExporter.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataExporter.Services;

public class PolicyService
{
    private ExporterDbContext _dbContext;

    public PolicyService(ExporterDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    /// <returns> A ReadPolicyDto representing the new policy, if succeded. Returns null, otherwise. </returns>
    public async Task<ReadPolicyResponse?> CreatePolicyAsync(CreatePolicyDto createPolicyDto)
    {
        return await Task.FromResult(new ReadPolicyResponse());
    }

    public async Task<ReadPoliciesResponse> ReadPoliciesAsync()
    {
        var policies = await _dbContext.Policies
            .AsNoTracking()
            .ToListAsync();

        return new ReadPoliciesResponse
        {
            Policies = policies.Select(x => x.ToDto())
        };
    }

    public async Task<ReadPolicyResponse?> ReadPolicyAsync(int id)
    {
        var policy = await _dbContext.Policies.SingleAsync(x => x.Id == id); // TODO: When primary key set up, use FindAsync() instead

        if (policy is null)
        {
            return null;
        }

        return policy.ToDto();
    }
}
