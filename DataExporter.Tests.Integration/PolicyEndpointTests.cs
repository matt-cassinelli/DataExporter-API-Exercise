using System.Net;
using System.Net.Http.Json;
using DataExporter.Dtos;

namespace DataExporter.Tests.Integration;

public class PolicyEndpointTests
{
    private readonly HttpClient _httpClient;

    public PolicyEndpointTests()
    {
        _httpClient = new HttpClient();
    }

    [Test, Order(1)]
    public async Task Can_Create_Policy()
    {
        var requestBody = new CreatePolicyRequest
        {
            PolicyNumber = "AAAA9999",
            Premium = 123,
            StartDate = DateTime.Parse("2025-12-13T14:15:00.0000000Z")
        };

        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("https://localhost:7246/policies"),
            Method = HttpMethod.Post,
            Content = JsonContent.Create(requestBody, mediaType: null)
        };

        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseBody = await response.Content.ReadFromJsonAsync<ReadPolicyResponse>();

        responseBody!.PolicyNumber.Should().Be(requestBody.PolicyNumber);
        responseBody!.Premium.Should().Be(requestBody.Premium);
        responseBody!.StartDate.Should().Be(requestBody.StartDate);
        responseBody!.Id.Should().NotBe(default);
    }

    [Test, Order(2)]
    public async Task Can_Read_Policies()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7246/policies");

        var response = await _httpClient.SendAsync(request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await response.Content.ReadFromJsonAsync<ReadPoliciesResponse>();

        body!.Policies.Should().HaveCount(6); // 5 seeded + 1 created above
        body!.Policies.Select(x => x.PolicyNumber).Should().Contain("AAAA9999");
    }

    [Test, Order(3)]
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
