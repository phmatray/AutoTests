using System.Threading.Tasks;
using Microsoft.Playwright;
using Reqnroll;

namespace TicketBookingApp.EndToEndTests.Hooks;

[Binding]
public class Hooks
{
    public IPage User { get; private set; } = null!; //-> We'll call this property in the tests

    [BeforeScenario] // -> Notice how we're doing these steps before each scenario
    public async Task RegisterSingleInstancePractitioner()
    {
        //Initialise Playwright
        IPlaywright playwright = await Playwright.CreateAsync();
        
        //Initialise a browser - 'Chromium' can be changed to 'Firefox' or 'Webkit'
        IBrowser browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false // -> Use this option to be able to see your test running
        });
        
        //Setup a browser context
        IBrowserContext context1 = await browser.NewContextAsync();

        //Initialise a page on the browser context.
        User = await context1.NewPageAsync(); 
    }
}
