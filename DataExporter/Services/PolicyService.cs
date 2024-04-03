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
    public async Task<ReadPolicyDto?> CreatePolicyAsync(CreatePolicyDto createPolicyDto)
    {
        return await Task.FromResult(new ReadPolicyDto());
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

    public async Task<ReadPolicyDto?> ReadPolicyAsync(int id)
    {
        var policy = await _dbContext.Policies.SingleAsync(x => x.Id == id);
        if (policy == null)
        {
            return null;
        }

        var policyDto = new ReadPolicyDto()
        {
            Id = policy.Id,
            PolicyNumber = policy.PolicyNumber,
            Premium = policy.Premium,
            StartDate = policy.StartDate
        };

        return policyDto;
    }
}
