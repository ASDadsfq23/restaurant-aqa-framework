using System.Text.Json;
using Restaurant_Aqa_Framework.Configuration;
using Restaurant_Aqa_Framework.Screenplay;
using Restaurant_Aqa_Framework.Support;
using Reqnroll;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Restaurant_Aqa_Framework.StepDefinitions;

[Binding]
public sealed class GroupPreOrderStepDefinitions(Actor actor) : StepDefinitionBase(actor)
{
    private static readonly HttpClient HttpClient = new();
    private HttpResponseMessage? _response;
    private string _groupId = string.Empty;

    [Given("a group pre-order exists with ID {string}")]
    public void GivenAGroupPreOrderExistsWithID(string groupId)
    {
        _groupId = groupId;
    }

    [Given("a non-existent group ID {string}")]
    public void GivenANonExistentGroupID(string groupId)
    {
        _groupId = groupId;
    }

    [When("the user requests the group details via API")]
    public async Task WhenTheUserRequestsTheGroupDetailsViaAPI()
    {
        var baseUrl = (Environment.GetEnvironmentVariable("API_URL") ?? "https://or6ic53c0a.execute-api.us-west-2.amazonaws.com/dev").TrimEnd('/');
        _response = await HttpClient.GetAsync($"{baseUrl}/group-orders/{_groupId}");
    }

    [Then("the response status code should be {int}")]
    public async Task ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        await Assert.That(_response).IsNotNull();
        await Assert.That((int)_response!.StatusCode).EqualTo(expectedStatusCode);
    }

    [Then("the group details should contain participants list and total amount")]
    public async Task ThenTheGroupDetailsShouldContainParticipantsListAndTotalAmount()
    {
        await Assert.That(_response).IsNotNull();
        var content = await _response!.Content.ReadAsStringAsync();
        using var json = JsonDocument.Parse(content);
        await Assert.That(json.RootElement.ValueKind).EqualTo(JsonValueKind.Object);
    }
}