using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;
using TicketBookingApp.EndToEndTests.Pages;

namespace TicketBookingApp.EndToEndTests.StepDefinitions;

[Binding]
public class TicketBookingStepDefinitions(
    Hooks.Hooks hooks,
    TicketBookingHomePage ticketBookingHomePage)
{
    private readonly IPage _user = hooks.User;
    
    [Given(@"I navigate to the home page")]
    public async Task GivenINavigateToTheHomePage()
    {
        // Go to the home page
        await _user.GotoAsync("http://localhost:5140/?");
        
        // Assert that the page content is correct
        await ticketBookingHomePage.AssertPageContent();
    }

    [Then(@"I should see a list of events")]
    public void ThenIShouldSeeAListOfEvents()
    {
        ScenarioContext.StepIsPending();
    }
}