using System.Net;
using System.Net.Http.Json;
using DataExporter.Dtos;

namespace DataExporter.Tests.Integration;

[Collection("Sequential")]
public class PolicyEndpointTests
{
    private readonly HttpClient _httpClient;

    public PolicyEndpointTests()
    {
        _httpClient = new HttpClient();
    }

    [Fact]
    public async Task Can_Read_Policies()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7246/policies");
        
        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadFromJsonAsync<ReadPoliciesResponse>();

        body!.Policies.Should().HaveCount(5);
        body!.Policies.Select(x => x.PolicyNumber).Should().Contain("HSCX1001");
    }

    [Fact]
    public async Task Can_Read_Policy()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7246/policies/1");

        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadFromJsonAsync<ReadPolicyResponse>();

        body!.PolicyNumber.Should().Be("HSCX1001");
        body!.Premium.Should().Be(200);
    }
}
