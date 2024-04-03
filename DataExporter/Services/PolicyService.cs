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

    /// <returns> A ReadPolicyResponse representing the new policy, if succeded. Returns null, otherwise. </returns>
    public async Task<ReadPolicyResponse?> CreatePolicyAsync(CreatePolicyRequest createPolicyDto)
    {
        // TODO: Validation

        var model = createPolicyDto.ToModel();

        _dbContext.Policies.Add(model);
        await _dbContext.SaveChangesAsync();

        return model.ToDto();
    }

    public async Task<ReadPolicyResponse?> ReadPolicyAsync(int id)
    {
        var policy = await _dbContext.Policies.SingleAsync(x => x.Id == id);

        if (policy is null)
        {
            return null;
        }

        return policy.ToDto();
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

    public async Task<ExportDataResponse> ExportDataAsync(DateTime startDate, DateTime endDate)
    {
        // TODO: Validation

        var policies = await _dbContext.Policies
            .Where(x => x.StartDate >= startDate && x.StartDate < endDate)
            //.Include()
            .AsNoTracking()
            .ToListAsync();

        return new ExportDataResponse
        {
            Data = policies.Select(x => x.ToNotesDto())
        };
    }
}
