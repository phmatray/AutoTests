using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;
using Shouldly;
using TicketBookingApp.EndToEndTests.Pages;

namespace TicketBookingApp.EndToEndTests.StepDefinitions;

[Binding]
public class TicketBookingStepDefinitions(
    Hooks.Hooks hooks,
    TicketBookingHomePage homePage,
    TicketBookingEventDetailsPage eventDetailsPage,
    TicketBookingBookingPage bookingPage)
{
    private readonly IPage _user = hooks.User;
    
    [Given(@"I navigate to the home page")]
    public async Task GivenINavigateToTheHomePage()
    {
        // Go to the home page
        await _user.GotoAsync("http://localhost:5140/");
        
        // Assert that the page content is correct
        await homePage.AssertPageContent();
    }

    [Then(@"I should see a list of events")]
    public async Task ThenIShouldSeeAListOfEvents()
    {
        // This assertion is already performed in AssertPageContent; repeat if necessary.
        var eventCount = await _user.Locator("ul li a").CountAsync();
        eventCount.ShouldBeGreaterThan(0, "Expected to find at least one event on the home page.");
    }

    [Given(@"I navigate to the event details page for event with id (.*)")]
    public async Task GivenINavigateToTheEventDetailsPageForEventWithId(int eventId)
    {
        await _user.GotoAsync($"http://localhost:5140/eventdetails/{eventId}");
    }

    [Then(@"I should see the event title ""(.*)""")]
    public async Task ThenIShouldSeeTheEventTitle(string expectedTitle)
    {
        await eventDetailsPage.AssertEventTitle(expectedTitle);
    }

    [Given(@"I navigate to the booking page for event with id (.*)")]
    public async Task GivenINavigateToTheBookingPageForEventWithId(int eventId)
    {
        await _user.GotoAsync($"http://localhost:5140/booking/{eventId}");
    }

    [When(@"I enter ""(.*)"" into the ""(.*)"" field")]
    public async Task WhenIEnterIntoTheField(string inputText, string fieldName)
    {
        // In our case, we assume the only field is the "User Name" field.
        await bookingPage.EnterUserName(inputText);
    }

    [When(@"I click on ""(.*)""")]
    public async Task WhenIClickOn(string buttonText)
    {
        if (buttonText == "Confirm Booking")
        {
            await bookingPage.ClickConfirmBooking();
        }
        else if (buttonText == "Book Ticket")
        {
            await eventDetailsPage.ClickBookTicket();
        }
        else
        {
            // Fallback for other buttons
            await _user.ClickAsync($"button:has-text('{buttonText}')");
        }
    }

    [Then(@"I should see a confirmation message ""(.*)""")]
    public async Task ThenIShouldSeeAConfirmationMessage(string expectedMessage)
    {
        await bookingPage.AssertBookingConfirmedMessage(expectedMessage);
    }
}