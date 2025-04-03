using System.Threading.Tasks;
using Microsoft.Playwright;
using Shouldly;

namespace TicketBookingApp.EndToEndTests.Pages;

public class TicketBookingBookingPage(Hooks.Hooks hooks)
{
    private readonly IPage _user = hooks.User;

    // Locator for the "User Name" input field
    private ILocator UserNameInput
        => _user.Locator("input[id='userName']");

    // Locator for the "Confirm Booking" button
    private ILocator ConfirmBookingButton
        => _user.Locator("button:has-text('Confirm Booking')");

    // Locator for the confirmation message (assumed to be in an <h2> element)
    private ILocator ConfirmationMessage
        => _user.Locator("h2");

    public async Task EnterUserName(string userName)
    {
        await UserNameInput.FillAsync(userName);
        var value = await UserNameInput.InputValueAsync();
        value.ShouldBe(userName);
    }

    public async Task ClickConfirmBooking()
    {
        await ConfirmBookingButton.ClickAsync();
    }

    public async Task AssertBookingConfirmedMessage(string expectedMessage)
    {
        await _user.WaitForSelectorAsync("h2");
        var message = await ConfirmationMessage.InnerTextAsync();
        message.ShouldContain(expectedMessage);
    }
}