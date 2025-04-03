using System.Threading.Tasks;
using Microsoft.Playwright;
using Shouldly;

namespace TicketBookingApp.EndToEndTests.Pages;

public class TicketBookingEventDetailsPage(Hooks.Hooks hooks)
{
    private readonly IPage _user = hooks.User;

    // Locator for the event title (assumed to be in an <h1> element)
    private ILocator EventTitle
        => _user.Locator("h1");

    // Locator for the "Book Ticket" button
    private ILocator BookTicketButton
        => _user.Locator("button:has-text('Book Ticket')");

    public async Task AssertEventTitle(string expectedTitle)
    {
        await _user.WaitForSelectorAsync("h1");
        var title = await EventTitle.InnerTextAsync();
        title.ShouldContain(expectedTitle);
    }

    public async Task ClickBookTicket()
    {
        await BookTicketButton.ClickAsync();
    }
}