using System.Threading.Tasks;
using Microsoft.Playwright;
using Shouldly;

namespace TicketBookingApp.EndToEndTests.Pages;

public class TicketBookingHomePage(Hooks.Hooks hooks)
{
    private readonly IPage _user = hooks.User;

    // Locator for event links (assuming events are rendered as <ul><li><a> elements)
    private ILocator EventLinks
        => _user.Locator("ul li a");

    public async Task AssertPageContent()
    {
        // Assert that the correct URL has been reached
        _user.Url.ShouldBe("http://localhost:5140/");
            
        // Assert that at least one event link is visible
        var eventCount = await EventLinks.CountAsync();
        eventCount.ShouldBeGreaterThan(0, "No events were found on the home page.");
    }

    // Optional: click on an event by its id (if links include the event id)
    public async Task ClickEventById(int eventId)
    {
        var eventLink = _user.Locator($"a[href='/eventdetails/{eventId}']");
        await eventLink.ClickAsync();
    }
}